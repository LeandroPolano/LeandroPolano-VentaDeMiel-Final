using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioVenta
    {
        private  SqlConnection _connection;
        private  RepositorioClienteDeMiel _repositorioCliente;
        private  SqlTransaction _tran;
        private  ClienteDeMiel cliente;
        private DateTime fecha;

        public RepositorioVenta(SqlConnection connection, RepositorioClienteDeMiel repositorioCliente)
        {
            _connection = connection;
            _repositorioCliente = repositorioCliente;

        }

        public RepositorioVenta(SqlConnection connection)
        {
            _connection = connection;
        }

        public RepositorioVenta(SqlConnection cn, SqlTransaction tran)
        {
            _connection = cn;
            _tran = tran;
        }

        public Venta GetVentaPorId(decimal id)
        {
            Venta p = null;
            try
            {
                string cadenaComando =
                    "SELECT VentaId, ClienteId, Total, Fecha FROM Ventas WHERE VentaId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirVenta(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Venta> GetLista()
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                string cadenaComando =
                    "SELECT VentaId, ClienteId, Total, Fecha " +
                    " FROM Ventas";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Venta insumo = ConstruirVenta(reader);
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



        private Venta ConstruirVenta(SqlDataReader reader)
        {
            Venta venta = new Venta();
            venta.VentaID = reader.GetDecimal(0);
            //fecha = new DateTime();
            _repositorioCliente = new RepositorioClienteDeMiel(_connection);
            venta.Cliente = _repositorioCliente.GetClienteDeMielPorId(reader.GetDecimal(1));
            venta.Total = reader.GetDecimal(2);
            venta.Fecha = reader.GetDateTime(3);

            return venta;

        }
        public void Guardar(Venta venta)
        {
            if (venta.VentaID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Ventas (ClienteId, Total, Fecha ) VALUES (@cliente, @total, @fecha)";
                    var comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@cliente", venta.Cliente.ClienteID);
                    comando.Parameters.AddWithValue("@total", venta.Total);
                    comando.Parameters.AddWithValue("@fecha", venta.Fecha);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    venta.VentaID = id;




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
                    string cadenaComando = "UPDATE Ventas SET ClienteId=@cliente, Total=@total, Fecha=@fecha WHERE VentaId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@cliente", venta.Cliente.ClienteID);
                    comando.Parameters.AddWithValue("@total", venta.Total);
                    comando.Parameters.AddWithValue("@fecha", venta.Fecha);
                    comando.Parameters.AddWithValue("@id", venta.VentaID);
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
                string cadenaComando = "DELETE FROM Ventas WHERE VentaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Venta insumo)
        {
            try
            {
                SqlCommand comando;
                if (insumo.VentaID == 0)
                {
                    string cadenaComando = "SELECT VentaID,ClienteID,Total,Fecha FROM Ventas WHERE ClienteID=@cliente AND Total=@total AND Fecha=@fecha";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@cliente", insumo.Cliente.ClienteID);
                    comando.Parameters.AddWithValue("@total", insumo.Total);
                    comando.Parameters.AddWithValue("@fecha", insumo.Fecha);


                }
                else
                {
                    string cadenaComando = "SELECT VentaID,ClienteID,Total,Fecha FROM Ventas WHERE ClienteID=@cliente AND Total=@total AND Fecha=@fecha AND VentaID<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@cliente", insumo.Cliente.ClienteID);
                    comando.Parameters.AddWithValue("@total", insumo.Total);
                    comando.Parameters.AddWithValue("@fecha", insumo.Fecha);
                    comando.Parameters.AddWithValue("@id", insumo.VentaID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Venta insumo)
        {
            try
            {
                SqlCommand comando;
                var cadenaDeComando = "SELECT VentaID FROM VentasProductos WHERE VentaID=@Id";
                comando = new SqlCommand(cadenaDeComando, _connection);
                comando.Parameters.AddWithValue("@id", insumo.VentaID);
                var reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //public void ActualizarStock(Venta insumo, decimal total)
        //{
        //    try
        //    {
        //        string cadenaComando = "UPDATE Ventas SET Total=Total+@cant WHERE VentaId=@id";
        //        var comando = new SqlCommand(cadenaComando, _connection, _tran);
        //        comando.Parameters.AddWithValue("@cant", total);
        //        comando.Parameters.AddWithValue("@id", insumo.VentaID);
        //        comando.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception("Error al actualizar la total de un insumo");
        //    }
        //}



        public List<Venta> GetLista(int clienteId)
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                string cadenaComando =
                    "SELECT VentaId, ClienteId, Total, Fecha " +
                    " FROM Ventas WHERE ClienteId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", clienteId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Venta insumo = ConstruirVenta(reader);
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

        public List<Venta> GetLista(string venta)
        {
            List<Venta> lista = new List<Venta>();
            try
            {
                string cadenaComando =
                    "SELECT VentaId, ClienteId, Total, Fecha " +
                    " FROM Ventas WHERE Venta LIKE @desc";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@desc", $"%{venta}%");
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Venta ventaVT = ConstruirVenta(reader);
                    lista.Add(ventaVT);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
