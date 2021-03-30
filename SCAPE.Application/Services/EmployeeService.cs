using SCAPE.Application.Interfaces;
using SCAPE.Domain.Entities;
using SCAPE.Domain.Interfaces;
using System.Threading.Tasks;

namespace SCAPE.Application.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task insertEmployee(Employee employee)
        {
            await _employeeRepository.insertEmployee(employee);
        }
    }
}
