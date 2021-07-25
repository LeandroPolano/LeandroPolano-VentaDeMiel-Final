using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioProveedor
    {
        private readonly SqlConnection conexion;
        private RepositorioCiudad repositorioCiudad;
        private readonly SqlTransaction _tran;

        public RepositorioProveedor(SqlConnection connection, RepositorioCiudad repositorioCiudad)
        {
            conexion = connection;
            this.repositorioCiudad = repositorioCiudad;
        }

        public RepositorioProveedor(SqlConnection connection)
        {
            conexion = connection;
        }

        public Proveedor GetProveedorPorId(decimal id)
        {
            Proveedor p = null;
            try
            {
                string cadenaComando =
                    "SELECT ProveedorID,Cuit,RazonSocial,Direccion,CiudadID,CPostal,Telefono,Email FROM Proveedores WHERE ProveedorID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirProveedor(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Proveedor> GetLista()
        {
            List<Proveedor> lista = new List<Proveedor>();
            try
            {
                string cadenaComando =
                    "SELECT ProveedorID,Cuit,RazonSocial,Direccion,CiudadID,CPostal,Telefono,Email FROM Proveedores ";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Proveedor proveedor = ConstruirProveedor(reader);
                    lista.Add(proveedor);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        private Proveedor ConstruirProveedor(SqlDataReader reader)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.ProveedorID = reader.GetDecimal(0);
            proveedor.Cuit = reader.GetDecimal(1);
            proveedor.RazonSocial = reader.GetString(2);
            proveedor.Direccion = reader.GetString(3);
            repositorioCiudad = new RepositorioCiudad(conexion);
            proveedor.Ciudad = repositorioCiudad.GetCiudadPorId(reader.GetDecimal(4));
            proveedor.CodigoPostal = reader.GetDecimal(5);
            proveedor.Telefono = reader.GetDecimal(6);
            proveedor.Email = reader.GetString(7);



            return proveedor;

        }

        public bool EstaRelacionado(Proveedor proveedor)
        {
            try
            {
                SqlCommand comando;
                var cadenaDeComando = "SELECT ProveedorID FROM ProductosDeProveedores WHERE ProveedorID=@Id";
                comando = new SqlCommand(cadenaDeComando, conexion);
                comando.Parameters.AddWithValue("@id", proveedor.ProveedorID);
                var reader = comando.ExecuteReader();
                if (!reader.HasRows)
                {

                    cadenaDeComando = "SELECT ProveedorID FROM Insumos WHERE ProveedorID=@Id";
                    comando = new SqlCommand(cadenaDeComando, conexion);
                    comando.Parameters.AddWithValue("@id", proveedor.ProveedorID);
                    reader = comando.ExecuteReader();
                }
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(Proveedor proveedor)
        {
            if (proveedor.ProveedorID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Proveedores (Cuit,RazonSocial,Direccion,CiudadID,CPostal,Telefono,Email )" +
                        " VALUES (@cuit, @razon ,@direc, @ciudad, @cpostal, @tel, @email)";
                    var comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@cuit", proveedor.Cuit);
                    comando.Parameters.AddWithValue("@razon", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@direc", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@ciudad", proveedor.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@cpostal", proveedor.CodigoPostal);
                    comando.Parameters.AddWithValue("@tel", proveedor.Telefono);
                    comando.Parameters.AddWithValue("@email", proveedor.Email);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    proveedor.ProveedorID = id;




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
                    string cadenaComando = "UPDATE Productos SET Cuit=@cuit,RazonSocial=@razon, Direccion=@direc, Ciudad=@ciudad CPostal=@cpostal, " +
                        "Telefono=@tel, Email=@email WHERE ProveedorID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@cuit", proveedor.Cuit);
                    comando.Parameters.AddWithValue("@razon", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@direc", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@ciudad", proveedor.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@cpostal", proveedor.CodigoPostal);
                    comando.Parameters.AddWithValue("@tel", proveedor.Telefono);
                    comando.Parameters.AddWithValue("@email", proveedor.Email);
                    comando.Parameters.AddWithValue("@id", proveedor.ProveedorID);
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
                string cadenaComando = "DELETE FROM Proveedores WHERE ProveedorID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Proveedor proveedor)
        {
            try
            {
                SqlCommand comando;
                if (proveedor.ProveedorID == 0)
                {
                    string cadenaComando = "SELECT ProveedorID, RazonSocial FROM Proveedores WHERE  RazonSocial=@nombre";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", proveedor.RazonSocial);

                }
                else
                {
                    string cadenaComando = "SELECT ProveedorID, RazonSocial FROM Proveedores WHERE  RazonSocial=@nombre AND ProveedorID<>@id";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@id", proveedor.ProveedorID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       
    }
}
