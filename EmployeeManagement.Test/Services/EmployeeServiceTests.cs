using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test.Services
{
    public class EmployeeServiceTests
    {
        [Fact(DisplayName = "Should add multiple Employees")]
        [Trait("Service", "Employee")]
        public async void AddMultipleEmployees_ShouldAddMultipleEmployees()
        {
            //Arrange
            Mock<IEmployeeRepository> repository = new Mock<IEmployeeRepository>();
            repository.Setup(r => r.GetEmployeeByRegistrationNumberAndName(It.IsAny<long>(), It.IsAny<string>())).Returns(Task.FromResult<Employee>(null));
            List<Employee> employees = new List<Employee>() { new Employee() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas" } };

            //Act
            var result = await new EmployeeService(repository.Object).AddMultipleEmployees(employees);

            //Assert
            Assert.True(result.Count > 0);
        }

        [Fact(DisplayName = "Should not add Employees because one of them is already in the database")]
        [Trait("Service", "Employee")]
        public async void AddMultipleEmployees_ShouldNot()
        {
            //Arrange
            Mock<IEmployeeRepository> repository = new Mock<IEmployeeRepository>();
            repository.Setup(r => r.GetEmployeeByRegistrationNumberAndName(It.IsAny<long>(), It.IsAny<string>())).Returns(Task.FromResult<Employee>(new Employee { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas" }));
            List<Employee> employees = new List<Employee>() { new Employee() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas" } };

            //Act
            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await new EmployeeService(repository.Object).AddMultipleEmployees(employees));
        }

        [Fact(DisplayName = "Should remove multiple employees")]
        [Trait("Service", "Employee")]
        public async void Remove_ShouldRemoveMultipleEmployees()
        {
            //Arrange
            Mock<IEmployeeRepository> repository = new Mock<IEmployeeRepository>();
            repository.Setup(r => r.GetEmployeeByRegistrationNumberAndName(It.IsAny<long>(), It.IsAny<string>())).Returns(Task.FromResult<Employee>(new Employee { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas" }));
            Dictionary<long, string> employees = new Dictionary<long, string>() { { 4856, "Jhon Doe" } };

            //Act
            var result = await new EmployeeService(repository.Object).RemoveMultipleEmployees(employees);

            //Assert
            Assert.True(result.Count > 0);
        }

        [Fact(DisplayName = "Should not remove multiple employees because one of them is not in the database")]
        [Trait("Service", "Employee")]
        public async void Remove_ShouldNotRemove()
        {
            //Arrange
            Mock<IEmployeeRepository> repository = new Mock<IEmployeeRepository>();
            repository.Setup(r => r.GetEmployeeByRegistrationNumberAndName(It.IsAny<long>(), It.IsAny<string>())).Returns(Task.FromResult<Employee>(null));
            Dictionary<long, string> employees = new Dictionary<long, string>() { { 4856, "Jhon Doe" } };

            //Act
            //Assert
            await Assert.ThrowsAsync<Exception>(async () => await new EmployeeService(repository.Object).RemoveMultipleEmployees(employees));
        }
    }
}
