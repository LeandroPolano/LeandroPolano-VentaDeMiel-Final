using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class CompraInsumo
    {
        public Compra Compra { get; set; }
        //public Producto Producto { get; set; }
        public decimal Cantidad { get; set; }
        public Insumo Insumo { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
