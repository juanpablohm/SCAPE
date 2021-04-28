using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// Insert employee into the context (SCAPEDB in this case)
        /// </summary>
        /// <param name="employee">Employee to insert</param>
        public async Task insertEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
        }


        public async Task<Employee> findEmployee(string documentId)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.DocumentId == documentId);
            
        }

        public async Task saveImageEmployee(EmployeeImage image)
        {
            _context.Image.Add(image);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> findEmployeeByPersistedFaceId(string persistedFaceId)
        {
            EmployeeImage image = await _context.Image.FirstOrDefaultAsync(i => i.PersistenceFaceId == persistedFaceId);
            return await _context.Employee.FirstOrDefaultAsync(e => e.Id == image.IdEmployee);
        }
    }
}
