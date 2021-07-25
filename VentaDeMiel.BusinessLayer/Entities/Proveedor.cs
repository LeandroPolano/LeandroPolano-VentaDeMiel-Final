using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaDeMiel.BusinessLayer.Entities
{
    public class Proveedor
    {
        public decimal ProveedorID { get; set; }
        public decimal Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public Ciudad Ciudad { get; set; }
        public decimal CodigoPostal { get; set; }
        public decimal Telefono { get; set; }
        public string Email { get; set; }

    }
}
