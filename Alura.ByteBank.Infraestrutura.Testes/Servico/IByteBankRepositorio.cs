using Alura.ByteBank.Dominio.Entidades;
using System.Collections.Generic;

namespace Alura.ByteBank.Infraestrutura.Testes.Servico
{
    public interface IByteBankRepositorio
    {
        List<Agencia> BuscarAgencias();
        List<Cliente> BuscarClientes();
        List<ContaCorrente> BuscarContasCorrentes();
    }
}