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
    public class ServicioMarca
    {
        private ConexionBD _conexion;
        private RepositorioMarca _repositorio;

        public ServicioMarca()
        {

        }
        public Marca GetMarcaPorId(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMarca(_conexion.AbrirConexion());
                var marca = _repositorio.GetMarcaPorId(id);
                _conexion.CerrarConexion();
                return marca;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Marca> GetLista()
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMarca(_conexion.AbrirConexion());
                var lista = _repositorio.GetLista();
                _conexion.CerrarConexion();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Marca marca)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMarca(_conexion.AbrirConexion());
                _repositorio.Guardar(marca);
                _conexion.CerrarConexion();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Borrar(decimal id)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMarca(_conexion.AbrirConexion());
                _repositorio.Borrar(id);
                _conexion.CerrarConexion();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(Marca marca)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMarca(_conexion.AbrirConexion());
                var existe = _repositorio.Existe(marca);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Marca marca)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorio = new RepositorioMarca(_conexion.AbrirConexion());
                var existe = _repositorio.EstaRelacionado(marca);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
