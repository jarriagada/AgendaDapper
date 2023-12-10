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

        public Cliente ActualizarCliente(Cliente cliente)
        {
            var sql = "UPDATE Cliente SET Nombres=@Nombres, Apellidos=@Apellidos, Telefono=@Telefono, Email=@Email, Pais=@Pais "
                + " WHERE IdCliente =@IdCliente";
            _db.Execute(sql, cliente);
            return cliente;
        }

        public Cliente AgregarCliente(Cliente cliente) {
            var sql = "INSERT INTO Cliente(Nombres, Apellidos, Telefono, Email, Pais, FechaCreacion)VALUES(@Nombres, @Apellidos, @Telefono, @Email, @Pais, @FechaCreacion)"
              + " SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = _db.Query<int>(sql, cliente).Single();
            cliente.IdCliente = id;
            return cliente;
        }
        
            //var sql = "INSERT INTO Cliente(Nombres, Apellidos, Telefono, Email, Pais, FechaCreacion)VALUES(@Nombres, @Apellidos, @Telefono, @Email, @Pais, @FechaCreacion)"
            //+ " SELECT CAST(SCOPE_IDENTITY()  as int);";
            //var id = _db.Query<int>(sql, new
            //{
            //    cliente.Nombres,
            //    cliente.Apellidos,
            //    cliente.Telefono,
            //    cliente.Email,
            //    cliente.Pais,
            //    cliente.FechaCreacion
            //}).Single();

            //cliente.IdCliente = id;
            //return cliente;
           
        

        public void BorrarCliente(int id)
        {
            /* query Dapper */
            var sql = "DELETE FROM CLIENTE WHERE IdCliente=@IdCliente";
            _db.Execute(sql, new { @IdCliente = id });

        }

        public Cliente GetCliente(int id)
        {
            /* query Dapper */
            var sql = "SELECT * FROM CLIENTE WHERE IdCliente=@IdCliente";
            return _db.Query<Cliente>(sql, new { @IdCliente = id }).Single();
        }

        public List<Cliente> GetClientes()
        {
            /* query Dapper */
            var sql = "SELECT * FROM CLIENTE";
            return _db.Query<Cliente>(sql).ToList();

        }
    }
}
