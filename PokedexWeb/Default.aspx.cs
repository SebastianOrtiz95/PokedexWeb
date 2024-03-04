using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PokedexWeb
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            lista = negocio.listarSP();

        }
    }
}