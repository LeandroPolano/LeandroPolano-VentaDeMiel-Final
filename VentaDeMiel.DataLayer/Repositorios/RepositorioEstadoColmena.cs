using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
   public class RepositorioEstadoColmena
    {
        private readonly SqlConnection _sqlConnection;
        

        public RepositorioEstadoColmena(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public EstadoColmena GetEstadoColmenaPorId(decimal id)
        {
            try
            {
                EstadoColmena estadoColmena = null;
                string cadenaComando = "SELECT EstadoColmenaID, EstadoColmena FROM EstadosColmenas WHERE EstadoColmenaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    estadoColmena = ConstruirEstadoColmena(reader);
                    reader.Close();
                }

                return estadoColmena;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<EstadoColmena> GetLista()
        {
            List<EstadoColmena> lista = new List<EstadoColmena>();
            try
            {
                string cadenaComando = "SELECT EstadoColmenaID, EstadoColmena FROM EstadosColmenas";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    EstadoColmena estadoColmena = ConstruirEstadoColmena(reader);
                    lista.Add(estadoColmena);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private EstadoColmena ConstruirEstadoColmena(SqlDataReader reader)
        {

            var estadoColmena = new EstadoColmena();
            estadoColmena.EstadoColmenaID = reader.GetDecimal(0);
            estadoColmena.estadoColmena = reader.GetString(1);
            return estadoColmena;

        }

        public void Guardar(EstadoColmena estadoColmena)
        {
            if (estadoColmena.EstadoColmenaID == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO EstadosColmenas VALUES(@nombre)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", estadoColmena.estadoColmena);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    estadoColmena.EstadoColmenaID = (int)(decimal)comando.ExecuteScalar();

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
                    string cadenaComando = "UPDATE EstadosColmenas SET EstadoColmena=@nombre WHERE EstadoColmenaID=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", estadoColmena.estadoColmena);
                    comando.Parameters.AddWithValue("@id", estadoColmena.EstadoColmenaID);
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
                string cadenaComando = "DELETE FROM EstadosColmenas WHERE EstadoColmenaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _sqlConnection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public bool Existe(EstadoColmena estadoColmena)
        {
            try
            {
                SqlCommand comando;
                if (estadoColmena.EstadoColmenaID == 0)
                {
                    string cadenaComando = "SELECT EstadoColmenaID, EstadoColmena FROM EstadosColmenas WHERE EstadoColmena=@nombre";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", estadoColmena.estadoColmena);

                }
                else
                {
                    string cadenaComando = "SELECT EstadoColmenaID, EstadoColmena FROM EstadosColmenas WHERE EstadoColmena=@nombre AND EstadoColmenaID<>@id";
                    comando = new SqlCommand(cadenaComando, _sqlConnection);
                    comando.Parameters.AddWithValue("@nombre", estadoColmena.estadoColmena);
                    comando.Parameters.AddWithValue("@id", estadoColmena.EstadoColmenaID);


                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(EstadoColmena estadoColmena)
        {
            try
            {
                var CadenaDeComando = "select EstadoColmenaID from Colmenares where EstadoColmenaID = @Id";
                var Comando = new SqlCommand(CadenaDeComando, _sqlConnection);
                Comando.Parameters.AddWithValue("@Id", estadoColmena.EstadoColmenaID);
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
