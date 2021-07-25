

using SCAPE.Application.Interfaces;
using SCAPE.Domain.Entities;
using SCAPE.Domain.Exceptions;
using SCAPE.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace SCAPE.Application.Services
{
    public class AttendanceService : IAttendanceService
    {

        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository, IEmployeeRepository employeeRepository)
        {
            _attendanceRepository = attendanceRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> addAttendance(DateTime date, string type, string documentEmployee)
        {
            Employee employee = await _employeeRepository.findEmployee(documentEmployee);

            if(employee != null)
            {
                Attendance newAttendance = new Attendance();
                newAttendance.Date = date;
                newAttendance.Type = type;
                newAttendance.IdEmployee = employee.Id;

                if(type.Length != 1)
                {
                    throw new AttendanceException("The type of Attendance is a character, not a string");
                }

                bool isInsert =  await _attendanceRepository.insertAttendance(newAttendance);

                if (!isInsert)
                {
                    throw new AttendanceException("There was an error entering attendance.");
                }
            }
            else
            {
                throw new EmployeeException("There is no employee linked to that document");
            }

            return true;
        }
    }
}
