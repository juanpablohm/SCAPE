using SCAPE.Domain.Entities;
using System.Threading.Tasks;

namespace SCAPE.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> insertUser(User user);
        Task<User> findEmployeeByEmail(string email);
        Task<User> getUser(User user);
    }
}
