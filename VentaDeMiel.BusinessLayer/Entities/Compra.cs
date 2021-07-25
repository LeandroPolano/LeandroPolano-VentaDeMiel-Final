using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
   public class Compra
    {
        public int CompraID { get; set; }
        public Proveedor Proveedor { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public List<CompraInsumo> CompraInsumos { get; set; }
    }
}
