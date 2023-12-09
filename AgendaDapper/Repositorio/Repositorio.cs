using AgendaDapper.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AgendaDapper.Repositorio
{
    public class Repositorio : IRepositorio
    {
        /* CLASE _CONNECTION */
        private readonly IDbConnection _db;

        /* SE UTILIZA COMO INYECCION DE DEPENDENCIAS */
        public Repositorio(IConfiguration configuracion)
        {
            _db = new SqlConnection(configuracion.GetConnectionString("ConexionLocalDB"));
        }



        public Repositorio() { }

        public Cliente ActualizarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Cliente AgregarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void DeleteClient(int id)
        {
            /* query Dapper */
            var sql = "DELETE FROM CLIENTE WHERE IdCliente=@IdCliente";
            _db.Execute(sql, new { @IdCliente = id });

        }

        public Cliente GetClient(int id)
        {
            /* query Dapper */
            var sql = "SELECT * FROM CLIENTES WHERE IdCliente=@IdCliente";
            return _db.Query<Cliente>(sql, new { @IdCliente = id }).Single();
        }

        public List<Cliente> GetClientes()
        {
            /* query Dapper */
            var sql = "SELECT * FROM CLIENTES";
            return _db.Query<Cliente>(sql).ToList();

        }
    }
}
