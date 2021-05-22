using Moq;
using ProfitSharing.Domain.DTOs;
using ProfitSharing.Domain.Interfaces;
using ProfitSharing.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace ProfitSharing.Tests.Services
{
    public class ProfitSharingServiceTests
    {
        [Fact(DisplayName = "Deve calcular corretamente")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldCalculateProfitWhenAvailableAmountIsSufficient()
        {
            //Arrange
            var availableSum = 10000.00M;
            var client = new Mock<IEmployeeManagementClient>();
            client.Setup(c => c.GetAllEmployees()).Returns(Task.FromResult( new List<EmployeeDTO> { new EmployeeDTO() { }, new EmployeeDTO() { } }));

            //Act
            var profit = await new ProfitSharingService(client.Object).CalculateProfitSharing(availableSum);
            var maskedResult = Regex.Replace(profit.BalanceSum, @"[R$ .]", "");
            var result = Convert.ToDecimal(Regex.Replace(maskedResult, @"[,]", "."));

            //Assert
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "Não deve calcular corretamente")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldNotCalculate()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
