using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ClsDatos
    {
        #region Variables Privadas

        private SqlConnection _objSqlConnection; //Conectar a BD
        private SqlDataAdapter _objSqlDataAdapter; //Permite lectura de datos con select
        private SqlCommand _objSqlCommand; //Usar comandos DML
        private DataSet _dtResultados; //Lista la tabla de resultados
        private DataTable _dtParametros; //Parametros para los procedimientos almacenados  
        private string _nombreTabla, _nombreSP, _mensajeErrorOS, _valorScalar, _nombreDB;
        private bool _scalar;

        #endregion

        #region Variables Publicas

        public SqlConnection ObjSqlConnection { get => _objSqlConnection; set => _objSqlConnection = value; }
        public SqlDataAdapter ObjSqlDataAdapter { get => _objSqlDataAdapter; set => _objSqlDataAdapter = value; }
        public SqlCommand ObjSqlCommand { get => _objSqlCommand; set => _objSqlCommand = value; }
        public DataSet DtResultados { get => _dtResultados; set => _dtResultados = value; }
        public DataTable DtParametros { get => _dtParametros; set => _dtParametros = value; }
        public string NombreTabla { get => _nombreTabla; set => _nombreTabla = value; }
        public string NombreSP { get => _nombreSP; set => _nombreSP = value; }
        public string MensajeErrorOS { get => _mensajeErrorOS; set => _mensajeErrorOS = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public string NombreDB { get => _nombreDB; set => _nombreDB = value; }
        public bool Scalar { get => _scalar; set => _scalar = value; }

        #endregion

        #region Constructores


        public ClsDatos()
        {
            DtParametros = new DataTable();
            DtParametros.Columns.Add("Nombre");
            DtParametros.Columns.Add("TipoDato");
            DtParametros.Columns.Add("Valor");
            NombreDB = "DBMenteSana";
        }

        public ClsDatos(SqlConnection objSqlConnection, SqlDataAdapter objSqlDataAdapter, SqlCommand objSqlCommand, DataSet dtResultados, 
            DataTable dtParametros, string nombreTabla, string nombreSP, string mensajeErrorOS, string valorScalar, string nombreDB, bool scalar)
        {
            ObjSqlConnection = objSqlConnection;
            ObjSqlDataAdapter = objSqlDataAdapter;
            ObjSqlCommand = objSqlCommand;
            DtResultados = dtResultados;
            DtParametros = dtParametros;
            NombreTabla = nombreTabla;
            NombreSP = nombreSP;
            MensajeErrorOS = mensajeErrorOS;
            ValorScalar = valorScalar;
            NombreDB = nombreDB;
            Scalar = scalar;
        }

        #endregion

        #region Metodos Privados

        private void CrearConexionBaseDatos(ref ClsDatos objDatos)
        {
            switch (objDatos.NombreDB)
            {
                case "DBMenteSana":
                    objDatos.ObjSqlConnection = new SqlConnection(AccesoDatos.Properties.Settings.Default.ConexMenteSana);
                    break;
            }
        }

        private void ValidarConexionBaseDatos(ref ClsDatos objDatos)
        {
            if (objDatos.ObjSqlConnection.State == ConnectionState.Closed)
            {
                objDatos.ObjSqlConnection.Open();
            }
            else
            {
                objDatos.ObjSqlConnection.Close();
                objDatos.ObjSqlConnection.Dispose(); //Memoria disponible
            }
        }

        private void AgregarParametros(ref ClsDatos objDataBase)
        {
            if (objDataBase.DtParametros != null)
            {
                SqlDbType TipoDatoSQL = new SqlDbType();
                foreach (DataRow item in objDataBase.DtParametros.Rows)
                {
                    switch (item[1])
                    {
                        case "1":
                            TipoDatoSQL = SqlDbType.Bit;
                            break;
                        case "2":
                            TipoDatoSQL = SqlDbType.TinyInt;
                            break;
                        case "3":
                            TipoDatoSQL = SqlDbType.SmallInt;
                            break;
                        case "4":
                            TipoDatoSQL = SqlDbType.Int;
                            break;
                        case "5":
                            TipoDatoSQL = SqlDbType.BigInt;
                            break;
                        case "6":
                            TipoDatoSQL = SqlDbType.Decimal;
                            break;
                        case "7":
                            TipoDatoSQL = SqlDbType.SmallMoney;
                            break;
                        case "8":
                            TipoDatoSQL = SqlDbType.Money;
                            break;
                        case "9":
                            TipoDatoSQL = SqlDbType.Float;
                            break;
                        case "10":
                            TipoDatoSQL = SqlDbType.Real;
                            break;
                        case "11":
                            TipoDatoSQL = SqlDbType.Date;
                            break;
                        case "12":
                            TipoDatoSQL = SqlDbType.Time;
                            break;
                        case "13":
                            TipoDatoSQL = SqlDbType.SmallDateTime;
                            break;
                        case "14":
                            TipoDatoSQL = SqlDbType.Char;
                            break;
                        case "15":
                            TipoDatoSQL = SqlDbType.VarChar;
                            break;
                        case "16":
                            TipoDatoSQL = SqlDbType.NVarChar;
                            break;
                        default:
                            break;
                    }
                    if (objDataBase.Scalar)
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            objDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = DBNull.Value;
                        }
                        else
                        {
                            objDataBase.ObjSqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();
                        }

                    }
                    else
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            objDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = DBNull.Value;
                        }
                        else
                        {
                            objDataBase.ObjSqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();
                        }
                    }
                }
            }
        }

        private void PrepararConexionBaseDatos(ref ClsDatos objDataBase)
        {
            CrearConexionBaseDatos(ref objDataBase);
            ValidarConexionBaseDatos(ref objDataBase);
        }

        private void EjecutarDataAdapter(ref ClsDatos objDatos)
        {
            try
            {
                PrepararConexionBaseDatos(ref objDatos);
                objDatos.ObjSqlDataAdapter = new SqlDataAdapter(objDatos.NombreSP, objDatos.ObjSqlConnection);
                objDatos.ObjSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                AgregarParametros(ref objDatos);
                objDatos.DtResultados = new DataSet();
                objDatos.ObjSqlDataAdapter.Fill(objDatos.DtResultados, objDatos.NombreTabla);


            }
            catch (Exception ex)
            {
                objDatos.MensajeErrorOS = ex.Message.ToString();

            }
            finally
            {
                if (objDatos.ObjSqlConnection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref objDatos);
                }
            }

        }

        private void EjecutarCommand(ref ClsDatos objDatos)
        {
            try
            {
                PrepararConexionBaseDatos(ref objDatos);
                objDatos.ObjSqlCommand = new SqlCommand(objDatos.NombreSP, objDatos.ObjSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                };
                AgregarParametros(ref objDatos);
                if (objDatos.Scalar)
                {
                    objDatos.ValorScalar = objDatos.ObjSqlCommand.ExecuteScalar().ToString().Trim();
                }
                else
                {
                    objDatos.ObjSqlCommand.ExecuteNonQuery().ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                objDatos.MensajeErrorOS = ex.Message.ToString();
            }
            finally
            {
                if (objDatos.ObjSqlConnection.State == ConnectionState.Open)
                {
                    ValidarConexionBaseDatos(ref objDatos);
                }
            }
        }

        public void CRUD(ref ClsDatos objDatos)
        {
            if (objDatos.Scalar)
            {
                EjecutarCommand(ref objDatos);
            }
            else
            {
                EjecutarDataAdapter(ref objDatos);
            }

        }

        #endregion
    }
}
