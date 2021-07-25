using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class Provincia
    {
        public decimal ProvinciaID { get; set; }       
        public Pais Pais { get; set; }
        public string provincia  { get; set; }
    }
}
