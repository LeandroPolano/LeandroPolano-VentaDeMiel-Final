using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaDeMiel.BusinessLayer.Entities;

namespace VentaDeMiel.DataLayer.Repositorios
{
    public class RepositorioColmenar
    {
        private readonly SqlConnection _connection;
        private readonly RepositorioCiudad _repositorioCiudad;
        private readonly SqlTransaction _tran;
        private  RepositorioEstadoColmena _repositorioEstadoColmena;
        private RepositorioInsumo _repositorioInsumo;

        public RepositorioColmenar(SqlConnection connection, RepositorioCiudad repositorioCiudad, RepositorioEstadoColmena repositorioEstadoColmena, RepositorioInsumo repositorioInsumo)
        {
            _connection = connection;
            this._repositorioCiudad = repositorioCiudad;
            this._repositorioEstadoColmena = repositorioEstadoColmena;
            this._repositorioInsumo = repositorioInsumo;

        }

        public RepositorioColmenar(SqlConnection connection, RepositorioCiudad _repositorioCiudad)
        {
            _connection = connection;
        }

        public RepositorioColmenar(SqlConnection cn, SqlTransaction tran)
        {
            _connection = cn;
            _tran = tran;
        }

        public RepositorioColmenar(SqlConnection sqlConnection)
        {
            this._connection = sqlConnection;
        }

