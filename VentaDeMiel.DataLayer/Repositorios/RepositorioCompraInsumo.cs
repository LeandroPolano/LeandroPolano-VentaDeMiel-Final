using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
   public class RepositorioCompraInsumo
    {
        private SqlConnection conexion;
        private RepositorioCompra repositorioCompra;
        private RepositorioInsumo repositorioInsumo;
        private readonly SqlTransaction _tran;

        public RepositorioCompraInsumo(SqlConnection connection, RepositorioCompra repositorioCompra, RepositorioInsumo repositorioInsumo)
        {
            conexion = connection;
            this.repositorioCompra = repositorioCompra;
            this.repositorioInsumo = repositorioInsumo;
        }

        public RepositorioCompraInsumo(SqlConnection connection)
        {
            conexion = connection;
        }

        public CompraInsumo GetInsumoPorId(decimal id)
        {
            CompraInsumo p = null;
            try
            {
                string cadenaComando =
                    "SELECT CompraID, InsumoID, Cantidad, PrecioUnitario FROM ComprasInsumos WHERE InsumoID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
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



        public List<CompraInsumo> GetLista()
        {
            List<CompraInsumo> lista = new List<CompraInsumo>();
            try
            {
                string cadenaComando =
                    "SELECT CompraID, InsumoID, Cantidad, PrecioUnitario FROM ComprasInsumos ";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CompraInsumo insumo = ConstruirInsumo(reader);
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

        private CompraInsumo ConstruirInsumo(SqlDataReader reader)
        {
            CompraInsumo comprainsumo = new CompraInsumo();
            repositorioCompra = new RepositorioCompra(conexion);
            comprainsumo.Compra = repositorioCompra.GetCompraPorId(reader.GetInt32(0));
            repositorioInsumo = new RepositorioInsumo(conexion);
            comprainsumo.Insumo = repositorioInsumo.GetInsumoPorId(reader.GetDecimal(1));
            comprainsumo.Cantidad = reader.GetDecimal(2);
            comprainsumo.PrecioUnitario = reader.GetDecimal(3);



            return comprainsumo;

        }
        public void Guardar(CompraInsumo compraInsumo)
        {
            try
            {
                string cadenaComando = "INSERT INTO ComprasInsumos ( CompraID,InsumoID, Cantidad, PrecioUnitario)" +
                    " VALUES (@Compra,@InsumoId, @Cantidad , @precio)";
                var comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@Compra", compraInsumo.Compra.CompraID);
                comando.Parameters.AddWithValue("@InsumoID", compraInsumo.Insumo.InsumoID);
                comando.Parameters.AddWithValue("@Cantidad", compraInsumo.Cantidad);
                comando.Parameters.AddWithValue("@precio", compraInsumo.PrecioUnitario);

                comando.ExecuteNonQuery();


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            //try
            //{
            //    string cadenaComando = "UPDATE ComprasInsumos SET CompraID=@Compra,InsumoID=@insumo,Cantidad=@cantidad, TipoEnvaseID=@tipo, Precio= @precio " +
            //        " WHERE InsumoID=@id AND CompraID=@vID";
            //    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
            //    comando.Parameters.AddWithValue("@Compra", compraInsumo.Compra.CompraID);
            //    comando.Parameters.AddWithValue("@insumo", compraInsumo.Insumo.InsumoID);
            //    comando.Parameters.AddWithValue("@cantidad", compraInsumo.Cantidad);
            //    comando.Parameters.AddWithValue("@tipo", compraInsumo.TipoEnvase.TipoEnvaseID);
            //    comando.Parameters.AddWithValue("@precio", compraInsumo.Precio);

            //    comando.Parameters.AddWithValue("@id", compraInsumo.Insumo.InsumoID);
            //    comando.Parameters.AddWithValue("@vID", compraInsumo.Compra.CompraID);
            //    comando.ExecuteNonQuery();

            //}
            //catch (Exception e)
            //{
            //    throw new Exception(e.Message);
            //}



        }

        public void Borrar(CompraInsumo compraInsumo)
        {
            try
            {
                string cadenaComando = "DELETE FROM ComprasInsumos WHERE CompraID=@compra";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                //comando.Parameters.AddWithValue("@id", compraInsumo.Insumo.InsumoID);
                comando.Parameters.AddWithValue("@compra", compraInsumo.Compra.CompraID);

                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(CompraInsumo insumo)
        {
            //try
            //{
            //    SqlCommand comando;
            //    if (insumo.Insumo.InsumoID == 0 )
            //    {
            //        string cadenaComando = "SELECT InsumoID, CompraInsumo FROM ComprasInsumos WHERE  CompraInsumo=@nombre";
            //        comando = new SqlCommand(cadenaComando, conexion);
            //        comando.Parameters.AddWithValue("@nombre", insumo.insumo);

            //    }
            //    else
            //    {
            //        string cadenaComando = "SELECT InsumoID, CompraInsumo FROM ComprasInsumos WHERE  CompraInsumo=@nombre AND InsumoID<>@id";
            //        comando = new SqlCommand(cadenaComando, conexion);
            //        comando.Parameters.AddWithValue("@nombre", insumo.insumo);
            //        comando.Parameters.AddWithValue("@id", insumo.InsumoID);


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

        public bool EstaRelacionado(CompraInsumo insumo)
        {
            return false;
        }

    }
}
