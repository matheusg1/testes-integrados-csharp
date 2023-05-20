using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Alura.ByteBank.Infraestrutura.Testes.Servico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _repositorio;

        public AgenciaRepositorioTestes()
        {
            var service = new ServiceCollection()
                .AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

            var provedor = service.BuildServiceProvider();

            _repositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            //Act
            var listaAgencias = _repositorio.ObterTodos();

            //Arrange
            Assert.NotEmpty(listaAgencias);
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            //Act
            var agencia = _repositorio.ObterPorId(1);
            
            //Assert
            Assert.NotNull(agencia);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]        
        public void TestaObterVariasAgenciasPorIds(int id)
        {
            //Act
            var agencia = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(agencia);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //Act
            var atualizado = _repositorio.Excluir(3);
            //Assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaExcecaoConsultaAgenciaPorId()
        {
            //Act & Assert
            Assert.Throws<FormatException>(
                () => _repositorio.ObterPorId(33)
            );
        }

        [Fact]
        public void TestaAdiconarAgenciaMock()
        {
            // Arrange
            var agencia = new Agencia()
            {
                Nome = "Agência Amaral",
                Identificador = Guid.NewGuid(),
                Id = 4,
                Endereco = "Rua Arthur Costa",
                Numero = 6497
            };

            var repositorioMock = new ByteBankRepositorio();

            //Act
            var adicionado = repositorioMock.AdicionarAgencia(agencia);

            //Assert
            Assert.True(adicionado);
        }

    }
}
