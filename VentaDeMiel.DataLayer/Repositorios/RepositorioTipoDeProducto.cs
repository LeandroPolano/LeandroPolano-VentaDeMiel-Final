using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioTipoProducto
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioTipoProducto(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public TipoProducto GetTipoProductoPorId(decimal id)
        {
            try
            {
                TipoProducto tipoProducto = null;
                string cadenaComando = "SELECT TipoProductoID, TipoProducto FROM TiposDeProductos WHERE TipoProductoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    tipoProducto = ConstruirTipoProducto(reader);
                    reader.Close();
                }

                return tipoProducto;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoProducto> GetLista()
        {
            List<TipoProducto> lista = new List<TipoProducto>();
            try
            {
                string cadenaComando = "SELECT TipoProductoID, TipoProducto FROM TiposDeProductos";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoProducto tipoProducto = ConstruirTipoProducto(reader);
                    lista.Add(tipoProducto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private TipoProducto ConstruirTipoProducto(SqlDataReader reader)
        {

            var tipoProducto = new TipoProducto();
            tipoProducto.TipoProductoID = reader.GetDecimal(0);
            tipoProducto.tipoProducto = reader.GetString(1);
            return tipoProducto;

        }

        public void Guardar(TipoProducto tipoProducto)
        {
            if (tipoProducto.TipoProductoID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO TiposDeProductos VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoProducto.tipoProducto);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    tipoProducto.TipoProductoID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE TiposDeProductos SET TipoProducto=@nombre WHERE TipoProductoID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoProducto.tipoProducto);
                    comando.Parameters.AddWithValue("@id", tipoProducto.TipoProductoID);
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
                string cadenaComando = "DELETE FROM TiposDeProductos WHERE TipoProductoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoProducto tipoProducto)
        {
            try
            {
                SqlCommand comando;
                if (tipoProducto.TipoProductoID == 0)
                {
                    string cadenaComando = "SELECT TipoProductoID, TipoProducto FROM TiposDeProductos WHERE TipoProducto=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoProducto.tipoProducto);

                }
                else
                {
                    string cadenaComando = "SELECT TipoProductoID, TipoProducto FROM TiposDeProductos WHERE TipoProducto=@nombre AND TipoProductoID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", tipoProducto.tipoProducto);
                    comando.Parameters.AddWithValue("@id", tipoProducto.TipoProductoID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(TipoProducto tipoProducto)
        {
            try
            {
                var CadenaDeComando = "select TipoProductoID from Productos where TipoProductoID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", tipoProducto.TipoProductoID);
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
