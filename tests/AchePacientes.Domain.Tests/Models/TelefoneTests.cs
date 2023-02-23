using AchePacientes.Domain.Pacientes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AchePacientes.Domain.Tests.Models
{
    public class TelefoneTests
    {
        [Theory]
        [InlineData("+55 11 98765-4321", true)]
        [InlineData("11 98765-4321", true)]
        [InlineData("55 11 98765-4321", false)]
        [InlineData("+55 11 987654321", false)]
        [InlineData("11 987 65 4321", false)]
        public void IsValidPhone_ShouldReturnExpectedResult(string telephoneNumber, bool expectedResult)
        {
            // Act
            //var result = Telefone.IsValidTelefone(telephoneNumber);

            // Assert
            //Assert.Equal(expectedResult, result);
        }
    }
}
