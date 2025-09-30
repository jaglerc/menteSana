using EntidadesBD;
using LogicaN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenteSanaPre
{
    public partial class FrmCRUD : Form
    {
        private Persona objPersona = null;
        private Rol objRol = null;
        private readonly PersonaLn objPersonaLn = new PersonaLn();
        private RolLn objRolLn = new RolLn();
        public FrmCRUD()
        {
            InitializeComponent();
            CargarListaClientes();
            ListarRol();
        }

        private void CargarListaClientes()
        {
            objPersona  = new Persona();
            objPersonaLn.Index(ref objPersona);
            if (objPersona.MensajeError == null)
            {
                dgvPersonas.DataSource = objPersona.DtResultados;
            }
            else
            {
                MessageBox.Show(objPersona.MensajeError, "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListarRol()
        {
            objRol = new Rol();
            objRolLn.Index(ref objRol);
            if (objRol.MensajeError == null)
            {
                cmbRol.DataSource = objRol.DtResultados;
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "id_rol";
            }
            else
            {
                MessageBox.Show(objRol.MensajeError, "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCRUD_Load(object sender, EventArgs e)
        {

        }
    }
}
