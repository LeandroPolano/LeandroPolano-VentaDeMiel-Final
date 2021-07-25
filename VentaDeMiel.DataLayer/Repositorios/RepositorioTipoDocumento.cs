using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
   public class RepositorioTipoDocumento
   {
        private readonly SqlConnection _sqlConnection;

        public RepositorioTipoDocumento(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public TipoDocumento GetTipoDocumentoPorId(decimal id)
        {
            try
            {
                TipoDocumento tipoDocumento = null;
                string cadenaComando = "SELECT TipoDocumentoID, TipoDocumento FROM TiposDocumentos WHERE TipoDocumentoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoDocumento = ConstruirTipoDocumento(reader);
                    reader.Close();
                }

                return tipoDocumento;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDocumento> GetLista()
        {
            List<TipoDocumento> lista = new List<TipoDocumento>();
            try
            {
                string cadenaComando = "SELECT TipoDocumentoID, TipoDocumento FROM TiposDocumentos";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoDocumento tipoDocumento = ConstruirTipoDocumento(reader);
                    lista.Add(tipoDocumento);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private TipoDocumento ConstruirTipoDocumento(SqlDataReader reader)
        {

            var tipoDocumento = new TipoDocumento();
            tipoDocumento.TipoDocumentoID = reader.GetDecimal(0);
            tipoDocumento.tipoDocumento = reader.GetString(1);
            return tipoDocumento;

        }

        public void Guardar(TipoDocumento tipoDocumento)
        {
            if (tipoDocumento.TipoDocumentoID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO TiposDocumentos VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDocumento.tipoDocumento);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    tipoDocumento.TipoDocumentoID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE TiposDocumentos SET TipoDocumento=@nombre WHERE TipoDocumentoID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDocumento.tipoDocumento);
                    comando.Parameters.AddWithValue("@id", tipoDocumento.TipoDocumentoID);
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
                string cadenaComando = "DELETE FROM TiposDocumentos WHERE TipoDocumentoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDocumento tipoDocumento)
        {
            try
            {
                SqlCommand comando;
                if (tipoDocumento.TipoDocumentoID == 0)
                {
                    string cadenaComando = "SELECT TipoDocumentoID, TipoDocumento FROM TiposDocumentos WHERE TipoDocumento=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDocumento.tipoDocumento);

                }
                else
                {
                    string cadenaComando = "SELECT TipoDocumentoID, TipoDocumento FROM TiposDocumentos WHERE TipoDocumento=@nombre AND TipoDocumentoID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoDocumento.tipoDocumento);
                    comando.Parameters.AddWithValue("@id", tipoDocumento.TipoDocumentoID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoDocumento tipoDocumento)
        {
            try
            {
                var CadenaDeComando = "select TipoDocumentoID from Productos where TipoDocumentoID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", tipoDocumento.TipoDocumentoID);
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
