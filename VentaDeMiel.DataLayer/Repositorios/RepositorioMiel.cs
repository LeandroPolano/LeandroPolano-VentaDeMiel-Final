using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioMiel
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioMiel(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Miel GetMielPorId(decimal id)
        {
            try
            {
                Miel miel = null;
                string cadenaComando = "SELECT MielID, Miel FROM Mieles WHERE MielID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    miel = ConstruirMiel(reader);
                    reader.Close();
                }

                return miel;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Miel> GetLista()
        {
            List<Miel> lista = new List<Miel>();
            try
            {
                string cadenaComando = "SELECT MielID, Miel FROM Mieles";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Miel miel = ConstruirMiel(reader);
                    lista.Add(miel);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Miel ConstruirMiel(SqlDataReader reader)
        {

            var miel = new Miel();
            miel.MielID = reader.GetDecimal(0);
            miel.miel = reader.GetDecimal(1);
            return miel;

        }

        public void Guardar(Miel miel)
        {
            if (miel.MielID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Mieles VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", miel.miel);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    miel.MielID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Mieles SET Miel=@nombre WHERE MielID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", miel.miel);
                    comando.Parameters.AddWithValue("@id", miel.MielID);
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
                string cadenaComando = "DELETE FROM Mieles WHERE MielID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Miel miel)
        {
            try
            {
                SqlCommand comando;
                if (miel.MielID == 0)
                {
                    string cadenaComando = "SELECT MielID, Miel FROM Mieles WHERE Miel=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", miel.miel);

                }
                else
                {
                    string cadenaComando = "SELECT MielID, Miel FROM Mieles WHERE Miel=@nombre AND MielID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", miel.miel);
                    comando.Parameters.AddWithValue("@id", miel.MielID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Miel miel)
        {
            try
            {
                var CadenaDeComando = "select MielID from Productos where MielID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", miel.MielID);
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
