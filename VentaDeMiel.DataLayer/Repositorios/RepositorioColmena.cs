using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioColmena
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioColmena(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Colmena GetColmenaPorId(decimal id)
        {
            try
            {
                Colmena ClaveColmena = null;
                string cadenaComando = "SELECT ColmenaID, ClaveColmena FROM Colmenas WHERE ColmenaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ClaveColmena = ConstruirColmena(reader);
                    reader.Close();
                }

                return ClaveColmena;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Colmena> GetLista()
        {
            List<Colmena> lista = new List<Colmena>();
            try
            {
                string cadenaComando = "SELECT ColmenaID, ClaveColmena FROM Colmenas";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Colmena ClaveColmena = ConstruirColmena(reader);
                    lista.Add(ClaveColmena);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Colmena ConstruirColmena(SqlDataReader reader)
        {

            var ClaveColmena = new Colmena();
            ClaveColmena.ColmenaID = reader.GetDecimal(0);
            ClaveColmena.ClaveColmena = reader.GetString(1);
            return ClaveColmena;

        }

        public void Guardar(Colmena ClaveColmena)
        {
            if (ClaveColmena.ColmenaID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Colmenas VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", ClaveColmena.ClaveColmena);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    ClaveColmena.ColmenaID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Colmenas SET ClaveColmena=@nombre WHERE ColmenaID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", ClaveColmena.ClaveColmena);
                    comando.Parameters.AddWithValue("@id", ClaveColmena.ColmenaID);
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
                string cadenaComando = "DELETE FROM Colmenas WHERE ColmenaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Colmena ClaveColmena)
        {
            try
            {
                SqlCommand comando;
                if (ClaveColmena.ColmenaID == 0)
                {
                    string cadenaComando = "SELECT ColmenaID, ClaveColmena FROM Colmenas WHERE ClaveColmena=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", ClaveColmena.ClaveColmena);

                }
                else
                {
                    string cadenaComando = "SELECT ColmenaID, ClaveColmena FROM Colmenas WHERE ClaveColmena=@nombre AND ColmenaID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", ClaveColmena.ClaveColmena);
                    comando.Parameters.AddWithValue("@id", ClaveColmena.ColmenaID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Colmena ClaveColmena)
        {
            try
            {
                var CadenaDeComando = "select ColmenaID from ColmenaColmenares where ColmenaID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", ClaveColmena.ColmenaID);
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
