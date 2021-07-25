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
    public class ServicioInsumo
    {
        private RepositorioInsumo _repositorioInsumo;
        private RepositorioProveedor _repositorioProveedor;
        private RepositorioCiudad repositorioCiudad;

        private ConexionBD _conexion;
        public Insumo GetInsumoPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), _repositorioProveedor);
            var p = _repositorioInsumo.GetInsumoPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Insumo> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), _repositorioProveedor);
            var lista = _repositorioInsumo.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(Insumo insumo)
        {
            _conexion = new ConexionBD();
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());
            _repositorioInsumo.Guardar(insumo);
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());
            _repositorioInsumo.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(Insumo insumo)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
                _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);
                _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), _repositorioProveedor);
                var existe = _repositorioInsumo.Existe(insumo);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Insumo insumo)
        {
            try
            {
                _conexion = new ConexionBD();
                _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());

                var relacionado = _repositorioInsumo.EstaRelacionado(insumo);
                _conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        public List<Insumo> GetLista(int proveedorId)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), _repositorioProveedor);
            var lista = _repositorioInsumo.GetLista(proveedorId);
            _conexion.CerrarConexion();
            return lista;

        }

        public List<Insumo> GetLista(string insumo)
        {
            _conexion = new ConexionBD();
            repositorioCiudad = new RepositorioCiudad(_conexion.AbrirConexion());
            _repositorioProveedor = new RepositorioProveedor(_conexion.AbrirConexion(), repositorioCiudad);
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion(), _repositorioProveedor);
            var lista = _repositorioInsumo.GetLista(insumo);
            _conexion.CerrarConexion();
            return lista;
        }
    }
}
