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
    public class ServicioTipoProducto
    {
       
            private ConexionBD _conexion;
            private RepositorioTipoProducto _repositorio;

            public ServicioTipoProducto()
            {

            }
            public TipoProducto GetTipoProductoPorId(decimal id)
            {
                try
                {
                    _conexion = new ConexionBD();
                    _repositorio = new RepositorioTipoProducto(_conexion.AbrirConexion());
                    var tipoProducto = _repositorio.GetTipoProductoPorId(id);
                    _conexion.CerrarConexion();
                    return tipoProducto;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }

            public List<TipoProducto> GetLista()
            {
                try
                {
                    _conexion = new ConexionBD();
                    _repositorio = new RepositorioTipoProducto(_conexion.AbrirConexion());
                    var lista = _repositorio.GetLista();
                    _conexion.CerrarConexion();
                    return lista;
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            public void Guardar(TipoProducto tipoProducto)
            {
                try
                {
                    _conexion = new ConexionBD();
                    _repositorio = new RepositorioTipoProducto(_conexion.AbrirConexion());
                    _repositorio.Guardar(tipoProducto);
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
                    _repositorio = new RepositorioTipoProducto(_conexion.AbrirConexion());
                    _repositorio.Borrar(id);
                    _conexion.CerrarConexion();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            public bool Existe(TipoProducto tipoProducto)
            {
                try
                {
                    _conexion = new ConexionBD();
                    _repositorio = new RepositorioTipoProducto(_conexion.AbrirConexion());
                    var existe = _repositorio.Existe(tipoProducto);
                    _conexion.CerrarConexion();
                    return existe;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            public bool EstaRelacionado(TipoProducto tipoProducto)
            {
                try
                {
                    _conexion = new ConexionBD();
                    _repositorio = new RepositorioTipoProducto(_conexion.AbrirConexion());
                    var existe = _repositorio.EstaRelacionado(tipoProducto);
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
