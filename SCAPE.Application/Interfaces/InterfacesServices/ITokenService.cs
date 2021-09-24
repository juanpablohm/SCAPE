using SCAPE.Application.DTOs;
using SCAPE.Domain.Entities;
using System.Threading.Tasks;

namespace SCAPE.Application.Interfaces
{
    public interface ITokenService
    {
        TokenModelDTO getToken(User user,string secretKey);

    }
}
