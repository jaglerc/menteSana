using AccesoDatos;
using EntidadesBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaN
{
    public class PersonaLn
    {
        #region Variables Privadas
        private ClsDatos ObjDatos = null;

        #endregion

        #region MetodoIndex
        public void Index(ref Persona ObjPersona)
        {
            ObjDatos = new ClsDatos()
            {
                NombreTabla = "Persona",
                NombreSP = "[listar_persona]",
                Scalar = false
            };
            Ejecutar(ref ObjPersona);
        }
        #endregion

        private void Ejecutar(ref Persona ObjPersona)
        {
            ObjDatos.CRUD(ref ObjDatos);
            if (ObjDatos.MensajeErrorOS == null)
            {
                if (ObjDatos.Scalar)
                {
                    ObjPersona.ValorScalar = ObjDatos.ValorScalar;
                }

                else
                {
                    ObjPersona.DtResultados = ObjDatos.DtResultados.Tables[0];
                    if (ObjPersona.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjPersona.DtResultados.Rows)
                        {
                            ObjPersona.Id_persona = item["id_persona"].ToString();
                            ObjPersona.Nombres = item["nombres"].ToString();
                            ObjPersona.Apellidos = item["apellidos"].ToString();
                            ObjPersona.Correo_institucional = item["correo_institucional"].ToString();
                            ObjPersona.Contraseña = item["contraseña"].ToString();
                            ObjPersona.Id_rol = Convert.ToInt32(item["id_rol"].ToString());

                        }

                    }
                }
            }
            else
            {
                ObjPersona.MensajeError = ObjDatos.MensajeErrorOS;
            }
        }

        #region MetodosCrud
        public void Create(ref Persona ObjPersona)
        {
            ObjDatos = new ClsDatos()
            {
                NombreTabla = "Persona",
                NombreSP = "[insertar_Persona]",
                Scalar = true
            };
            ObjDatos.DtParametros.Rows.Add(@"@id_persona", "16", ObjPersona.Id_persona);
            ObjDatos.DtParametros.Rows.Add(@"@nombres", "16", ObjPersona.Nombres);
            ObjDatos.DtParametros.Rows.Add(@"@apellidos", "16", ObjPersona.Apellidos);
            ObjDatos.DtParametros.Rows.Add(@"@correo_institucional", "16", ObjPersona.Correo_institucional);
            ObjDatos.DtParametros.Rows.Add(@"@contraseña", "16", ObjPersona.Contraseña);
            ObjDatos.DtParametros.Rows.Add(@"@id_rol", "4", ObjPersona.Id_rol);

            Ejecutar(ref ObjPersona);
        }

        public void Update(ref Persona ObjPersona)
        {
            ObjDatos = new ClsDatos()
            {
                NombreTabla = "Persona",
                NombreSP = "[actualizar_Persona]",
                Scalar = true
            };
            ObjDatos.DtParametros.Rows.Add(@"@id_persona", "4", ObjPersona.Id_persona);
            ObjDatos.DtParametros.Rows.Add(@"@nombres", "16", ObjPersona.Nombres);
            ObjDatos.DtParametros.Rows.Add(@"@apellidos", "16", ObjPersona.Apellidos);
            ObjDatos.DtParametros.Rows.Add(@"@correo_institucional", "16", ObjPersona.Correo_institucional);
            ObjDatos.DtParametros.Rows.Add(@"@contraseña", "16", ObjPersona.Contraseña);
            ObjDatos.DtParametros.Rows.Add(@"@id_rol", "4", ObjPersona.Id_rol);
            

            Ejecutar(ref ObjPersona);
        }

        public void Delete(ref Persona ObjPersona)
        {
            ObjDatos = new ClsDatos()
            {
                NombreTabla = "Persona",
                NombreSP = "[eliminar_persona]",
                Scalar = true
            };
            ObjDatos.DtParametros.Rows.Add(@"@id_persona", "16", ObjPersona.Id_persona);

            Ejecutar(ref ObjPersona);
        }

        public void Read(ref Persona ObjPersona)
        {
            ObjDatos = new ClsDatos()
            {
                NombreTabla = "Persona",
                NombreSP = "[consulta_persona]",
                Scalar = true
            };
            ObjDatos.DtParametros.Rows.Add(@"@id_persona", "16", ObjPersona.Id_persona);

            Ejecutar(ref ObjPersona);
        }

        #endregion
    }
}
