using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Service;
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
        [Fact(DisplayName = "Deve adicionar multiplos funcionarios")]
        [Trait("Service", "Employee")]
        public async void AddMultipleEmployees_Should()
        {
            //Arrange
            var repository = new Mock<IEmployeeRepository>();
            repository.Setup(r => r.GetEmployeeByRegistrationNumberAndName(It.IsAny<long>(), It.IsAny<string>())).Returns(Task.FromResult<Employee>(null));
            var employees = new List<Employee>() { new Employee() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas" } };
            //Act
            var result = await new EmployeeService(repository.Object).AddMultipleEmployees(employees);

            //Assert
            Assert.True(result.Count>0);
        }

        [Fact(DisplayName = "Não deve adicionar multiplos funcionarios")]
        [Trait("Service", "Employee")]
        public void AddMultipleEmployees_ShouldNot()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact(DisplayName = "Deve remover multiplos funcionarios")]
        [Trait("Service", "Employee")]
        public void Remove_ShouldRemove()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact(DisplayName = "Não deve remover multiplos funcionarios")]
        [Trait("Service", "Employee")]
        public void Remove_ShouldNotRemove()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
