using Moq;
using SCAPE.API.ActionsModels;
using SCAPE.Application.Services;
using SCAPE.Domain.Entities;
using SCAPE.Domain.Exceptions;
using SCAPE.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SCAPE.UnitTests
{
    public class AddAttendanceTest
    {
        private AttendanceService attendanceService;
        private List<Attendance> attendances;
        public AddAttendanceTest()
        {
        }

        [Fact]
        public async Task AddAttendanceTestInvalidDocumentEmployee()
        {
            AttendanceModel newAttendance = new AttendanceModel();
            newAttendance.dateTime = new DateTime(2021, 07, 25);
            newAttendance.documentEmployee = "44SXH43";   //Invalid Document
            newAttendance.type = "I";

            
            var mock_Repository_Employee = new Mock<IEmployeeRepository>();
            mock_Repository_Employee.Setup(m => m.findEmployee(It.IsAny<string>())).Returns(
                async (string document) => { return null; }
            );

            attendanceService = new AttendanceService(null, mock_Repository_Employee.Object);

            EmployeeException exception = await Assert.ThrowsAsync<EmployeeException>(
               () => attendanceService.addAttendance(newAttendance.dateTime, newAttendance.type, newAttendance.documentEmployee)
            );
            Assert.Equal("There is no employee linked to that document", exception.Message);
        }

        [Fact]
        public async Task AddAttendanceTestInvalidDateTime()
        {
            AttendanceModel newAttendance = new AttendanceModel();
            newAttendance.documentEmployee = "9999";   
            newAttendance.type = "I";

            String dateInvalid = "2021_07_25T07:45"; //Invalid DateTime String

            await Assert.ThrowsAsync<FormatException>(
               () => attendanceService.addAttendance(DateTime.Parse(dateInvalid, null, System.Globalization.DateTimeStyles.RoundtripKind), newAttendance.type, newAttendance.documentEmployee)
            );
        }

        [Fact]
        public async Task AddAttendanceTestInvalidType()
        {
            AttendanceModel newAttendance = new AttendanceModel();
            newAttendance.dateTime = new DateTime(2021, 07, 25);
            newAttendance.documentEmployee = "9999";   
            newAttendance.type = "loreps"; //Invalid Type

            Employee employee = new Employee();
            employee.DocumentId = "9999";

            var mock_Repository_Employee = new Mock<IEmployeeRepository>();
            mock_Repository_Employee.Setup(m => m.findEmployee(It.IsAny<string>())).Returns(
                async (string document) => { return employee; }
            );

            attendanceService = new AttendanceService(null, mock_Repository_Employee.Object);

            AttendanceException exception = await Assert.ThrowsAsync<AttendanceException>(
               () => attendanceService.addAttendance(newAttendance.dateTime, newAttendance.type, newAttendance.documentEmployee)
            );
            Assert.Equal("The type of Attendance is a character, not a string", exception.Message);
        }

        [Fact]
        public async Task AddAttendanceTestValid()
        {
            Employee employee = new Employee();
            employee.DocumentId = "9999";

            var mock_Repository_Employee = new Mock<IEmployeeRepository>();
            mock_Repository_Employee.Setup(m => m.findEmployee(It.IsAny<string>())).Returns(
                async (string document) => { return employee; }
            );

            AttendanceModel newAttendance = new AttendanceModel();
            newAttendance.dateTime = new DateTime(2021, 07, 25);
            newAttendance.documentEmployee = "9999";
            newAttendance.type = "I";

            var mock_Repository_Attendance = new Mock<IAttendanceRepository>();
            mock_Repository_Attendance.Setup(m => m.insertAttendance(It.IsAny<Attendance>())).Returns(
                async (Attendance attendance) => { return true; }
            );

            attendanceService = new AttendanceService(mock_Repository_Attendance.Object, mock_Repository_Employee.Object);


            Assert.True(await attendanceService.addAttendance(newAttendance.dateTime, newAttendance.type, newAttendance.documentEmployee));
        }
    }
}
