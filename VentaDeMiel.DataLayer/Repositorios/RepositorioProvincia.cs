using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioProvincia
    {
        private readonly SqlConnection conexion;
        private RepositorioPais _repositorioPais;
        private readonly SqlTransaction _tran;

        public RepositorioProvincia(SqlConnection connection, RepositorioPais repositorioPais)
        {
            conexion = connection;
            _repositorioPais = repositorioPais;

        }

        public RepositorioProvincia(SqlConnection connection)
        {
            conexion = connection;
        }

        public RepositorioProvincia(SqlConnection cn, SqlTransaction tran)
        {
            conexion = cn;
            _tran = tran;
        }

        public Provincia GetProvinciaPorId(decimal id)
        {
            Provincia p = null;
            try
            {
                string cadenaComando =
                    "SELECT ProvinciaId, Provincia, PaisId FROM Provincias WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirProvincia(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Provincia> GetLista()
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string cadenaComando =
                    "SELECT ProvinciaId, Provincia, PaisId " +
                    " FROM Provincias";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
      
        private Provincia ConstruirProvincia(SqlDataReader reader)
        {
            Provincia provincia = new Provincia();
            provincia.ProvinciaID = reader.GetDecimal(0);
            provincia.provincia = reader.GetString(1);
            _repositorioPais = new RepositorioPais(conexion);
            provincia.Pais = _repositorioPais.GetPaisPorId(reader.GetDecimal(2));


            return provincia;

        }
        public void Guardar(Provincia provincia)
        {
            if (provincia.ProvinciaID==0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Provincias (Provincia, PaisId ) VALUES (@desc, @pais)";
                    var comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@desc", provincia.provincia);
                    comando.Parameters.AddWithValue("@pais", provincia.Pais.PaisID);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    provincia.ProvinciaID = id;




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
                        string cadenaComando = "UPDATE Provincias SET Provincia=@nombre,PaisId=@paisId WHERE ProvinciaId=@id";
                        SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                        comando.Parameters.AddWithValue("@nombre", provincia.provincia);
                    comando.Parameters.AddWithValue("@paisId",provincia.Pais.PaisID);
                        comando.Parameters.AddWithValue("@id", provincia.ProvinciaID);
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
                string cadenaComando = "DELETE FROM Provincias WHERE ProvinciaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Provincia provincia)
        {
            try
            {
                SqlCommand comando;
                if (provincia.ProvinciaID == 0)
                {
                    string cadenaComando = "SELECT ProvinciaID, Provincia,PaisID FROM Provincias WHERE PaisID=@pais AND Provincia=@nombre";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", provincia.provincia);
                    comando.Parameters.AddWithValue("@pais",provincia.Pais.PaisID);

                }
                else
                {
                    string cadenaComando = "SELECT ProvinciaID, Provincia,PaisID FROM Provincias WHERE PaisID=@pais AND Provincia=@nombre AND ProvinciaID<>@id";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", provincia.provincia);
                    comando.Parameters.AddWithValue("@id", provincia.ProvinciaID);
                    comando.Parameters.AddWithValue("@pais", provincia.Pais.PaisID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Provincia provincia)
        {
            try
            {
                SqlCommand comando;
                var cadenaDeComando = "SELECT ProvinciaID FROM Ciudades WHERE ProvinciaID=@Id";
                comando = new SqlCommand(cadenaDeComando, conexion);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaID);
                var reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void ActualizarStock(Provincia provincia, decimal cantidad)
        {
            try
            {
                string cadenaComando = "UPDATE Provincias SET Stock=Stock+@cant WHERE ProvinciaId=@id";
                var comando = new SqlCommand(cadenaComando, conexion, _tran);
                comando.Parameters.AddWithValue("@cant", cantidad);
                comando.Parameters.AddWithValue("@id", provincia.ProvinciaID);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al actualizar el stock de un provincia");
            }
        }

        

        public List<Provincia> GetLista(int paisId)
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string cadenaComando =
                    "SELECT ProvinciaId, Provincia, PaisId " +
                    " FROM Provincias WHERE PaisId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", paisId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincia = ConstruirProvincia(reader);
                    lista.Add(provincia);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Provincia> GetLista(string provincia)
        {
            List<Provincia> lista = new List<Provincia>();
            try
            {
                string cadenaComando =
                    "SELECT ProvinciaId, Provincia, PaisId " +
                    " FROM Provincias WHERE Provincia LIKE @desc";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@desc", $"%{provincia}%");
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Provincia provincias = ConstruirProvincia(reader);
                    lista.Add(provincias);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
