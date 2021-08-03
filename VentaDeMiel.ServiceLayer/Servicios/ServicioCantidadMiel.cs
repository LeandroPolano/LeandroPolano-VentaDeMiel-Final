using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;
using VentaDeMiel.DataLayer;
using VentaDeMiel.DataLayer.Repositorios;

namespace VentaDeMiel.ServiceLayer.Servicios
{
    public class ServicioCantidadMiel
    {
        private ConexionBD _conexion;
        private RepositorioCantidadMiel _repositorio;

        public ServicioCantidadMiel()
        {

        }
        public CantidadMiel GetCantidadMielPorId(int id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCantidadMiel(_conexion.AbrirConexion());
                var cantidadMiel = _repositorio.GetCantidadMielPorId(id);
                _conexion.CerrarConexion();
                return cantidadMiel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<CantidadMiel> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCantidadMiel(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(decimal cantidadMiel)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioCantidadMiel(_conexion.AbrirConexion());
                _repositorio.Guardar(cantidadMiel);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}
