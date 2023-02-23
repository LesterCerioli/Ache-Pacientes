using AchePacientes.Domain.Pacientes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchePacientes.Domain.Tests.Models
{
    public class CpfTests
    {
        [Fact]
        public void Cpf_WithInvalidNumber_ShouldThrowException()
        {
            var invalidCpf = "123456789-10";

            Assert.Throws<Exception>(() => new Cpf(invalidCpf));
        }

        [Fact]
        public void Cpf_WithValidNumber_ShouldReturnCorrectNumber()
        {
            var validCpf = "083.728.187-40";

            var cpf = new Cpf(validCpf);

            Assert.Equal(validCpf, cpf.CPFNumero);
        }
    }
}
