using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioMarca
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioMarca(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Marca GetMarcaPorId(decimal id)
        {
            try
            {
                Marca marca = null;
                string cadenaComando = "SELECT MarcaID, Marca FROM Marcas WHERE MarcaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    marca = ConstruirMarca(reader);
                    reader.Close();
                }

                return marca;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Marca> GetLista()
        {
            List<Marca> lista = new List<Marca>();
            try
            {
                string cadenaComando = "SELECT MarcaID, Marca FROM Marcas";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Marca marca = ConstruirMarca(reader);
                    lista.Add(marca);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Marca ConstruirMarca(SqlDataReader reader)
        {

            var marca = new Marca();
            marca.MarcaID = reader.GetDecimal(0);
            marca.marca = reader.GetString(1);
            return marca;

        }

        public void Guardar(Marca marca)
        {
            if (marca.MarcaID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Marcas VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.marca);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    marca.MarcaID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Marcas SET Marca=@nombre WHERE MarcaID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.marca);
                    comando.Parameters.AddWithValue("@id", marca.MarcaID);
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
                string cadenaComando = "DELETE FROM Marcas WHERE MarcaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

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
                SqlCommand comando;
                if (marca.MarcaID == 0)
                {
                    string cadenaComando = "SELECT MarcaID, Marca FROM Marcas WHERE Marca=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.marca);

                }
                else
                {
                    string cadenaComando = "SELECT MarcaID, Marca FROM Marcas WHERE Marca=@nombre AND MarcaID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", marca.marca);
                    comando.Parameters.AddWithValue("@id", marca.MarcaID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
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
                var CadenaDeComando = "select MarcaID from Productos where MarcaID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", marca.MarcaID);
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
