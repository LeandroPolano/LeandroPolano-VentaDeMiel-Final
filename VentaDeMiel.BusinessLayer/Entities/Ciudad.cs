using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
   public class Ciudad
    {
        public decimal CiudadID { get; set; }
        public Provincia Provincia { get; set; }
        public string ciudad { get; set; }
    }
}
