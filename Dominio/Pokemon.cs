using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pokemon
    {
        public int id { get; set; }
        [DisplayName("Número")]
        public int numero { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        public string UrlImagen { get; set; }
        [DisplayName("Tipo")]
        public Elemento tipo { get; set; }
        [DisplayName("Debilidad")]
        public Elemento debilidad { get; set; }
    }
}
