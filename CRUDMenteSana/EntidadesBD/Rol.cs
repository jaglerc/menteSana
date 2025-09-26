using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Rol
    {
        int id_rol;
        string nombre;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        public Rol()
        {

        }

        public Rol(int id_rol, string nombre)
        {
            Id_rol = id_rol;
            Nombre = nombre;
        }

        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }
    }


}
