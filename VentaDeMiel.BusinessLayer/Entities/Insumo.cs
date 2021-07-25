using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
   public class Insumo
    {
        public decimal InsumoID { get; set; }
        public Proveedor Proveedor { get; set; }
        public string insumo { get; set; }
        public decimal Cantidad { get; set; }

    }
}
