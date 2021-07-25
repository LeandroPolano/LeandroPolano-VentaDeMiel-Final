using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
   public class RepositorioClienteDeMiel
    {
        private readonly SqlConnection conexion;
        private RepositorioCiudad repositorioCiudad;
        private RepositorioTipoDocumento repositorioTipoDocumento;
        private readonly SqlTransaction _tran;

        public RepositorioClienteDeMiel(SqlConnection connection, RepositorioCiudad repositorioCiudad)
        {
            conexion = connection;
            this.repositorioCiudad = repositorioCiudad;
        }

        public RepositorioClienteDeMiel(SqlConnection connection)
        {
            conexion = connection;
        }

        public RepositorioClienteDeMiel(SqlConnection sqlConnection, RepositorioCiudad repositorioCiudad1, RepositorioTipoDocumento repositorioTipoDocumento1)
        {
            this.conexion = sqlConnection;
            this.repositorioCiudad = repositorioCiudad1;
            this.repositorioTipoDocumento = repositorioTipoDocumento1;
        }

        public ClienteDeMiel GetClienteDeMielPorId(decimal id)
        {
            ClienteDeMiel p = null;
            try
            {
                string cadenaComando =
                    "SELECT ClienteID,RazonSocial,Direccion,CiudadID,CPostal,Telefono,Email,TipoDocumentoID,NumeroDocumento FROM ClientesDeMiel WHERE ClienteID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirClienteDeMiel(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<ClienteDeMiel> GetLista()
        {
            List<ClienteDeMiel> lista = new List<ClienteDeMiel>();
            try
            {
                string cadenaComando =
                    "SELECT ClienteID,RazonSocial,Direccion,CiudadID,CPostal,Telefono,Email,TipoDocumentoID,NumeroDocumento FROM ClientesDeMiel ";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ClienteDeMiel proveedor = ConstruirClienteDeMiel(reader);
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


        private ClienteDeMiel ConstruirClienteDeMiel(SqlDataReader reader)
        {
            ClienteDeMiel cliente = new ClienteDeMiel();
            cliente.ClienteID = reader.GetDecimal(0);
            cliente.RazonSocial = reader.GetString(1);
            cliente.Direccion = reader.GetString(2);
            repositorioCiudad = new RepositorioCiudad(conexion);
            cliente.Ciudad = repositorioCiudad.GetCiudadPorId(reader.GetDecimal(3));
            cliente.CodigoPostal = reader.GetDecimal(4);
            cliente.Telefono = reader.GetDecimal(5);
            cliente.Email = reader.GetString(6);
            repositorioTipoDocumento = new RepositorioTipoDocumento(conexion);
            cliente.TipoDocumento = repositorioTipoDocumento.GetTipoDocumentoPorId(reader.GetDecimal(7));
            cliente.NumeroDocumento = reader.GetDecimal(8);



            return cliente;

        }

        public bool EstaRelacionado(ClienteDeMiel proveedor)
        {
            return false;
        }

        public void Guardar(ClienteDeMiel proveedor)
        {
            if (proveedor.ClienteID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO ClientesDeMiel (RazonSocial,Direccion,CiudadID,CPostal,Telefono,Email,TipoDocumentoID,NumeroDocumento )" +
                        " VALUES (@razon ,@direc, @ciudad, @cpostal, @tel, @email, @tipodoc, @numdoc)";
                    var comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@razon", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@direc", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@ciudad", proveedor.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@cpostal", proveedor.CodigoPostal);
                    comando.Parameters.AddWithValue("@tel", proveedor.Telefono);
                    comando.Parameters.AddWithValue("@email", proveedor.Email);
                    comando.Parameters.AddWithValue("@tipodoc", proveedor.TipoDocumento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@numdoc", proveedor.NumeroDocumento);


                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, conexion);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    proveedor.ClienteID = id;




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
                    string cadenaComando = "UPDATE ClientesDeMiel SET RazonSocial=@razon, Direccion=@direc, CiudadID=@ciudad, CPostal=@cpostal, " +
                        "Telefono=@tel, Email=@email, TipoDocumentoID=@tipodoc,NumeroDocumento=@numdoc WHERE ClienteID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                    
                    comando.Parameters.AddWithValue("@razon", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@direc", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@ciudad", proveedor.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@cpostal", proveedor.CodigoPostal);
                    comando.Parameters.AddWithValue("@tel", proveedor.Telefono);
                    comando.Parameters.AddWithValue("@email", proveedor.Email);
                    comando.Parameters.AddWithValue("@tipodoc", proveedor.TipoDocumento.TipoDocumentoID);
                    comando.Parameters.AddWithValue("@numdoc", proveedor.NumeroDocumento);
                    comando.Parameters.AddWithValue("@id", proveedor.ClienteID);
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
                string cadenaComando = "DELETE FROM ClientesDeMiel WHERE ClienteID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ClienteDeMiel proveedor)
        {
            try
            {
                SqlCommand comando;
                if (proveedor.ClienteID == 0)
                {
                    string cadenaComando = "SELECT ClienteID, RazonSocial, NumeroDocumento FROM ClientesDeMiel WHERE  RazonSocial=@nombre AND NumeroDocumento=@numdoc";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@numdoc", proveedor.NumeroDocumento);

                }
                else
                {
                    string cadenaComando = "SELECT ClienteID, RazonSocial, NumeroDocumento FROM ClientesDeMiel WHERE  RazonSocial=@nombre AND ClienteID<>@id AND NumeroDocumento=@numdoc";
                    comando = new SqlCommand(cadenaComando, conexion);
                    comando.Parameters.AddWithValue("@nombre", proveedor.RazonSocial);
                    comando.Parameters.AddWithValue("@numdoc", proveedor.NumeroDocumento);
                    comando.Parameters.AddWithValue("@id", proveedor.ClienteID);


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
