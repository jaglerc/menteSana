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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            objPersona = new Persona()
            {
                Id_persona = txtDocumento.Text,
                Nombres = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Correo_institucional = txtCorreo.Text,
                Contraseña = txtContraseña.Text,
                Id_rol = Convert.ToInt32(cmbRol.SelectedValue.ToString()),
            };
            objPersonaLn.Create(ref objPersona);
            CargarListaClientes();
            if (objPersona.MensajeError == null)
            {
                MessageBox.Show("El cliente: " + objPersona.Nombres + " Fue agregado con éxito " + MessageBoxButtons.OK + MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El cliente: " + objPersona.Nombres + " NO fue agregado con éxito " + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
            cmbRol.SelectedValue = 1;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objPersona = new Persona()
            {
                Id_persona = txtDocumento.Text,
                Nombres = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Correo_institucional = txtCorreo.Text,
                Contraseña = txtContraseña.Text,
                Id_rol = Convert.ToInt32(cmbRol.SelectedValue.ToString()),
            };
            objPersonaLn.Update(ref objPersona);

            if (objPersona.MensajeError == null)
            {
                MessageBox.Show("la persona: " + objPersona.Nombres + " Fue actualizado con éxito " + MessageBoxButtons.OK + MessageBoxIcon.Information);
                CargarListaClientes();
            }
            else
            {
                MessageBox.Show("la persona: " + objPersona.Nombres + " NO fue actualizado con éxito " + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
            cmbRol.SelectedValue = 1;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objPersona = new Persona()
            {
                Id_persona = txtDocumento.Text,

            };
            objPersonaLn.Delete(ref objPersona);
            CargarListaClientes();

            if (objPersona.MensajeError == null)
            {
                MessageBox.Show("El cliente: " + objPersona.Nombres + "Fue eliminado con éxito" + MessageBoxButtons.OK + MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El cliente: " + objPersona.Nombres + "NO fue eliminado con éxito " + MessageBoxButtons.OK + MessageBoxIcon.Error);
            }
            txtDocumento.Text = "";
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
        }
    }
}
