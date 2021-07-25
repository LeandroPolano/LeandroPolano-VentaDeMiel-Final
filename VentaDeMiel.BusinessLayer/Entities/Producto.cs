using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class Producto
    {
        public decimal ProductoID { get; set; }
        public string producto { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public Marca Marca { get; set; }
        public decimal Stock { get; set; }

       
    }
}
