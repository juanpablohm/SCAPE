using SCAPE.Application.DTOs;
using SCAPE.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SCAPE.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> addUser(string email, string password, string role);
        Task<User> login(string email, string password);
    }
}
