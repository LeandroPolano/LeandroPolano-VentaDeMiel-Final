using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioVentaProducto
    {
        private  SqlConnection conexion;
        private RepositorioVenta repositorioVenta;
        private RepositorioTipoEnvase repositorioTipoEnvase;
        //private RepositorioProducto repositorioProducto;
        private readonly SqlTransaction _tran;

        public RepositorioVentaProducto(SqlConnection connection, RepositorioVenta repositorioVenta, RepositorioTipoEnvase repositorioTipoEnvase)
        {
            conexion = connection;
            this.repositorioVenta = repositorioVenta;
            this.repositorioTipoEnvase = repositorioTipoEnvase;
        }

        public RepositorioVentaProducto(SqlConnection connection)
        {
            conexion = connection;
        }

        public VentaProducto GetProductoPorId(decimal id)
        {
            VentaProducto p = null;
            try
            {
                string cadenaComando =
                    "SELECT VentaID, ProductoID, Cantidad, TipoEnvaseID, Precio FROM VentasProductos WHERE ProductoID=@id";
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



        public List<VentaProducto> GetLista()
        {
            List<VentaProducto> lista = new List<VentaProducto>();
            try
            {
                string cadenaComando =
                    "SELECT VentaID, ProductoID, Cantidad, TipoEnvaseID FROM VentasProductos ";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    VentaProducto producto = ConstruirProducto(reader);
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

        private VentaProducto ConstruirProducto(SqlDataReader reader)
        {
            VentaProducto ventaproducto = new VentaProducto();
            //repositorioProducto = new RepositorioProducto(conexion);
            //ventaproducto.Producto = repositorioProducto.GetProductoPorId(reader.GetDecimal(0));
            repositorioVenta = new RepositorioVenta(conexion);
            ventaproducto.Venta = repositorioVenta.GetVentaPorId(reader.GetDecimal(1));
            repositorioTipoEnvase = new RepositorioTipoEnvase(conexion);
            ventaproducto.TipoEnvase = repositorioTipoEnvase.GetTipoEnvasePorId(reader.GetDecimal(2));
            repositorioVenta = new RepositorioVenta(conexion);
            ventaproducto.Cantidad = reader.GetDecimal(3);
            ventaproducto.Precio = reader.GetDecimal(4);



            return ventaproducto;

        }
        public void Guardar(VentaProducto ventaProducto)
        {
                try
                {
                    string cadenaComando = "INSERT INTO VentasProductos ( VentaID, Cantidad, TipoEnvaseID, Precio)" +
                        " VALUES (@Venta, @Cantidad ,@TipoEnvase, @precio)";
                    var comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@Venta", ventaProducto.Venta.VentaID);
                    //comando.Parameters.AddWithValue("@producto", ventaProducto.Producto.ProductoID);
                    comando.Parameters.AddWithValue("@Cantidad", ventaProducto.Cantidad);
                    comando.Parameters.AddWithValue("@TipoEnvase", ventaProducto.TipoEnvase.TipoEnvaseID);
                    comando.Parameters.AddWithValue("@precio", ventaProducto.Precio);

                    comando.ExecuteNonQuery();


                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }

                //try
                //{
                //    string cadenaComando = "UPDATE VentasProductos SET VentaID=@Venta,ProductoID=@producto,Cantidad=@cantidad, TipoEnvaseID=@tipo, Precio= @precio " +
                //        " WHERE ProductoID=@id AND VentaID=@vID";
                //    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                //    comando.Parameters.AddWithValue("@Venta", ventaProducto.Venta.VentaID);
                //    comando.Parameters.AddWithValue("@producto", ventaProducto.Producto.ProductoID);
                //    comando.Parameters.AddWithValue("@cantidad", ventaProducto.Cantidad);
                //    comando.Parameters.AddWithValue("@tipo", ventaProducto.TipoEnvase.TipoEnvaseID);
                //    comando.Parameters.AddWithValue("@precio", ventaProducto.Precio);

                //    comando.Parameters.AddWithValue("@id", ventaProducto.Producto.ProductoID);
                //    comando.Parameters.AddWithValue("@vID", ventaProducto.Venta.VentaID);
                //    comando.ExecuteNonQuery();

                //}
                //catch (Exception e)
                //{
                //    throw new Exception(e.Message);
                //}


            
        }

        public void Borrar(VentaProducto ventaProducto)
        {
            try
            {
                string cadenaComando = "DELETE FROM VentasProductos WHERE VentaID=@venta";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                //comando.Parameters.AddWithValue("@id", ventaProducto.Producto.ProductoID);
                comando.Parameters.AddWithValue("@venta", ventaProducto.Venta.VentaID);

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(VentaProducto producto)
        {
            //try
            //{
            //    SqlCommand comando;
            //    if (producto.Producto.ProductoID == 0 )
            //    {
            //        string cadenaComando = "SELECT ProductoID, VentaProducto FROM VentasProductos WHERE  VentaProducto=@nombre";
            //        comando = new SqlCommand(cadenaComando, conexion);
            //        comando.Parameters.AddWithValue("@nombre", producto.producto);

            //    }
            //    else
            //    {
            //        string cadenaComando = "SELECT ProductoID, VentaProducto FROM VentasProductos WHERE  VentaProducto=@nombre AND ProductoID<>@id";
            //        comando = new SqlCommand(cadenaComando, conexion);
            //        comando.Parameters.AddWithValue("@nombre", producto.producto);
            //        comando.Parameters.AddWithValue("@id", producto.ProductoID);


            //    }
            //    SqlDataReader reader = comando.ExecuteReader();
            //    return reader.HasRows;
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}
            return false;
        }

        public bool EstaRelacionado(VentaProducto producto)
        {
            return false;
        }


    }
}
