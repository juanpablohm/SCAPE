using Microsoft.EntityFrameworkCore;
using SCAPE.Domain.Entities;
using SCAPE.Domain.Interfaces;
using SCAPE.Infraestructure.Context;
using System;
using System.Threading.Tasks;

namespace SCAPE.Infraestructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly SCAPEDBContext _context;

        public AttendanceRepository(SCAPEDBContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Insert Attendance into the context (SCAPEDB in this case)
        /// </summary>
        /// <param name="attendance">Attendance to insert</param>
        public async Task<bool> insertAttendance(Attendance attendance)
        {
            _context.Attendance.Add(attendance);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
