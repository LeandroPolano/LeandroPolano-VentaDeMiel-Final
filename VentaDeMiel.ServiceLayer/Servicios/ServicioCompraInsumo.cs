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
    public class ServicioCompraInsumo
    {
        private RepositorioInsumo _repositorioInsumo;
        private RepositorioCompra repositorioCompra;
        private RepositorioCompraInsumo _repositorioCompraInsumo;

        private ConexionBD _conexion;
        public Insumo GetInsumoPorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion());
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());
            var p = _repositorioInsumo.GetInsumoPorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<Insumo> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion());
            _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());

            var lista = _repositorioInsumo.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        //public void Guardar(Insumo insumo)
        //{
        //    _conexion = new ConexionBD();
        //    _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());
        //    _repositorioInsumo.Guardar(insumo);
        //    _conexion.CerrarConexion();
        //}

        public void Borrar(CompraInsumo compraInsumo)
        {
            _conexion = new ConexionBD();
            _repositorioCompraInsumo = new RepositorioCompraInsumo(_conexion.AbrirConexion());
            _repositorioCompraInsumo.Borrar(compraInsumo);
            _conexion.CerrarConexion();
        }

        //public bool Existe(Insumo insumo)
        //{
        //    try
        //    {
        //        _conexion = new ConexionBD();
        //        repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion());
        //        repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion());
        //        _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());

        //        var existe = _repositorioInsumo.Existe(insumo);
        //        _conexion.CerrarConexion();
        //        return existe;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public bool EstaRelacionado(CompraInsumo compraInsumo)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCompra = new RepositorioCompra(_conexion.AbrirConexion());
                _repositorioInsumo = new RepositorioInsumo(_conexion.AbrirConexion());

                var relacionado = _repositorioCompraInsumo.EstaRelacionado(compraInsumo);
                _conexion.CerrarConexion();
                return relacionado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
