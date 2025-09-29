using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Reporte
    {
        int id_reporte;
        string id_psicologo, tipo, id_estudiante;
        DateTime fecha_generacion;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;


        public int Id_reporte { get => id_reporte; set => id_reporte = value; }
        public string Id_psicologo { get => id_psicologo; set => id_psicologo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public DateTime Fecha_generacion { get => fecha_generacion; set => fecha_generacion = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }

        public Reporte()
        {

        }

        public Reporte(int id_reporte, string id_psicologo, string tipo, string id_estudiante, DateTime fecha_generacion,
            string mensajeError, string valorScalar, DataTable dtResultados)
        {
            Id_reporte = id_reporte;
            Id_psicologo = id_psicologo;
            Tipo = tipo;
            Id_estudiante = id_estudiante;
            Fecha_generacion = fecha_generacion;
            MensajeError = mensajeError;
            ValorScalar = valorScalar;
            DtResultados = dtResultados;
        }

    }
}
