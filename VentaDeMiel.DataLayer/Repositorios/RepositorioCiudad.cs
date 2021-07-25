using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioCiudad
    {
        private readonly SqlConnection _connection;
        private  RepositorioProvincia _repositorioProvincia;
        private readonly SqlTransaction _tran;
        private readonly Provincia provincia;

        public RepositorioCiudad(SqlConnection connection, RepositorioProvincia repositorioProvincia)
        {
            _connection = connection;
            _repositorioProvincia = repositorioProvincia;

        }

        public RepositorioCiudad(SqlConnection connection)
        {
            _connection = connection;
        }

        public RepositorioCiudad(SqlConnection cn, SqlTransaction tran)
        {
            _connection = cn;
            _tran = tran;
        }

        public Ciudad GetCiudadPorId(decimal id)
        {
            Ciudad p = null;
            try
            {
                string cadenaComando =
                    "SELECT CiudadId, Ciudad, ProvinciaId FROM Ciudades WHERE CiudadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirCiudad(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Ciudad> GetLista()
        {
            List<Ciudad> lista = new List<Ciudad>();
            try
            {
                string cadenaComando =
                    "SELECT CiudadId, Ciudad, ProvinciaId " +
                    " FROM Ciudades";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Ciudad ciudad = ConstruirCiudad(reader);
                    lista.Add(ciudad);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        

        private Ciudad ConstruirCiudad(SqlDataReader reader)
        {
            Ciudad ciudad = new Ciudad();
            ciudad.CiudadID = reader.GetDecimal(0);
            ciudad.ciudad = reader.GetString(1);
            _repositorioProvincia = new RepositorioProvincia(_connection);
            ciudad.Provincia = _repositorioProvincia.GetProvinciaPorId(reader.GetDecimal(2));

            return ciudad;

        }
        public void Guardar(Ciudad ciudad)
        {
            if (ciudad.CiudadID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Ciudades (Ciudad, ProvinciaId ) VALUES (@desc, @provincia)";
                    var comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@desc", ciudad.ciudad);
                    comando.Parameters.AddWithValue("@provincia", ciudad.Provincia.ProvinciaID);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    ciudad.CiudadID = id;




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
                    string cadenaComando = "UPDATE Ciudades SET Ciudad=@nombre,ProvinciaId=@provinciaId WHERE CiudadId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", ciudad.ciudad);
                    comando.Parameters.AddWithValue("@provinciaId", ciudad.Provincia.ProvinciaID);
                    comando.Parameters.AddWithValue("@id", ciudad.CiudadID);
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
                string cadenaComando = "DELETE FROM Ciudades WHERE CiudadID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                SqlCommand comando;
                if (ciudad.CiudadID == 0)
                {
                    string cadenaComando = "SELECT CiudadID, Ciudad,ProvinciaID FROM Ciudades WHERE ProvinciaID=@provincia AND Ciudad=@nombre";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", ciudad.ciudad);
                    comando.Parameters.AddWithValue("@provincia", ciudad.Provincia.ProvinciaID);

                }
                else
                {
                    string cadenaComando = "SELECT CiudadID, Ciudad,ProvinciaID FROM Ciudades WHERE ProvinciaID=@provincia AND Ciudad=@nombre AND CiudadID<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", ciudad.ciudad);
                    comando.Parameters.AddWithValue("@id", ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@provincia", ciudad.Provincia.ProvinciaID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Ciudad ciudad)
        {
            try
            {
                SqlCommand comando;
                var cadenaDeComando = "SELECT CiudadID FROM Colmenares WHERE CiudadID=@Id";
                comando = new SqlCommand(cadenaDeComando, _connection);
                comando.Parameters.AddWithValue("@id", ciudad.CiudadID);
                var reader = comando.ExecuteReader();
                if (!reader.HasRows)
                {
                    
                    cadenaDeComando = "SELECT CiudadID FROM ClientesDeMiel WHERE CiudadID=@Id";
                    comando = new SqlCommand(cadenaDeComando, _connection);
                    comando.Parameters.AddWithValue("@id", ciudad.CiudadID);
                    reader = comando.ExecuteReader();
                    if (!reader.HasRows)
                    {

                        cadenaDeComando = "SELECT CiudadID FROM Proveedores WHERE CiudadID=@Id";
                        comando = new SqlCommand(cadenaDeComando, _connection);
                        comando.Parameters.AddWithValue("@id", ciudad.CiudadID);
                        reader = comando.ExecuteReader();
                    }

                }


                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void ActualizarStock(Ciudad ciudad, decimal cantidad)
        {
            try
            {
                string cadenaComando = "UPDATE Ciudades SET Stock=Stock+@cant WHERE CiudadId=@id";
                var comando = new SqlCommand(cadenaComando, _connection, _tran);
                comando.Parameters.AddWithValue("@cant", cantidad);
                comando.Parameters.AddWithValue("@id", ciudad.CiudadID);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al actualizar el stock de un ciudad");
            }
        }
        


        public List<Ciudad> GetLista(int provinciaId)
        {
            List<Ciudad> lista = new List<Ciudad>();
            try
            {
                string cadenaComando =
                    "SELECT CiudadId, Ciudad, ProvinciaId " +
                    " FROM Ciudades WHERE ProvinciaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", provinciaId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Ciudad ciudad = ConstruirCiudad(reader);
                    lista.Add(ciudad);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Ciudad> GetLista(string ciudad)
        {
            List<Ciudad> lista = new List<Ciudad>();
            try
            {
                string cadenaComando =
                    "SELECT CiudadId, Ciudad, ProvinciaId " +
                    " FROM Ciudades WHERE Ciudad LIKE @desc";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@desc", $"%{ciudad}%");
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Ciudad ciudads = ConstruirCiudad(reader);
                    lista.Add(ciudads);
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
