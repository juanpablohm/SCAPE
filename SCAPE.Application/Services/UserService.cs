

using SCAPE.Application.Interfaces;
using SCAPE.Application.Utils;
using SCAPE.Domain.Entities;
using SCAPE.Domain.Exceptions;
using SCAPE.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace SCAPE.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        private readonly IEmployeeRepository _employeeRepository;

        public UserService(IUserRepository userRepository, IEmployeeRepository employeeRepository)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
        }

        
        public async Task<bool> addUser(string email, string password, string role)
        {
            User user = null;
            /*
             * Validar que no existan más usuarios con ese correo
             */
            user = await _userRepository.findEmployeeByEmail(email);

            if (user == null)
            {
                User newUser = new User();
                newUser.Id = 0;
                newUser.Email = email;
                newUser.Password = Encrypt.GetSHA256(password); //Encriptar contraseña
                newUser.Role = role;

                bool isInsert =  await _userRepository.insertUser(newUser);

                if (!isInsert)
                {
                    throw new UserException("There was an error entering user.");
                }
            }
            else
            {
                throw new UserException("There is user linked to that email");
            }

            return true;
        }

        public async Task<User> login(string email, string password)
        {
            User user = new User();
            user.Email = email;
            user.Password = Encrypt.GetSHA256(password);
            
            User oUser = await _userRepository.getUser(user);

            if (oUser == null)
            {
                throw new UserException("There was an error with credentials");
            }
            oUser.Password = "";
            return oUser;
        }
    }
}
