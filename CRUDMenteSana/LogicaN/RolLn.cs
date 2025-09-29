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
    public class RolLn
    {
        #region Variables Privadas
        private ClsDatos ObjDatos = null;

        #endregion

        #region MetodoIndex
        public void Index(ref Rol ObjRol)
        {
            ObjDatos = new ClsDatos()
            {
                NombreTabla = "Rol",
                NombreSP = "[listar_rol]",
                Scalar = false
            };
            Ejecutar(ref ObjRol);
        }
        #endregion

        private void Ejecutar(ref Rol ObjRol)
        {
            ObjDatos.CRUD(ref ObjDatos);
            if (ObjDatos.MensajeErrorOS == null)
            {
                if (ObjDatos.Scalar)
                {
                    ObjRol.ValorScalar = ObjDatos.ValorScalar;
                }

                else
                {
                    ObjRol.DtResultados = ObjDatos.DtResultados.Tables[0];
                    if (ObjRol.DtResultados.Rows.Count == 1)
                    {
                        foreach (DataRow item in ObjRol.DtResultados.Rows)
                        {
                            ObjRol.Id_rol = Convert.ToInt32(item["id_rol"].ToString());
                            ObjRol.Nombre = item["nombre"].ToString();
                        }

                    }
                }
            }
            else
            {
                ObjRol.MensajeError = ObjDatos.MensajeErrorOS;
            }
        }
    }
}
