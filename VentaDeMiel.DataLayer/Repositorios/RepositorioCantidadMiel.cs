using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioCantidadMiel
    {
        private readonly SqlConnection _sqlConnection;

        public RepositorioCantidadMiel(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public CantidadMiel GetCantidadMielPorId(int id)
        {
            try
            {
                CantidadMiel cantidadMiel = null;
                string cadenaComando = "SELECT CantidadMielID, CantidadMiel FROM CantidadesMiel WHERE CantidadMielID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    cantidadMiel = ConstruirCantidadMiel(reader);
                    reader.Close();
                }

                return cantidadMiel;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<CantidadMiel> GetLista()
        {
            List<CantidadMiel> lista = new List<CantidadMiel>();
            try
            {
                string cadenaComando = "SELECT CantidadMielID, CantidadMiel FROM CantidadesMiel";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    CantidadMiel cantidadMiel = ConstruirCantidadMiel(reader);
                    lista.Add(cantidadMiel);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private CantidadMiel ConstruirCantidadMiel(SqlDataReader reader)
        {

            var cantidadMiel = new CantidadMiel();
            cantidadMiel.CantidadMielID = reader.GetInt32(0);
            cantidadMiel.cantidadMiel = reader.GetDecimal(1);
            return cantidadMiel;

        }

        public void Guardar(decimal Cantidad)
        {
            try
            {

                    string cadenaComando = "UPDATE CantidadesMiel SET CantidadMiel=CantidadMiel+@nombre WHERE CantidadMielID=1";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", Cantidad);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            
        }

    }
}
