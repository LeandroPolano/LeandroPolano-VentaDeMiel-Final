using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class TipoEnvase
    {
        public decimal TipoEnvaseID { get; set; }
        public string tipoEnvase { get; set; }
        public Capacidad Capacidad { get; set; }
     
    }
}
