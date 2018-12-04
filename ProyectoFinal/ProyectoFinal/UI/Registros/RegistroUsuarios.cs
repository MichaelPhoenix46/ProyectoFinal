using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Registros
{
    public partial class RegistroUsuarios : Form
    {
        public RegistroUsuarios()
        {
            InitializeComponent();
            UsuarioradioButton.Checked = true;
            
        }


        private void Limpiar()
        {
            UsuarionumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            NombreUstextBox.Text = string.Empty;
            ContraseñatextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now; 
        }

        private bool ExiteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            Usuario usuario = repositorio.Buscar((int)UsuarionumericUpDown.Value);
            return (usuario != null);
        }


        public void LlenarCampos(Usuario usuario)
        {
            NombretextBox.Text = usuario.Nombre;
            FechadateTimePicker.Value = usuario.FechaRegistro;
            TelefonomaskedTextBox.Text = usuario.Telefono;
            NombreUstextBox.Text = usuario.UserName;
            FechadateTimePicker.Value = usuario.FechaRegistro;
            CedulamaskedTextBox.Text = usuario.Cedula;
            ContraseñatextBox.Text = usuario.Password;

        }

        private Usuario LlenaClase()
        {
            Usuario usuario = new Usuario();
            usuario.UsuarioId = Convert.ToInt32(UsuarionumericUpDown.Value);
            usuario.Nombre = NombretextBox.Text;
            usuario.FechaRegistro = FechadateTimePicker.Value;
            usuario.Telefono = TelefonomaskedTextBox.Text;
            usuario.UserName = NombreUstextBox.Text;
            usuario.FechaRegistro = FechadateTimePicker.Value;
            usuario.Cedula = CedulamaskedTextBox.Text;
            usuario.Password = ContraseñatextBox.Text;
            return usuario;
        }

        private bool Validar()
        {

            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombretextBox.Text) || string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                UsuarioerrorProvider.SetError(NombretextBox, "Campo Vacio ");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text) || string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                UsuarioerrorProvider.SetError(CedulamaskedTextBox, "Campo Vacio ");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombreUstextBox.Text) || string.IsNullOrWhiteSpace(NombreUstextBox.Text))
            {
                UsuarioerrorProvider.SetError(NombreUstextBox, "Campo Vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text) || string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                UsuarioerrorProvider.SetError(TelefonomaskedTextBox, "Campo Vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text) || string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                UsuarioerrorProvider.SetError(CedulamaskedTextBox, "Campo Vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ContraseñatextBox.Text) || string.IsNullOrWhiteSpace(ContraseñatextBox.Text))
            {
                UsuarioerrorProvider.SetError(ContraseñatextBox, "Campo Vacio");
                paso = false;
            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            int id;
            Usuario usuario = new Usuario();

            int.TryParse(UsuarionumericUpDown.Text, out id);
            usuario = repositorio.Buscar(id);

            if (usuario != null)
            {
                MessageBox.Show("usuario Encontrado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarCampos(usuario);
            }
            else
            {
                MessageBox.Show("usuario no Exite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            bool paso = false;
            Usuario usuario = new Usuario();
            if (!Validar())
                return;
            usuario = LlenaClase();
            if (UsuarionumericUpDown.Value == 0)
            {
                if (AdminradioButton.Checked == true)
                    usuario.Tipo = "Administrador";
                else
                    usuario.Tipo = "Usuario";
                paso = repositorio.Guardar(usuario);
            }
            else
            {
                if (!ExiteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No Se Puede Modificar No Exite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (AdminradioButton.Checked == true)
                    usuario.Tipo = "Administrador";
                else
                    usuario.Tipo = "Usuario";
                paso = repositorio.Modificar(usuario);
            }
            if (paso)
            {
                MessageBox.Show("Guardado con Exito", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Miembro> repositorio = new RepositorioBase<Miembro>();
            int id;
            int.TryParse(UsuarionumericUpDown.Text, out id);
            if (!ExiteEnLaBaseDeDatos())
            {
                UsuarioerrorProvider.SetError(UsuarionumericUpDown, "Este Miembro No Exite");
                UsuarionumericUpDown.Focus();
                return;
            }
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Usuario Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se Pudo Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        public static void SoloLetras(KeyPressEventArgs v)
        {
            if (Char.IsLetter(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
            }
        }

        public static void SoloNumero(KeyPressEventArgs v)
        {
            if (Char.IsDigit(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(v.KeyChar))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(v.KeyChar))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo Números");
            }
        }

        private void NombretextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void TelefonomaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }
        private void CedulamaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }
    }
}
