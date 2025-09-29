using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Alerta
    {
        int id_alerta, id_estado;
        string tipo;
        DateTime fecha;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        public int Id_alerta { get => id_alerta; set => id_alerta = value; }
        public int Id_estado { get => id_estado; set => id_estado = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }

        public Alerta()
        {

        }

        public Alerta(int id_alerta, int id_estado, string tipo, DateTime fecha)
        {
            Id_alerta = id_alerta;
            Id_estado = id_estado;
            Tipo = tipo;
            Fecha = fecha;


        }
    }
}
