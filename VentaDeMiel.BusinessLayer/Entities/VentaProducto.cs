using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class VentaProducto
    {
        public Venta Venta { get; set; }
        //public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public TipoEnvase TipoEnvase { get; set; }
        public decimal Precio { get; set; }

    }
}
