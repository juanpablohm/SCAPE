using Moq;
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
    public class InsertEmployeeTest
    {
        private EmployeeService employeeService;
        private List<Employee> employees;

        public InsertEmployeeTest()
        {
            var mock_Repository = new Mock<IEmployeeRepository>();
            employees = new List<Employee>();

            mock_Repository.Setup(m => m.insertEmployee(It.IsAny<Employee>())).Returns(
               async (Employee newEmployee) =>
                {
                    if (employees.FirstOrDefault(o => o.Email == newEmployee.Email) != null)
                        return false;
 
                    employees.Add(newEmployee);
                    return true;
                }
            );

            mock_Repository.Setup(m => m.findEmployee(It.IsAny<string>())).Returns(
                async (string document) => employees.FirstOrDefault(o => o.DocumentId == document)
            );
            employeeService = new EmployeeService(mock_Repository.Object, null);
        }

        [Fact]
        public async Task insertValidEmployee()
        {
            Employee newEmployee = new Employee();

            newEmployee.DocumentId = "1234567891";
            newEmployee.FirstName = "Pepito";
            newEmployee.LastName = "Perez";
            newEmployee.Email = "pepitoperez@scape.com";
            newEmployee.Sex = "H";
            newEmployee.DateBirth = new DateTime(2000, 3, 1, 7, 0, 0);

            await employeeService.insertEmployee(newEmployee);

            Employee searchEmployee = await employeeService.findEmployee(newEmployee.DocumentId);

            Assert.Equal(searchEmployee.DocumentId, newEmployee.DocumentId);
            Assert.Equal(searchEmployee.FirstName, newEmployee.FirstName);
            Assert.Equal(searchEmployee.LastName, newEmployee.LastName);
            Assert.Equal(searchEmployee.Email, newEmployee.Email);
            Assert.Equal(searchEmployee.Sex, newEmployee.Sex);
            Assert.Equal(searchEmployee.DateBirth, newEmployee.DateBirth);
        }

        [Fact]
        public async Task insertEmployeeWithAlreadyRegisterDocument()
        {

            Employee newEmployee = new Employee();

            newEmployee.DocumentId = "1234567892";
            newEmployee.FirstName = "Ricardo";
            newEmployee.LastName = "Martinez";
            newEmployee.Email = "ricardomartinez@scape.com";
            newEmployee.Sex = "H";
            newEmployee.DateBirth = new DateTime(2000, 3, 1, 7, 0, 0);

            await employeeService.insertEmployee(newEmployee);

            newEmployee.FirstName = "Pedro";
            newEmployee.LastName = "Perez";
            newEmployee.Email = "ricardomartinez@scape.com";

            RegisterEmployeeException exception = await Assert.ThrowsAsync<RegisterEmployeeException>(
               () => employeeService.insertEmployee(newEmployee)
            );
            Assert.Equal("An employee with the same document id has already been registered", exception.Message);
        }


        [Fact]
        public async Task insertEmployeeWithInvalidDocument()
        {
            Employee newEmployee = new Employee();

            newEmployee.DocumentId = "145231ACDF";
            newEmployee.FirstName = "Marie";
            newEmployee.LastName = "Curie";
            newEmployee.Email = "mariecurie@scape.com";
            newEmployee.Sex = "M";
            newEmployee.DateBirth = new DateTime(2000, 3, 1, 7, 0, 0);

            RegisterEmployeeException exception = await Assert.ThrowsAsync<RegisterEmployeeException>(
               () => employeeService.insertEmployee(newEmployee)
            );
            Assert.Equal("Document entered is not valid", exception.Message);
        }

        [Fact]
        public async Task insertEmployeeWithInvalidEmail()
        {
            Employee newEmployee = new Employee();

            newEmployee.DocumentId = "6543215462";
            newEmployee.FirstName = "Margaret";
            newEmployee.LastName = "Hamilton";
            newEmployee.Email = "margaret.hamilton";
            newEmployee.Sex = "M";
            newEmployee.DateBirth = new DateTime(2000, 3, 1, 7, 0, 0);

            RegisterEmployeeException exception = await Assert.ThrowsAsync<RegisterEmployeeException>(
               () => employeeService.insertEmployee(newEmployee)
            );
            Assert.Equal("Email address entered is not valid", exception.Message);
        }

        [Fact]
        public async Task insertEmployeeWithoutDocument()
        {
            Employee newEmployee = new Employee();

            newEmployee.DocumentId = null;
            newEmployee.FirstName = "Bruno";
            newEmployee.LastName = "Mars";
            newEmployee.Email = "brunomars@scape.com";
            newEmployee.Sex = "H";
            newEmployee.DateBirth = new DateTime(2000, 3, 1, 7, 0, 0);

            RegisterEmployeeException exception = await Assert.ThrowsAsync<RegisterEmployeeException>(
               () => employeeService.insertEmployee(newEmployee)
            );
            Assert.Equal("The document, name and lastname fields are required", exception.Message);
        }
    }

    }
