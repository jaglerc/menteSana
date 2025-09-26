using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Estado_Emocional
    {
        int id_estado;
        string id_persona, nombre_estado, nota;
        DateTime fecha_hora;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        public Estado_Emocional()
        {

        }


        public int Id_estado { get => id_estado; set => id_estado = value; }
        public string Id_persona { get => id_persona; set => id_persona = value; }
        public string Nombre_estado { get => nombre_estado; set => nombre_estado = value; }
        public string Nota { get => nota; set => nota = value; }
        public DateTime Fecha_hora { get => fecha_hora; set => fecha_hora = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }

        public Estado_Emocional(int id_estado, string id_persona, string nombre_estado, string nota, DateTime fecha_hora)
        {
            Id_estado = id_estado;
            Id_persona = id_persona;
            Nombre_estado = nombre_estado;
            Nota = nota;
            Fecha_hora = fecha_hora;
        }

    }
}
