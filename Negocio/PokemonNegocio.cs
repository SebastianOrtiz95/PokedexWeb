using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
	
    public class PokemonNegocio
    {

		private AccesoDatos datos;
		public PokemonNegocio()
		{
			datos = new AccesoDatos();	
		}
		public List<Pokemon> listarSP()
		{
            List<Pokemon> lista = new List<Pokemon>();
            datos = new AccesoDatos();
            try
            {
				//datos.setearConsulta("select P.id,numero,nombre,P.Descripcion,UrlImagen,E.Descripcion tipo,D.Descripcion debilidad,P.IdTipo,P.IdDebilidad from POKEMONS P,ELEMENTOS D,ELEMENTOS E where P.IdTipo = E.Id and   P.IdDebilidad = D.Id and P.Activo = 1");
				datos.setearSP("storeListar");
                datos.ejecutarConsulta();
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();
                    aux.numero = (int)datos.Lector["numero"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }

                    aux.id = (int)datos.Lector["id"];
                    aux.tipo = new Elemento();
                    aux.tipo.descripcion = (string)datos.Lector["tipo"];
                    aux.tipo.id = (int)datos.Lector["idtipo"];
                    aux.debilidad = new Elemento();
                    aux.debilidad.descripcion = (string)datos.Lector["debilidad"];
                    aux.debilidad.id = (int)datos.Lector["idDebilidad"];

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
        public List<Pokemon> listar()
        {
			List<Pokemon> lista = new List<Pokemon>();
			datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("select P.id,numero,nombre,P.Descripcion,UrlImagen,E.Descripcion tipo,D.Descripcion debilidad,P.IdTipo,P.IdDebilidad from POKEMONS P,ELEMENTOS D,ELEMENTOS E where P.IdTipo = E.Id and   P.IdDebilidad = D.Id and P.Activo = 1");
				datos.ejecutarConsulta();
				while (datos.Lector.Read())
				{
					Pokemon aux = new Pokemon();
					aux.numero = (int)datos.Lector["numero"];
					aux.nombre = (string)datos.Lector["nombre"];
					aux.descripcion = (string)datos.Lector["descripcion"];
					if (!(datos.Lector["UrlImagen"] is DBNull))
					{
					  aux.UrlImagen = (string)datos.Lector["UrlImagen"];
					}

					aux.id = (int)datos.Lector["id"];
					aux.tipo = new Elemento();
					aux.tipo.descripcion = (string)datos.Lector["tipo"];
					aux.tipo.id = (int)datos.Lector["idtipo"];
					aux.debilidad = new Elemento();
					aux.debilidad.descripcion = (string)datos.Lector["debilidad"];
					aux.debilidad.id = (int)datos.Lector["idDebilidad"];

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
		public void agregar(Pokemon nuevo)
		{
			try
			{ 
				datos.setearConsulta("insert into POKEMONS (Numero,Nombre,Descripcion,UrlImagen,IdTipo,IdDebilidad,Activo)values(@Numero,@Nombre,@Descripcion,@UrlImagen,@IdTipo,@IdDebilidad,1)");
				datos.setearParametro("@Numero",nuevo.numero);
				datos.setearParametro("@Nombre",nuevo.nombre);
				datos.setearParametro("@Descripcion",nuevo.descripcion);
				datos.setearParametro("@UrlImagen",nuevo.UrlImagen);
				datos.setearParametro("@IdTipo",nuevo.tipo.id);
				datos.setearParametro("@IdDebilidad",nuevo.debilidad.id);
				datos.ejecutarAccion();
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
        public void agregarConSP(Pokemon nuevo)
        {
            try
            {
                datos.setearSP("storedAltaPokemon");
                datos.setearParametro("@Numero", nuevo.numero);
                datos.setearParametro("@Nombre", nuevo.nombre);
                datos.setearParametro("@Descripcion", nuevo.descripcion);
                datos.setearParametro("@UrlImagen", nuevo.UrlImagen);
                datos.setearParametro("@IdTipo", nuevo.tipo.id);
                datos.setearParametro("@IdDebilidad", nuevo.debilidad.id);
				datos.setearParametro("@IdEvolucion",DBNull.Value);
                datos.ejecutarAccion();
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
        public void Modificar(Pokemon pokemon)
		{
			try
			{
				datos.setearConsulta("update POKEMONS set Numero = @numero , Nombre = @nombre,Descripcion= @descripcion,UrlImagen=@urlImagen,IdTipo=@IdTipo,IdDebilidad=@IdDebilidad where id = @id");
				datos.setearParametro("@numero", pokemon.numero);
				datos.setearParametro("@nombre",pokemon.nombre);
				datos.setearParametro("@descripcion",pokemon.descripcion);
				datos.setearParametro("@urlimagen",pokemon.UrlImagen);
				datos.setearParametro("@IdTipo",pokemon.tipo.id);
				datos.setearParametro("@IdDebilidad",pokemon.debilidad.id);
                datos.setearParametro("@id",pokemon.id);
				datos.ejecutarAccion();
				
			}
			catch (Exception ex)
			{

				throw ex ;
			}
			finally
			{
				datos.cerrarConexion();
			}
		}
		public void ModificarConSP(Pokemon pokemon)
		{
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearSP("storedModificarPokemon");
                datos.setearParametro("@numero", pokemon.numero);
                datos.setearParametro("@nombre", pokemon.nombre);
                datos.setearParametro("@descripcion", pokemon.descripcion);
                datos.setearParametro("@urlimagen", pokemon.UrlImagen);
                datos.setearParametro("@IdTipo", pokemon.tipo.id);
                datos.setearParametro("@IdDebilidad", pokemon.debilidad.id);
                datos.setearParametro("@id", pokemon.id);
				datos.ejecutarAccion();
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
		public void eliminar(Pokemon poke)
		{
			try
			{
				datos.setearConsulta("delete from POKEMONS where id = @id");
				datos.setearParametro("@id",poke.id);
				datos.ejecutarAccion();
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
		public void eliminarLogico(int id)
		{
			try
			{
				datos.setearConsulta("update POKEMONS set Activo = 0 where id = @id");
				datos.setearParametro("@id", id);
				datos.ejecutarAccion();
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
        public Pokemon ObtenerPorId(int id)
        {
            try
            {
                // Obtener la lista completa de pokemons
                List<Pokemon> lista = listar();

                // Buscar el pokemon con el id especificado en la lista
                Pokemon pokemon = lista.Find(p => p.id == id);

                return pokemon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Pokemon> filtrar(string campo, string criterio, string filtro)
		{
			List<Pokemon> lista = new List<Pokemon>();
			
			try
			{
				string consulta = "select P.id,numero,nombre,P.Descripcion,UrlImagen,E.Descripcion tipo, D.Descripcion debilidad, P.IdTipo,P.IdDebilidad from POKEMONS P, ELEMENTOS D,ELEMENTOS E where P.IdTipo = E.Id and P.IdDebilidad = D.Id and P.Activo = 1 and ";

                
				if (campo == "Numero")
				{
					if (criterio == "Mayor a")
					{
						consulta += " numero > " + filtro;
					}
					if (criterio == "Menor a")
					{
						consulta += "numero < " + filtro;
					}
					if (criterio == "Igual a")
					{
						consulta += " numero = " + filtro;
					}
				}
			    if (campo=="Nombre")
				{
                    if (criterio == "Comienza con")
                    {
                        consulta += " nombre like '"  + filtro + "%' ";
                    }
                    if (criterio == "Termina con")
                    {
                        consulta += " nombre like '%" + filtro + "' " ;
                    }
                    if (criterio == "Contiene")
                    {
                        consulta += " nombre like '%" + filtro + "%' ";
                    }
                }
				if (campo == "Descripcion")
				{
                    if (criterio == "Comienza con")
                    {
                        consulta += " P.Descripcion like '" + filtro + "%' ";
                    }
                    if (criterio == "Termina con")
                    {
                        consulta += " P.Descripcion like '%" + filtro + "' ";
                    }
                    if (criterio == "Contiene")
                    {
                        consulta += " P.Descripcion like '%" + filtro + "%' ";
                    }
                }
				datos.setearConsulta(consulta);
				datos.ejecutarConsulta();
				while (datos.Lector.Read())
				{
                    Pokemon aux = new Pokemon();
                    aux.numero = (int)datos.Lector["numero"];
                    aux.nombre = (string)datos.Lector["nombre"];
                    aux.descripcion = (string)datos.Lector["descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                    {
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    }

                    aux.id = (int)datos.Lector["id"];
                    aux.tipo = new Elemento();
                    aux.tipo.descripcion = (string)datos.Lector["tipo"];
                    aux.tipo.id = (int)datos.Lector["idtipo"];
                    aux.debilidad = new Elemento();
                    aux.debilidad.descripcion = (string)datos.Lector["debilidad"];
                    aux.debilidad.id = (int)datos.Lector["idDebilidad"];

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
