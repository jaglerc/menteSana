using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Recomendacion
    {
        int id_recomendacion, id_estado;
        string contenido;
        DateTime fecha_generada;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        public Recomendacion()
        {

        }

        public Recomendacion(int id_recomendacion, int id_estado, string contenido, DateTime fecha_generada)
        {
            Id_recomendacion = id_recomendacion;
            Id_estado = id_estado;
            Contenido = contenido;
            Fecha_generada = fecha_generada;
        }

        public int Id_recomendacion { get => id_recomendacion; set => id_recomendacion = value; }
        public int Id_estado { get => id_estado; set => id_estado = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public DateTime Fecha_generada { get => fecha_generada; set => fecha_generada = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
    }
}
