using SCAPE.Domain.Entities;
using System.Threading.Tasks;

namespace SCAPE.Domain.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<bool> insertAttendance(Attendance attendance);
    }
}
