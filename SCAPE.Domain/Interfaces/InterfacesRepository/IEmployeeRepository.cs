using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCAPE.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task insertEmployee(Employee employee);

        Task saveImageEmployee(EmployeeImage image);

        Task<Employee> findEmployee(string documentId);

        Task<Employee> findEmployeeByPersistedFaceId(string persistedFaceId);
    }
}
