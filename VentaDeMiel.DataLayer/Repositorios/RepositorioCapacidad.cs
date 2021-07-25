using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioCapacidad
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioCapacidad(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Capacidad GetCapacidadPorId(decimal id)
        {
            try
            {
                Capacidad capacidad = null;
                string cadenaComando = "SELECT CapacidadID, Capacidad FROM Capacidades WHERE CapacidadID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    capacidad = ConstruirCapacidad(reader);
                    reader.Close();
                }

                return capacidad;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Capacidad> GetLista()
        {
            List<Capacidad> lista = new List<Capacidad>();
            try
            {
                string cadenaComando = "SELECT CapacidadID, Capacidad FROM Capacidades";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Capacidad capacidad = ConstruirCapacidad(reader);
                    lista.Add(capacidad);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Capacidad ConstruirCapacidad(SqlDataReader reader)
        {

            var capacidad = new Capacidad();
            capacidad.CapacidadID = reader.GetDecimal(0);
            capacidad.capacidad = reader.GetString(1);
            return capacidad;

        }

        public void Guardar(Capacidad capacidad)
        {
            if (capacidad.CapacidadID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Capacidades VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", capacidad.capacidad);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    capacidad.CapacidadID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Capacidades SET Capacidad=@nombre WHERE CapacidadID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", capacidad.capacidad);
                    comando.Parameters.AddWithValue("@id", capacidad.CapacidadID);
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
                string cadenaComando = "DELETE FROM Capacidades WHERE CapacidadID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Capacidad capacidad)
        {
            try
            {
                SqlCommand comando;
                if (capacidad.CapacidadID == 0)
                {
                    string cadenaComando = "SELECT CapacidadID, Capacidad FROM Capacidades WHERE Capacidad=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", capacidad.capacidad);

                }
                else
                {
                    string cadenaComando = "SELECT CapacidadID, Capacidad FROM Capacidades WHERE Capacidad=@nombre AND CapacidadID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", capacidad.capacidad);
                    comando.Parameters.AddWithValue("@id", capacidad.CapacidadID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Capacidad capacidad)
        {
            try
            {
                var CadenaDeComando = "select CapacidadID from TiposDeEnvases where CapacidadID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", capacidad.CapacidadID);
                var reader = Comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
