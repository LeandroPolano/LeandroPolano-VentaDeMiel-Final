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
    public class ServicioTipoEnvase
    {
        private RepositorioTipoEnvase _repositorioTipoEnvase;
        private RepositorioCapacidad repositorioCapacidad;

        private ConexionBD _conexion;
        public TipoEnvase GetTipoEnvasePorId(decimal id)
        {
            _conexion = new ConexionBD();
            repositorioCapacidad = new RepositorioCapacidad(_conexion.AbrirConexion());
            _repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion(), repositorioCapacidad);
            var p = _repositorioTipoEnvase.GetTipoEnvasePorId(id);
            _conexion.CerrarConexion();
            return p;

        }

        public List<TipoEnvase> GetLista()
        {
            _conexion = new ConexionBD();
            repositorioCapacidad = new RepositorioCapacidad(_conexion.AbrirConexion());
            _repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion(), repositorioCapacidad);

            var lista = _repositorioTipoEnvase.GetLista();
            _conexion.CerrarConexion();
            return lista;

        }

        public void Guardar(TipoEnvase tipoEnvase)
        {
            _conexion = new ConexionBD();
            _repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion());
            _repositorioTipoEnvase.Guardar(tipoEnvase);
            _conexion.CerrarConexion();
        }

        public void Borrar(decimal id)
        {
            _conexion = new ConexionBD();
            _repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion());
            _repositorioTipoEnvase.Borrar(id);
            _conexion.CerrarConexion();
        }

        public bool Existe(TipoEnvase tipoEnvase)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCapacidad = new RepositorioCapacidad(_conexion.AbrirConexion());
                _repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion(), repositorioCapacidad);

                var existe = _repositorioTipoEnvase.Existe(tipoEnvase);
                _conexion.CerrarConexion();
                return existe;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoEnvase tipoEnvase)
        {
            try
            {
                _conexion = new ConexionBD();
                repositorioCapacidad = new RepositorioCapacidad(_conexion.AbrirConexion());
                _repositorioTipoEnvase = new RepositorioTipoEnvase(_conexion.AbrirConexion(), repositorioCapacidad);

                var relacionado = _repositorioTipoEnvase.EstaRelacionado(tipoEnvase);
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
