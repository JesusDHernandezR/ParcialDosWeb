using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidad;

namespace Datos
{
    public class AfiliadoRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Afiliado> _afiliados = new List<Afiliado>();
        public AfiliadoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Afiliado afiliado){
            using (var command=_connection.CreateCommand())
            {
                 command.CommandText="INSERT INTO TblaAfiliado (TipoId,Id,Nombre,FechaNacimiento,FechaAfiliacion,Estado)VALUES(@TipoId,@Id,@Nombre,@FechaNacimiento,@FechaAfiliacion,@Estado)";
                 command.Parameters.AddWithValue("@TipoId", afiliado.TipoId);
                 command.Parameters.AddWithValue("@Id", afiliado.Id);
                 command.Parameters.AddWithValue("@Nombre", afiliado.Nombre);
                 command.Parameters.AddWithValue("@FechaNacimiento", afiliado.FechaNacimiento);
                 command.Parameters.AddWithValue("@FechaAfiliacion", afiliado.FechaAfiliacion);
                 command.Parameters.AddWithValue("@Estado", afiliado.Estado);
                 command.ExecuteNonQuery();
            }
        }
    }
}
