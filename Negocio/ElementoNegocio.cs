using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ElementoNegocio
    {
       public List<Elemento> listar2()
        {
            List<Elemento> lista = new List<Elemento>();
            AccesoDatos datos  = new AccesoDatos();
            try
            {
                datos.setearConsulta("select id , descripcion from ELEMENTOS");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();
                    aux.id = (int)datos.Lector["id"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        
    }
}
