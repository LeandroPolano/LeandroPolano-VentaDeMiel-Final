using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class Venta
    {
        public decimal VentaID { get; set; }
        public ClienteDeMiel Cliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public List<VentaProducto> VentaProductos { get; set; }
    }
}
