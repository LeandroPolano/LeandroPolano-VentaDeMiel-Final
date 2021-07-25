using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioProducto
    {
        private readonly SqlConnection conexion;
        private RepositorioMarca repositorioMarca;
        private RepositorioTipoProducto repositorioTipoProducto;
        private readonly SqlTransaction _tran;

        public RepositorioProducto(SqlConnection connection, RepositorioMarca repositorioMarca, RepositorioTipoProducto repositorioTipoProducto)
        {
            conexion = connection;
            this.repositorioMarca = repositorioMarca;
            this.repositorioTipoProducto = repositorioTipoProducto;
        }

        public RepositorioProducto(SqlConnection connection)
        {
            conexion = connection;
        }

        public Producto GetProductoPorId(decimal id)
        {
            Producto p = null;
            try
            {
                string cadenaComando =
                    "SELECT ProductoID,Producto,TipoProductoID,MarcaID,Stock FROM Productos WHERE ProductoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirProducto(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Producto> GetLista()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                string cadenaComando =
                    "SELECT ProductoID,Producto,TipoProductoID,MarcaID,Stock FROM Productos ";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto producto = ConstruirProducto(reader);
                    lista.Add(producto);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Producto ConstruirProducto(SqlDataReader reader)
        {
            Producto producto = new Producto();
            producto.ProductoID = reader.GetDecimal(0);
            producto.producto = reader.GetString(1);
            repositorioTipoProducto = new RepositorioTipoProducto(conexion);
            producto.TipoProducto = repositorioTipoProducto.GetTipoProductoPorId(reader.GetDecimal(2));
            repositorioMarca = new RepositorioMarca(conexion);
            producto.Marca = repositorioMarca.GetMarcaPorId(reader.GetDecimal(3));
            producto.Stock = reader.GetDecimal(4);



            return producto;

        }
        public void Guardar(Producto producto)
        {
            if (producto.ProductoID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Productos (Producto, TipoProductoID, MarcaID, Stock)" +
                        " VALUES (@producto, @tipo ,@marca, @stock)";
                    var comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@producto", producto.producto);
                    comando.Parameters.AddWithValue("@tipo", producto.TipoProducto.TipoProductoID);
                    comando.Parameters.AddWithValue("@marca", producto.Marca.MarcaID);
                    comando.Parameters.AddWithValue("@stock", producto.Stock);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    producto.ProductoID = id;




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
                    string cadenaComando = "UPDATE Productos SET Producto=@nombre,TipoProductoID=@tipo, MarcaID=@marca, Stock=@stock " +
                        " WHERE ProductoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", producto.producto);
                    comando.Parameters.AddWithValue("@tipo", producto.TipoProducto.TipoProductoID);
                    comando.Parameters.AddWithValue("@marca", producto.Marca.MarcaID);
                    comando.Parameters.AddWithValue("@stock", producto.Stock);

                    comando.Parameters.AddWithValue("@id", producto.ProductoID);
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
                string cadenaComando = "DELETE FROM Productos WHERE ProductoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Producto producto)
        {
            try
            {
                SqlCommand comando;
                if (producto.ProductoID == 0)
                {
                    string cadenaComando = "SELECT ProductoID, Producto FROM Productos WHERE  Producto=@nombre";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", producto.producto);

                }
                else
                {
                    string cadenaComando = "SELECT ProductoID, Producto FROM Productos WHERE  Producto=@nombre AND ProductoID<>@id";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", producto.producto);
                    comando.Parameters.AddWithValue("@id", producto.ProductoID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Producto producto)
        {
            try
            {
                SqlCommand comando;
                var cadenaDeComando = "SELECT ProductoID FROM VentasProductos WHERE ProductoID=@Id";
                comando = new SqlCommand(cadenaDeComando, conexion);
                comando.Parameters.AddWithValue("@id", producto.ProductoID);
                var reader = comando.ExecuteReader();
                if (!reader.HasRows)
                {

                    cadenaDeComando = "SELECT ProductoID FROM ProductosDeProveedores WHERE ProductoID=@Id";
                    comando = new SqlCommand(cadenaDeComando, conexion);
                    comando.Parameters.AddWithValue("@id", producto.ProductoID);
                    reader = comando.ExecuteReader();
                }
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }



    }
}
