using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;
using VentaDeMiel.DataLayer.Repositorios;

namespace VentaDeMiel.DataLayer.Repositorios
{
   public class RepositorioCompra
    {
        private SqlConnection _connection;
        private RepositorioProveedor _repositorioProveedor;
        private SqlTransaction _tran;
        private Proveedor proveedor;
        private DateTime fecha;

        public RepositorioCompra(SqlConnection connection, RepositorioProveedor repositorioProveedor)
        {
            _connection = connection;
            _repositorioProveedor = repositorioProveedor; 

        }

        public RepositorioCompra(SqlConnection connection)
        {
            _connection = connection;
        }

        public RepositorioCompra(SqlConnection cn, SqlTransaction tran)
        {
            _connection = cn;
            _tran = tran;
        }
        
        public Compra GetCompraPorId(decimal id)
        {
            Compra p = null;
            try
            {
                string cadenaComando =
                    "SELECT CompraId, ProveedorId, Total, Fecha FROM Compras WHERE CompraId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirCompra(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Compra> GetLista()
        {
            List<Compra> lista = new List<Compra>();
            try
            {
                string cadenaComando =
                    "SELECT CompraId, ProveedorId, Total, Fecha " +
                    " FROM Compras";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Compra insumo = ConstruirCompra(reader);
                    lista.Add(insumo);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }



        private Compra ConstruirCompra(SqlDataReader reader)
        {
            Compra compra = new Compra();
            compra.CompraID = reader.GetInt32(0);
            //fecha = new DateTime();
            _repositorioProveedor = new RepositorioProveedor(_connection);
            compra.Proveedor = _repositorioProveedor.GetProveedorPorId(reader.GetDecimal(1));
            compra.Total = reader.GetDecimal(2);
            compra.Fecha = reader.GetDateTime(3);

            return compra;

        }
        public void Guardar(Compra compra)
        {
            if (compra.CompraID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Compras (ProveedorId, Total, Fecha ) VALUES (@proveedor, @total, @fecha)";
                    var comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@proveedor", compra.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@total", compra.Total);
                    comando.Parameters.AddWithValue("@fecha", compra.Fecha);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    compra.CompraID = id;




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
                    string cadenaComando = "UPDATE Compras SET ProveedorId=@proveedor, Total=@total, Fecha=@fecha WHERE CompraId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@proveedor", compra.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@total", compra.Total);
                    comando.Parameters.AddWithValue("@fecha", compra.Fecha);
                    comando.Parameters.AddWithValue("@id", compra.CompraID);
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
                string cadenaComando = "DELETE FROM Compras WHERE CompraID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Compra insumo)
        {
            try
            {
                SqlCommand comando;
                if (insumo.CompraID == 0)
                {
                    string cadenaComando = "SELECT CompraID,ProveedorID,Total,Fecha FROM Compras WHERE ProveedorID=@proveedor AND Total=@total AND Fecha=@fecha";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@proveedor", insumo.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@total", insumo.Total);
                    comando.Parameters.AddWithValue("@fecha", insumo.Fecha);


                }
                else
                {
                    string cadenaComando = "SELECT CompraID,ProveedorID,Total,Fecha FROM Compras WHERE ProveedorID=@proveedor AND Total=@total AND Fecha=@fecha AND CompraID<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@proveedor", insumo.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@total", insumo.Total);
                    comando.Parameters.AddWithValue("@fecha", insumo.Fecha);
                    comando.Parameters.AddWithValue("@id", insumo.CompraID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Compra insumo)
        {
            try
            {
                SqlCommand comando;
                var cadenaDeComando = "SELECT CompraID FROM ComprasProductos WHERE CompraID=@Id";
                comando = new SqlCommand(cadenaDeComando, _connection);
                comando.Parameters.AddWithValue("@id", insumo.CompraID);
                var reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //public void ActualizarStock(Compra insumo, decimal total)
        //{
        //    try
        //    {
        //        string cadenaComando = "UPDATE Compras SET Total=Total+@cant WHERE CompraId=@id";
        //        var comando = new SqlCommand(cadenaComando, _connection, _tran);
        //        comando.Parameters.AddWithValue("@cant", total);
        //        comando.Parameters.AddWithValue("@id", insumo.CompraID);
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception("Error al actualizar la total de un insumo");
        //    }
        //}



        public List<Compra> GetLista(int proveedorId)
        {
            List<Compra> lista = new List<Compra>();
            try
            {
                string cadenaComando =
                    "SELECT CompraId, ProveedorId, Total, Fecha " +
                    " FROM Compras WHERE ProveedorId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", proveedorId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Compra insumo = ConstruirCompra(reader);
                    lista.Add(insumo);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //public List<Compra> GetLista(string compra)
        //{
        //    List<Compra> lista = new List<Compra>();
        //    try
        //    {
        //        string cadenaComando =
        //            "SELECT CompraId, ProveedorId, Total, Fecha " +
        //            " FROM Compras WHERE Compra LIKE @desc";
        //        SqlCommand comando = new SqlCommand(cadenaComando, _connection);
        //        comando.Parameters.AddWithValue("@desc", $"%{compra}%");
        //        SqlDataReader reader = comando.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Compra compraVT = ConstruirCompra(reader);
        //            lista.Add(compraVT);
        //        }
        //        reader.Close();
        //        return lista;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }
        //}
    }
}
