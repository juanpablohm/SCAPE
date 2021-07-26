

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

        /// <summary>
        /// This method contain bussiness logic
        /// Add attendance to _attendanceRepository
        /// </summary>
        /// <param name="date">Current date of attendance</param>
        /// <param name="type">Type of attendance</param>
        /// <param name="documentEmployee">Employee's document of attendance</param>
        /// <returns>
        /// return a error message, if there is not employee linked to that document
        /// return a error message, if the attendance's type is not valid,
        /// return a error message, if the attendance is not add,
        /// if the insert is success, return true
        /// </returns>
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
                throw new EmployeeException("There is not employee linked to that document");
            }

            return true;
        }
    }
}
