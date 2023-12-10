using Xunit;
using AchePacientes.Domain.Pacientes.Interfaces;
using Moq;
using AchePacientes.Application.ViewModels.Pacientes;
using AchePacientes.Domain.Pacientes.ValueObjects;
using AchePacientes.Application.Services.Pacientes.Implementations;
using NetDevPack.Mediator;
using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using AchePacientes.Application.Handlers.Paciente;

namespace AchePacientes.Application.Tests.Services
{
    public class PacienteServiceTests
    {
        [Fact]
        public async Task GetCPF_ShouldReturnMappedViewModel()
        {
            var cpfNumero = new Cpf("123.456.789-09");
            var pacienteRepositoryMock = new Mock<IPacienteRepository>();
            var mediatorHandlerMock = new Mock<IMediatorHandler>();
            var mapperMock = new Mock<IMapper>();

            var pacienteService = new PacienteService(
                pacienteRepositoryMock.Object,
                mediatorHandlerMock.Object,
                mapperMock.Object);

            var pacienteEntity = new PacienteEntity(); // Substitua PacienteEntity com o tipo real da sua entidade
            pacienteRepositoryMock.Setup(x => x.GetByCPF(cpfNumero)).ReturnsAsync(pacienteEntity);

            var pacienteViewModel = new PacienteViewModel(); // Substitua PacienteViewModel com o tipo real do seu ViewModel
            mapperMock.Setup(x => x.Map<PacienteViewModel>(pacienteEntity)).Returns(pacienteViewModel);

            // Act
            var resultado = await pacienteService.GetCPF(cpfNumero);

            // Assert
            resultado.Should().BeEquivalentTo(pacienteViewModel);


        }

        
    }
}