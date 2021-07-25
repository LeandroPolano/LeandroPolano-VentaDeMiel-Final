using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioTipoEnvase
    {
        private readonly SqlConnection conexion;
        private RepositorioCapacidad repositorioCapacidad;
        private readonly SqlTransaction _tran;

        public RepositorioTipoEnvase(SqlConnection connection, RepositorioCapacidad repositorioCapacidad)
        {
            conexion = connection;
            this.repositorioCapacidad = repositorioCapacidad;
        }

        public RepositorioTipoEnvase(SqlConnection connection)
        {
            conexion = connection;
        }

        public TipoEnvase GetTipoEnvasePorId(decimal id)
        {
            TipoEnvase p = null;
            try
            {
                string cadenaComando =
                    "SELECT TipoEnvaseID,TipoEnvase,CapacidadID FROM TiposEnvases WHERE TipoEnvaseID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirTipoEnvase(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<TipoEnvase> GetLista()
        {
            List<TipoEnvase> lista = new List<TipoEnvase>();
            try
            {
                string cadenaComando =
                    "SELECT TipoEnvaseID,TipoEnvase,CapacidadID FROM TiposEnvases ";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoEnvase tipoEnvase = ConstruirTipoEnvase(reader);
                    lista.Add(tipoEnvase);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private TipoEnvase ConstruirTipoEnvase(SqlDataReader reader)
        {
            TipoEnvase tipoEnvase = new TipoEnvase();
            tipoEnvase.TipoEnvaseID = reader.GetDecimal(0);
            tipoEnvase.tipoEnvase = reader.GetString(1);
            tipoEnvase.Capacidad = repositorioCapacidad.GetCapacidadPorId(reader.GetDecimal(2));



            return tipoEnvase;

        }
        public void Guardar(TipoEnvase tipoEnvase)
        {
            if (tipoEnvase.TipoEnvaseID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO TiposEnvases (TipoEnvase, CapacidadID)" +
                        " VALUES (@tipoEnvase, @capacidad )";
                    var comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@tipoEnvase", tipoEnvase.tipoEnvase);
                    comando.Parameters.AddWithValue("@capacidad", tipoEnvase.Capacidad.CapacidadID);
               

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    tipoEnvase.TipoEnvaseID = id;


                    

                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
            else
            {
                try
                {
                    string cadenaComando = "UPDATE TiposEnvases SET TipoEnvase=@nombre,CapacidadID=@capacidad WHERE TipoEnvaseId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", tipoEnvase.tipoEnvase);
                    comando.Parameters.AddWithValue("@capacidad", tipoEnvase.Capacidad.CapacidadID);

                    comando.Parameters.AddWithValue("@id", tipoEnvase.TipoEnvaseID);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }


            }
        }

        public void Borrar(decimal id)
        {
            try
            {
                string cadenaComando = "DELETE FROM TiposEnvases WHERE TipoEnvaseID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoEnvase tipoEnvase)
        {
            try
            {
                SqlCommand comando;
                if (tipoEnvase.TipoEnvaseID == 0)
                {
                    string cadenaComando = "SELECT TipoEnvaseID, TipoEnvase FROM TiposEnvases WHERE  TipoEnvase=@nombre";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", tipoEnvase.tipoEnvase);

                }
                else
                {
                    string cadenaComando = "SELECT TipoEnvaseID, TipoEnvase FROM TiposEnvases WHERE  TipoEnvase=@nombre AND TipoEnvaseID<>@id";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", tipoEnvase.tipoEnvase);
                    comando.Parameters.AddWithValue("@id", tipoEnvase.TipoEnvaseID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoEnvase tipoEnvase)
        {
            return false;
        }
    }
}
