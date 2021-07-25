using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioPais
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioPais(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public Pais GetPaisPorId(decimal id)
        {
            try
            {
                Pais pais = null;
                string cadenaComando = "SELECT PaisID, Pais FROM Paises WHERE PaisID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    pais = ConstruirPais(reader);
                    reader.Close();
                }

                return pais;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Pais> GetLista()
        {
            List<Pais> lista = new List<Pais>();
            try
            {
                string cadenaComando = "SELECT PaisID, Pais FROM Paises";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Pais pais = ConstruirPais(reader);
                    lista.Add(pais);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private Pais ConstruirPais(SqlDataReader reader)
        {

            var pais = new Pais();
            pais.PaisID = reader.GetDecimal(0);
            pais.pais = reader.GetString(1);
            return pais;

        }

        public void Guardar(Pais pais)
        {
            if (pais.PaisID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Paises VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", pais.pais);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    pais.PaisID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE Paises SET Pais=@nombre WHERE PaisID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", pais.pais);
                    comando.Parameters.AddWithValue("@id", pais.PaisID);
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
                string cadenaComando = "DELETE FROM Paises WHERE PaisID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Pais pais)
        {
            try
            {
                SqlCommand comando;
                if (pais.PaisID == 0)
                {
                    string cadenaComando = "SELECT PaisID, Pais FROM Paises WHERE Pais=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", pais.pais);

                }
                else
                {
                    string cadenaComando = "SELECT PaisID, Pais FROM Paises WHERE Pais=@nombre AND PaisID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", pais.pais);
                    comando.Parameters.AddWithValue("@id", pais.PaisID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Pais pais)
        {
            try
            {
                var CadenaDeComando = "select PaisID from Provincias where PaisID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", pais.PaisID);
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
