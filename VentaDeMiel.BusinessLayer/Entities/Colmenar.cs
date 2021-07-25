using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class Colmenar
    {
        public decimal ColmenarID { get; set; }
        public Ciudad Ciudad { get; set; }
        public string NombreColmenar { get; set; }
        public decimal CantidadColmena { get; set; }
        public EstadoColmena EstadoColmena { get; set; }
        public Insumo Insumo { get; set; }
        public decimal CantidadInsumo { get; set; }
    }
}
