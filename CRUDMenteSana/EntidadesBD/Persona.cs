using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Persona
    {
        string id_persona, nombres, apellidos, correo_institucional, contraseña;
        int id_rol;

        private string _mensajeError, _valorScalar;
        private DataTable _dtResultados;

        public Persona()
        {

        }

        public Persona(string id_persona, string nombres, string apellidos, string correo_institucional, string contraseña, int id_rol)
        {
            Id_persona = id_persona;
            Nombres = nombres;
            Apellidos = apellidos;
            Correo_institucional = correo_institucional;
            Contraseña = contraseña;
            Id_rol = id_rol;
        }

        public string Id_persona { get => id_persona; set => id_persona = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Correo_institucional { get => correo_institucional; set => correo_institucional = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorScalar { get => _valorScalar; set => _valorScalar = value; }
        public DataTable DtResultados { get => _dtResultados; set => _dtResultados = value; }



    }
}
