using AgendaDapper.Models;

namespace AgendaDapper.Repositorio
{
    public interface IRepositorio
    {
        Cliente GetClient(int id);
        List<Cliente> GetClientes();
        Cliente AgregarCliente(Cliente cliente);
        Cliente ActualizarCliente(Cliente cliente);
        void DeleteClient(int id);

    }
}
