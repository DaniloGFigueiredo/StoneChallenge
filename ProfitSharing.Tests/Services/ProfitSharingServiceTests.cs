using Moq;
using ProfitSharing.Domain.DTOs;
using ProfitSharing.Domain.Interfaces;
using ProfitSharing.Service;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace ProfitSharing.Tests.Services
{
    public class ProfitSharingServiceTests
    {
        [Fact(DisplayName = "Should calculate correclty when the available amount is sufficient")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldCalculateProfitWhenAvailableAmountIsSufficient()
        {
            //Arrange
            decimal availableSum = 500000.00M;
            Mock<IEmployeeManagementClient> client = new Mock<IEmployeeManagementClient>();
            client.Setup(c => c.GetAllEmployees()).Returns(Task.FromResult(new List<EmployeeDTO> { new EmployeeDTO() { AdmissionDate = new DateTime(2015, 06, 07), Area = Domain.Enums.Enum.EmployeeArea.CustomerRelations, GrossSalary = 3899.74M, Name = "John Doe", RegistrationNumber = 4585, Role = "Líder de Relacionamento", Id = "60a59ee7ab4483dac5fade51" }, new EmployeeDTO() { AdmissionDate = new DateTime(2015, 01, 05), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 1396.52M, Name = "John Doe", RegistrationNumber = 4515, Role = "Auxiliar de Contabilidade", Id = "60a59ee7ab4483dac5fade51" } }));

            //Act
            ProfitSharingResultDTO profit = await new ProfitSharingService(client.Object).CalculateProfitSharing(availableSum);

            string firstParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[0].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string secondParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[1].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string maskedResult = Regex.Replace(profit.BalanceSum, @"[R$ .]", "");

            decimal result = Convert.ToDecimal(Regex.Replace(maskedResult, @"[,]", "."));
            decimal firstParticipantSum = Convert.ToDecimal(Regex.Replace(firstParticipantMaskedResult, @"[,]", "."));
            decimal secondParticipant = Convert.ToDecimal(Regex.Replace(secondParticipantMaskedResult, @"[,]", "."));

            //Assert
            Assert.True(firstParticipantSum == 187187.52M);
            Assert.True(secondParticipant == 83791.20M);
            Assert.True(result > 0);
        }

        [Fact(DisplayName = "Should calculate correclty when the available amount is insufficient")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldCalculateProfitWhenAvailableAmountIsInsufficient()
        {
            //Arrange
            decimal availableSum = 100000.00M;
            Mock<IEmployeeManagementClient> client = new Mock<IEmployeeManagementClient>();
            client.Setup(c => c.GetAllEmployees()).Returns(Task.FromResult(new List<EmployeeDTO> { new EmployeeDTO() { AdmissionDate = new DateTime(2015, 06, 07), Area = Domain.Enums.Enum.EmployeeArea.CustomerRelations, GrossSalary = 3899.74M, Name = "John Doe", RegistrationNumber = 4585, Role = "Líder de Relacionamento", Id = "60a59ee7ab4483dac5fade51" }, new EmployeeDTO() { AdmissionDate = new DateTime(2015, 01, 05), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 1396.52M, Name = "John Doe", RegistrationNumber = 4515, Role = "Auxiliar de Contabilidade", Id = "60a59ee7ab4483dac5fade51" } }));

            //Act
            ProfitSharingResultDTO profit = await new ProfitSharingService(client.Object).CalculateProfitSharing(availableSum);

            string firstParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[0].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string secondParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[1].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string maskedResult = Regex.Replace(profit.BalanceSum, @"[R$ .]", "");

            decimal result = Convert.ToDecimal(Regex.Replace(maskedResult, @"[,]", "."));
            decimal firstParticipantSum = Convert.ToDecimal(Regex.Replace(firstParticipantMaskedResult, @"[,]", "."));
            decimal secondParticipant = Convert.ToDecimal(Regex.Replace(secondParticipantMaskedResult, @"[,]", "."));

            //Assert
            Assert.True(firstParticipantSum == 69078.31M);
            Assert.True(secondParticipant == 30921.69M);
            Assert.True(result == 0);
        }


        [Fact(DisplayName = "Should not calculate correctly when the available amount is sufficient")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldNotCalculateCorrectlyWhenTheAmountIsSufficient()
        {
            //Arrange
            decimal availableSum = 500000.00M;
            Mock<IEmployeeManagementClient> client = new Mock<IEmployeeManagementClient>();
            client.Setup(c => c.GetAllEmployees()).Returns(Task.FromResult(new List<EmployeeDTO> { new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas", Id = "60a59ee7ab4483dac5fade51" }, new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.CustomerRelations, GrossSalary = 4000.00M, Name = "John Doe", RegistrationNumber = 4515, Role = "Líder de Relacionamento", Id = "60a59ee7ab4483dac5fade51" } }));

            //Act
            ProfitSharingResultDTO profit = await new ProfitSharingService(client.Object).CalculateProfitSharing(availableSum);

            string firstParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[0].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string secondParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[1].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string maskedResult = Regex.Replace(profit.BalanceSum, @"[R$ .]", "");

            decimal result = Convert.ToDecimal(Regex.Replace(maskedResult, @"[,]", "."));
            decimal firstParticipantSum = Convert.ToDecimal(Regex.Replace(firstParticipantMaskedResult, @"[,]", "."));
            decimal secondParticipant = Convert.ToDecimal(Regex.Replace(secondParticipantMaskedResult, @"[,]", "."));

            //Assert
            Assert.False(firstParticipantSum == 187187.52M);
            Assert.False(secondParticipant == 83791.20M);
            Assert.False(result == 0);
        }


        [Fact(DisplayName = "Should not calculate correclty when the available amount is insufficient")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldNotCalculateProfitWhenAvailableAmountIsInsufficient()
        {
            //Arrange
            decimal availableSum = 100000.00M;
            Mock<IEmployeeManagementClient> client = new Mock<IEmployeeManagementClient>();
            client.Setup(c => c.GetAllEmployees()).Returns(Task.FromResult(new List<EmployeeDTO> { new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas", Id = "60a59ee7ab4483dac5fade51" }, new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.CustomerRelations, GrossSalary = 4000.00M, Name = "John Doe", RegistrationNumber = 4515, Role = "Líder de Relacionamento", Id = "60a59ee7ab4483dac5fade51" } }));

            //Act
            ProfitSharingResultDTO profit = await new ProfitSharingService(client.Object).CalculateProfitSharing(availableSum);

            string firstParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[0].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string secondParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[1].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string maskedResult = Regex.Replace(profit.BalanceSum, @"[R$ .]", "");

            decimal result = Convert.ToDecimal(Regex.Replace(maskedResult, @"[,]", "."));
            decimal firstParticipantSum = Convert.ToDecimal(Regex.Replace(firstParticipantMaskedResult, @"[,]", "."));
            decimal secondParticipant = Convert.ToDecimal(Regex.Replace(secondParticipantMaskedResult, @"[,]", "."));

            //Assert
            Assert.False(firstParticipantSum == 69078.31M);
            Assert.False(secondParticipant == 30921.69M);
            Assert.False(result > 0);
        }

        [Fact(DisplayName = "Should calculate correctly when the available amount is zero")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldCalculateProfitWhenAvailableAmountIsZero()
        {
            //Arrange
            decimal availableSum = 0M;
            Mock<IEmployeeManagementClient> client = new Mock<IEmployeeManagementClient>();
            client.Setup(c => c.GetAllEmployees()).Returns(Task.FromResult(new List<EmployeeDTO> { new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas", Id = "60a59ee7ab4483dac5fade51" }, new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.CustomerRelations, GrossSalary = 4000.00M, Name = "John Doe", RegistrationNumber = 4515, Role = "Líder de Relacionamento", Id = "60a59ee7ab4483dac5fade51" } }));

            //Act
            ProfitSharingResultDTO profit = await new ProfitSharingService(client.Object).CalculateProfitSharing(availableSum);

            string firstParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[0].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string secondParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[1].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string maskedResult = Regex.Replace(profit.BalanceSum, @"[R$ .]", "");

            decimal result = Convert.ToDecimal(Regex.Replace(maskedResult, @"[,]", "."));
            decimal firstParticipantSum = Convert.ToDecimal(Regex.Replace(firstParticipantMaskedResult, @"[,]", "."));
            decimal secondParticipant = Convert.ToDecimal(Regex.Replace(secondParticipantMaskedResult, @"[,]", "."));

            //Assert
            Assert.True(firstParticipantSum == 0);
            Assert.True(secondParticipant == 0);
            Assert.True(result == 0);
        }

        [Fact(DisplayName = "Should not calculate correctly when the available amount is zero")]
        [Trait("Service", "ProfitSharing")]
        public async void CalculateProfitSharing_ShouldNotCalculateProfitWhenAvailableAmountIsZero()
        {
            //Arrange
            decimal availableSum = 0M;
            Mock<IEmployeeManagementClient> client = new Mock<IEmployeeManagementClient>();
            client.Setup(c => c.GetAllEmployees()).Returns(Task.FromResult(new List<EmployeeDTO> { new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.Accountability, GrossSalary = 5000.00M, Name = "John Doe", RegistrationNumber = 4585, Role = "Diretor de vendas", Id = "60a59ee7ab4483dac5fade51" }, new EmployeeDTO() { AdmissionDate = new DateTime(2021, 05, 16), Area = Domain.Enums.Enum.EmployeeArea.CustomerRelations, GrossSalary = 4000.00M, Name = "John Doe", RegistrationNumber = 4515, Role = "Líder de Relacionamento", Id = "60a59ee7ab4483dac5fade51" } }));

            //Act
            ProfitSharingResultDTO profit = await new ProfitSharingService(client.Object).CalculateProfitSharing(availableSum);

            string firstParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[0].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string secondParticipantMaskedResult = Regex.Replace(profit.ProfitSharingParticipantList[1].ResultingIndividualProfitSharingSum, @"[R$ .]", "");
            string maskedResult = Regex.Replace(profit.BalanceSum, @"[R$ .]", "");

            decimal result = Convert.ToDecimal(Regex.Replace(maskedResult, @"[,]", "."));
            decimal firstParticipantSum = Convert.ToDecimal(Regex.Replace(firstParticipantMaskedResult, @"[,]", "."));
            decimal secondParticipant = Convert.ToDecimal(Regex.Replace(secondParticipantMaskedResult, @"[,]", "."));

            //Assert
            Assert.False(firstParticipantSum != 0);
            Assert.False(secondParticipant != 0);
            Assert.False(result != 0);
        }
    }
}
