using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioInsumo
    {
        private readonly SqlConnection _connection;
        private  RepositorioProveedor _repositorioProveedor;
        private readonly SqlTransaction _tran;
        private readonly Proveedor proveedor;

        public RepositorioInsumo(SqlConnection connection, RepositorioProveedor repositorioProveedor)
        {
            _connection = connection;
            _repositorioProveedor = repositorioProveedor;

        }

        public RepositorioInsumo(SqlConnection connection)
        {
            _connection = connection;
        }

        public RepositorioInsumo(SqlConnection cn, SqlTransaction tran)
        {
            _connection = cn;
            _tran = tran;
        }

        public Insumo GetInsumoPorId(decimal id)
        {
            Insumo p = null;
            try
            {
                string cadenaComando =
                    "SELECT InsumoId, Insumo, ProveedorId, Cantidad FROM Insumos WHERE InsumoId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirInsumo(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Insumo> GetLista()
        {
            List<Insumo> lista = new List<Insumo>();
            try
            {
                string cadenaComando =
                    "SELECT InsumoId, Insumo, ProveedorId, Cantidad " +
                    " FROM Insumos";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Insumo insumo = ConstruirInsumo(reader);
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



        private Insumo ConstruirInsumo(SqlDataReader reader)
        {
            Insumo insumo = new Insumo();
            insumo.InsumoID = reader.GetDecimal(0);
            insumo.insumo = reader.GetString(1);
            _repositorioProveedor = new RepositorioProveedor(_connection);
            insumo.Proveedor = _repositorioProveedor.GetProveedorPorId(reader.GetDecimal(2));
            insumo.Cantidad = reader.GetDecimal(3);

            return insumo;

        }

        public void EditarInsumo(Colmenar colmenar)
        {
            try
            {
                var cadenaDeComando = "UPDATE Insumos SET Cantidad-=@cant WHERE InsumoId=@id";
                var comando = new SqlCommand(cadenaDeComando, _connection, _tran);
                comando.Parameters.AddWithValue("@id",colmenar.Insumo.InsumoID);
                comando.Parameters.AddWithValue("@cant",colmenar.CantidadInsumo);
                comando.ExecuteNonQuery();
                colmenar.Insumo.Cantidad -= Convert.ToDecimal(colmenar.CantidadInsumo);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Insumo insumo)
        {
            if (insumo.InsumoID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Insumos (Insumo, ProveedorId, Cantidad ) VALUES (@desc, @proveedor, @cant)";
                    var comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@desc", insumo.insumo);
                    comando.Parameters.AddWithValue("@proveedor", insumo.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@cant", insumo.Cantidad);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    insumo.InsumoID = id;




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
                    string cadenaComando = "UPDATE Insumos SET Insumo=@nombre,ProveedorId=@proveedorId, Cantidad=@cant WHERE InsumoId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", insumo.insumo);
                    comando.Parameters.AddWithValue("@proveedorId", insumo.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@cant", insumo.Cantidad);
                    comando.Parameters.AddWithValue("@id", insumo.InsumoID);
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
                string cadenaComando = "DELETE FROM Insumos WHERE InsumoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Insumo insumo)
        {
            try
            {
                SqlCommand comando;
                if (insumo.InsumoID == 0)
                {
                    string cadenaComando = "SELECT InsumoID, Insumo,ProveedorID,Cantidad FROM Insumos WHERE ProveedorID=@proveedor AND Cantidad=@cant AND Insumo=@nombre";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", insumo.insumo);
                    comando.Parameters.AddWithValue("@proveedor", insumo.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@cant", insumo.Cantidad);


                }
                else
                {
                    string cadenaComando = "SELECT InsumoID, Insumo,ProveedorID,Cantidad FROM Insumos WHERE ProveedorID=@proveedor AND Cantidad=@cant AND Insumo=@nombre AND InsumoID<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", insumo.insumo);
                    comando.Parameters.AddWithValue("@id", insumo.InsumoID);
                    comando.Parameters.AddWithValue("@proveedor", insumo.Proveedor.ProveedorID);
                    comando.Parameters.AddWithValue("@cant", insumo.Cantidad);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Insumo insumo)
        {
            try
            {
                SqlCommand comando;
                var cadenaDeComando = "SELECT InsumoID FROM Colmenares WHERE InsumoID=@Id";
                comando = new SqlCommand(cadenaDeComando, _connection);
                comando.Parameters.AddWithValue("@id", insumo.InsumoID);
                var reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public void ActualizarStock(Compra compra)
        {
            try
            {
                foreach (var cm in compra.CompraInsumos)
                {
                    string cadenaComando = "UPDATE Insumos SET Cantidad=Cantidad+@cant WHERE InsumoId=@id";
                    var comando = new SqlCommand(cadenaComando, _connection, _tran);
                    comando.Parameters.AddWithValue("@cant", cm.Cantidad);
                    comando.Parameters.AddWithValue("@id", cm.Insumo.InsumoID);
                    comando.ExecuteNonQuery(); 
                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al actualizar la cantidad de un insumo");
            }
        }
        public void ActualizarStock(Insumo insumo, decimal cantidad)
        {
            try
            {
                string cadenaComando = "UPDATE Insumos SET Cantidad=Cantidad+@cant WHERE InsumoId=@id";
                var comando = new SqlCommand(cadenaComando, _connection, _tran);
                comando.Parameters.AddWithValue("@cant", cantidad);
                comando.Parameters.AddWithValue("@id", insumo.InsumoID);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al actualizar la cantidad de un insumo");
            }
        }



        public List<Insumo> GetLista(int proveedorId)
        {
            List<Insumo> lista = new List<Insumo>();
            try
            {
                string cadenaComando =
                    "SELECT InsumoId, Insumo, ProveedorId, Cantidad " +
                    " FROM Insumos WHERE ProveedorId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", proveedorId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Insumo insumo = ConstruirInsumo(reader);
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

        public List<Insumo> GetLista(string insumo)
        {
            List<Insumo> lista = new List<Insumo>();
            try
            {
                string cadenaComando =
                    "SELECT InsumoId, Insumo, ProveedorId, Cantidad " +
                    " FROM Insumos WHERE Insumo LIKE @desc";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@desc", $"%{insumo}%");
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Insumo insumos = ConstruirInsumo(reader);
                    lista.Add(insumos);
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
