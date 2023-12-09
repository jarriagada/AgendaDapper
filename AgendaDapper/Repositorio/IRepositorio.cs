using AgendaDapper.Models;

namespace AgendaDapper.Repositorio
{
    public interface IRepositorio
    {
        Cliente GetClient(int id);
        List<Cliente> GetClientes();
        Cliente AgregarCliente(Cliente cliente);
        Cliente ActualizarCliente(int id);
        void DeleteClient(int id);

    }
}