        public Colmenar GetColmenarPorId(decimal id)
        {
            Colmenar p = null;
            try
            {
                string cadenaComando =
                    "SELECT ColmenarId, NombreColmenar, CiudadId, CantidadColmena, EstadoColmenaID, InsumoID,CantidadInsumo FROM Colmenares WHERE ColmenarId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    p = ConstruirColmenar(reader);
                }
                reader.Close();
                return p;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<Colmenar> GetLista()
        {
            List<Colmenar> lista = new List<Colmenar>();
            try
            {
                string cadenaComando =
                    "SELECT ColmenarId, NombreColmenar, CiudadId, CantidadColmena, EstadoColmenaID, InsumoID, CantidadInsumo " +
                    " FROM Colmenares";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Colmenar colmenar = ConstruirColmenar(reader);
                    lista.Add(colmenar);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
       
        private Colmenar ConstruirColmenar(SqlDataReader reader)
        {
            _repositorioEstadoColmena = new RepositorioEstadoColmena(_connection);
            Colmenar colmenar = new Colmenar();
            colmenar.ColmenarID = reader.GetDecimal(0);
            colmenar.NombreColmenar = reader.GetString(1);
            colmenar.Ciudad = _repositorioCiudad.GetCiudadPorId(reader.GetDecimal(2));
            colmenar.CantidadColmena = reader.GetDecimal(3);
            colmenar.EstadoColmena = _repositorioEstadoColmena.GetEstadoColmenaPorId(reader.GetDecimal(4));
            colmenar.Insumo = _repositorioInsumo.GetInsumoPorId(reader.GetDecimal(5));
            colmenar.CantidadInsumo = reader.GetDecimal(6);


            return colmenar;

        }
        public void Guardar(Colmenar colmenar)
        {
            if (colmenar.ColmenarID == 0)
            {
                try
                {
                    string cadenaComando = "INSERT INTO Colmenares (NombreColmenar, CiudadId, CantidadColmena, EstadoColmenaID, InsumoID,CantidadInsumo) VALUES (@desc, @ciudad, @colm, @esta, @insu,@cant)";
                    var comando = new SqlCommand(cadenaComando, _connection,_tran);
                    comando.Parameters.AddWithValue("@desc", colmenar.NombreColmenar);
                    comando.Parameters.AddWithValue("@ciudad", colmenar.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@colm", colmenar.CantidadColmena);
                    comando.Parameters.AddWithValue("@esta", colmenar.EstadoColmena.EstadoColmenaID);
                    comando.Parameters.AddWithValue("@insu", colmenar.Insumo.InsumoID);
                    comando.Parameters.AddWithValue("@cant",colmenar.CantidadInsumo);

                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _connection,_tran);
                    int id = (int)(decimal)comando.ExecuteScalar();
                    colmenar.ColmenarID = id;




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
                    string cadenaComando = "UPDATE Colmenares SET NombreColmenar=@nombre,CiudadId=@ciudadId, CantidadColmena=@colm, EstadoColmenaID=@esta, InsumoID=@insu ,CantidadInsumo=@cant WHERE ColmenarId=@id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _connection,_tran);
                    comando.Parameters.AddWithValue("@nombre", colmenar.NombreColmenar);
                    comando.Parameters.AddWithValue("@ciudadId", colmenar.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@colm", colmenar.CantidadColmena);
                    comando.Parameters.AddWithValue("@esta", colmenar.EstadoColmena.EstadoColmenaID);
                    comando.Parameters.AddWithValue("@insu", colmenar.Insumo.InsumoID);
                    comando.Parameters.AddWithValue("@cant", colmenar.CantidadInsumo);

                    comando.Parameters.AddWithValue("@id", colmenar.ColmenarID);
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
                string cadenaComando = "DELETE FROM Colmenares WHERE ColmenarID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(Colmenar colmenar)
        {
            try
            {
                SqlCommand comando;
                if (colmenar.ColmenarID == 0)
                {
                    string cadenaComando = "SELECT ColmenarID, NombreColmenar,CiudadID, CantidadColmena, InsumoID FROM Colmenares WHERE CiudadID=@ciudad AND NombreColmenar=@nombre AND CantidadColmena=@colm AND InsumoID=@insu AND EstadoColmenaID=@esta";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", colmenar.NombreColmenar);
                    comando.Parameters.AddWithValue("@ciudad", colmenar.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@colm", colmenar.CantidadColmena);
                    comando.Parameters.AddWithValue("@esta", colmenar.EstadoColmena.EstadoColmenaID);
                    comando.Parameters.AddWithValue("@insu", colmenar.Insumo.InsumoID);



                }
                else
                {
                    string cadenaComando = "SELECT ColmenarID, NombreColmenar,CiudadID, InsumoID FROM Colmenares WHERE CiudadID=@ciudad AND NombreColmenar=@nombre AND CantidadColmena=@colm AND EstadoColmenaID=@esta AND InsumoID=@insu AND ColmenarID<>@id";
                    comando = new SqlCommand(cadenaComando, _connection);
                    comando.Parameters.AddWithValue("@nombre", colmenar.NombreColmenar);
                    comando.Parameters.AddWithValue("@id", colmenar.ColmenarID);
                    comando.Parameters.AddWithValue("@ciudad", colmenar.Ciudad.CiudadID);
                    comando.Parameters.AddWithValue("@colm", colmenar.CantidadColmena);
                    comando.Parameters.AddWithValue("@esta", colmenar.EstadoColmena.EstadoColmenaID);
                    comando.Parameters.AddWithValue("@insu", colmenar.Insumo.InsumoID);



                }
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool EstaRelacionado(Colmenar colmenar)
        {
            throw new System.NotImplementedException();
        }

        



        public List<Colmenar> GetLista(int ciudadId)
        {
            List<Colmenar> lista = new List<Colmenar>();
            try
            {
                string cadenaComando =
                    "SELECT ColmenarId, NombreColmenar, CiudadId, CantidadColmena, EstadoColmenaID, InsumoID" +
                    " FROM Colmenares WHERE CiudadId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", ciudadId);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Colmenar colmenar = ConstruirColmenar(reader);
                    lista.Add(colmenar);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<Colmenar> GetLista(string colmenar)
        {
            List<Colmenar> lista = new List<Colmenar>();
            try
            {
                string cadenaComando =
                    "SELECT ColmenarId, NombreColmenar, CiudadId, CantidadColmena, InsumoID " +
                    " FROM Colmenares WHERE NombreColmenar LIKE @desc";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@desc", $"%{colmenar}%");
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Colmenar colmenars = ConstruirColmenar(reader);
                    lista.Add(colmenars);
                }
                reader.Close();
                return lista;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            
        }
        public List<Colmenar> GetLista(decimal EstadoColmenaID)
        {
            List<Colmenar> listaCol = new List<Colmenar>();
            try
            {
                string cadenaComando =
                    "SELECT ColmenarId, NombreColmenar, CiudadId, CantidadColmena, EstadoColmenaID, InsumoID" +
                    " FROM Colmenares WHERE EstadoColmenaID=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _connection);
                comando.Parameters.AddWithValue("@id", EstadoColmenaID);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Colmenar colmenar = ConstruirColmenar(reader);
                    listaCol.Add(colmenar);
                }
                reader.Close();
                return listaCol;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
