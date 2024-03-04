using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace PokedexWeb
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    ddlDebilidad.DataSource = negocio.listar2();
                    ddlDebilidad.DataValueField = "id";
                    ddlDebilidad.DataTextField = "descripcion";
                    ddlDebilidad.DataBind();
                    ddlTipo.DataSource = negocio.listar2();
                    ddlTipo.DataValueField = "id";
                    ddlTipo.DataTextField = "descripcion";
                    ddlTipo.DataBind();
                }

                int id = Request.QueryString["id"]!=null ? int.Parse(Request.QueryString["id"]):0;

                if (id != 0 && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();

                    Pokemon seleccionado = negocio.ObtenerPorId(id);
                    txtDescripcion.Text = seleccionado.descripcion;
                    txtId.Text = seleccionado.id.ToString();
                    txtNombre.Text = seleccionado.nombre;
                    txtNumero.Text = seleccionado.numero.ToString();
                    txtImagenUrl.Text = seleccionado.UrlImagen;
                    ddlDebilidad.SelectedValue = seleccionado.debilidad.id.ToString(); 
                    ddlTipo.SelectedValue = seleccionado.tipo.id.ToString();
                    cargarImagen(seleccionado.UrlImagen);

                }
            }
            catch (Exception ex)
            {
                Session.Add("error",ex);
                throw;
            }
           
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon nuevo = new Pokemon();
            nuevo.id = int.Parse(txtId.Text);
            nuevo.nombre = txtNombre.Text;
            nuevo.descripcion= txtDescripcion.Text;
            nuevo.tipo = new Elemento();
            nuevo.tipo.id = int.Parse(ddlTipo.SelectedValue);
            nuevo.debilidad = new Elemento();
            nuevo.debilidad.id = int.Parse(ddlDebilidad.SelectedValue);
            nuevo.UrlImagen = txtImagenUrl.Text;
            nuevo.numero = int.Parse(txtNumero.Text);

            if (nuevo.id != 0)
            {
                negocio.Modificar(nuevo);
            }
            else
            {
                negocio.agregarConSP(nuevo);
            }
            Response.Redirect("ListaPokemon.aspx",false);
        }
            
        public void cargarImagen(string url)
        {
            if (url!="")
             imgPokemon.ImageUrl = url;
            else
               imgPokemon.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtImagenUrl.Text;
        }
    }
}
            
        
            
            
            
            
           