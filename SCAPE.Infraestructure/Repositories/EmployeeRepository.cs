using SCAPE.Domain.Entities;
using SCAPE.Domain.Interfaces;
using SCAPE.Infraestructure.Context;
using System;
using System.Threading.Tasks;

namespace SCAPE.Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SCAPEDBContext _context;

        public EmployeeRepository(SCAPEDBContext context)
        {
            _context = context;
        }

        public async Task insertEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}
