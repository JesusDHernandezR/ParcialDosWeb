using System;
using Datos;
using Entidad;
namespace Logica
{
    public class AfiliadoService
    {
        private ConnectionManager connection;
        private AfiliadoRepository afiliadoRepository;        
        public AfiliadoService(string connectionString)
        {
            connection = new ConnectionManager(connectionString);
            afiliadoRepository = new AfiliadoRepository(connection);
        }
        public GuardarAfiliadoResponse Guardar(Afiliado afiliado){
            try
            {
                connection.Open();
                afiliadoRepository.Guardar(afiliado);
                return new GuardarAfiliadoResponse(afiliado);
            }
            catch (Exception ev)
            {
                return new GuardarAfiliadoResponse("Error al guardar: "+ev.Message);
            }finally{
                connection.Close();
            }
        }
    }
    public class GuardarAfiliadoResponse{
        public Afiliado Afiliado {get;set;}
        public bool Error {get;set;}
        public string Mensaje {get;set;}
        public GuardarAfiliadoResponse(Afiliado afiliado)
        {
            Afiliado = afiliado;
            Error=false;
        }
        public GuardarAfiliadoResponse(string mensaje){
            Mensaje=mensaje;
            Error=true; 
        }
    }
}
