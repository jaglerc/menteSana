using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Cita
    {
        int id_cita;
        string id_estudiante, id_psicologo;
        DateTime fecha = DateTime.Now.Date;
        TimeSpan hora = DateTime.Now.TimeOfDay;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;


        public int Id_cita { get => id_cita; set => id_cita = value; }
        public string Id_estudiante { get => id_estudiante; set => id_estudiante = value; }
        public string Id_psicologo { get => id_psicologo; set => id_psicologo = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public TimeSpan Hora { get => hora; set => hora = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }

        public Cita()
        {

        }

        public Cita(int id_cita, string id_estudiante, string id_psicologo, DateTime fecha, TimeSpan hora)
        {
            Id_cita = id_cita;
            Id_estudiante = id_estudiante;
            Id_psicologo = id_psicologo;
            Fecha = fecha;
            Hora = hora;
        }

    }
}
