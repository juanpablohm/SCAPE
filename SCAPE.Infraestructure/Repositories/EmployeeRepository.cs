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

        /// <summary>
        /// Find employee at the context (SCAPEDB in this case)
        /// </summary>
        /// <param name="documentId">employee's documentId to find</param>
        /// <returns>>A successful call returns a Employee</returns>
        public async Task<Employee> findEmployee(string documentId)
        {
            return await _context.Employee.FirstOrDefaultAsync(e => e.DocumentId == documentId);
            
        }
        /// <summary>
        /// Saves the employee's image into the context (SCAPEDB in this case)
        /// </summary>
        /// <param name="image">Employee image to save</param>
        public async Task saveImageEmployee(EmployeeImage image)
        {
            _context.Image.Add(image);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        ///  Find employee by PersistedFaceId at the context (SCAPEDB in this case)
        /// </summary>
        /// <param name="persistedFaceId">persistedFaceId to find </param>
        /// <returns>A successful call returns a Employee</returns>
        public async Task<Employee> findEmployeeByPersistedFaceId(string persistedFaceId)
        {
            EmployeeImage image = await _context.Image.FirstOrDefaultAsync(i => i.PersistenceFaceId == persistedFaceId);
            
            if (image == null)
            {
                return null;
            }
            
            return await _context.Employee.FirstOrDefaultAsync(e => e.Id == image.IdEmployee);
        }
    }
}
