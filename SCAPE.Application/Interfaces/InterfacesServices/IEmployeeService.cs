using SCAPE.Application.DTOs;
using SCAPE.Domain.Entities;
using System.Threading.Tasks;

namespace SCAPE.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task insertEmployee(Employee employee);

        Task<bool> associateFace(string documentId, string encodeImage);

        Task<Employee> getEmployeeByFace(string encodeImage,string faceListId);

        Task<Employee> findEmployee(string documentId);
    }
}
