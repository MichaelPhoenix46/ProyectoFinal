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
using ProyectoFinal.DAL;
using ProyectoFinal.BLL;

namespace ProyectoFinal.UI.Registros
{
    public partial class RegistroMiembro : Form
    {
        public RegistroMiembro()
        {
            InitializeComponent();

        }

        private void Limpiar()
        {
            MiembronumericUpDown.Value = 0;
            NombretextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            FechadateTimePicker.Value = DateTime.Now;
        }

        private bool ExiteEnLaBaseDeDatos()
        {
            RepositorioBase<Miembro> repositorio = new RepositorioBase<Miembro>();
            Miembro miembro = repositorio.Buscar((int)MiembronumericUpDown.Value);
            return (miembro != null);
        }


        public void LlenarCampos(Miembro miembro)
        {
            NombretextBox.Text = miembro.Nombre;
            FechadateTimePicker.Value = miembro.FechaRegistro;
            TelefonomaskedTextBox.Text = miembro.Telefono;
            DirecciontextBox.Text = miembro.Direccion;
            FechadateTimePicker.Value = miembro.FechaRegistro;
            CedulamaskedTextBox.Text = miembro.Cedula;

        }

        private Miembro LlenaClase()
        {
            Miembro miembro = new Miembro();
            miembro.MiembroId = Convert.ToInt32(MiembronumericUpDown.Value);
            miembro.Nombre = NombretextBox.Text;
            miembro.FechaRegistro = FechadateTimePicker.Value;
            miembro.Telefono = TelefonomaskedTextBox.Text;
            miembro.Direccion = DirecciontextBox.Text;
            miembro.FechaRegistro = FechadateTimePicker.Value;
            miembro.Cedula = CedulamaskedTextBox.Text;
            return miembro;
        }

        private bool Validar()
        {

            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombretextBox.Text) || string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                MiembroerrorProvider.SetError(NombretextBox, "Campo Vacio ");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text) || string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                MiembroerrorProvider.SetError(CedulamaskedTextBox, "Campo Vacio ");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text) || string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text))
            {
                MiembroerrorProvider.SetError(DirecciontextBox, "Campo Vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text) || string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text))
            {
                MiembroerrorProvider.SetError(TelefonomaskedTextBox, "Campo Vacio");
                paso = false;
            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Miembro> repositorio = new RepositorioBase<Miembro>();
            int id;
            Miembro miembro = new Miembro();

            int.TryParse(MiembronumericUpDown.Text, out id);
            miembro = repositorio.Buscar(id);

            if (miembro != null)
            {
                MessageBox.Show("Miembro Encontrado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarCampos(miembro);
            }
            else
            {
                MessageBox.Show("Miembro no Exite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Miembro> repositorio = new RepositorioBase<Miembro>();
            int id;
            int.TryParse(MiembronumericUpDown.Text, out id);
            if (!ExiteEnLaBaseDeDatos())
            {
                MiembroerrorProvider.SetError(MiembronumericUpDown, "Este Miembro No Exite");
                MiembronumericUpDown.Focus();
                return;
            }
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Miembro Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se Pudo Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Miembro> repositorio = new RepositorioBase<Miembro>();
            bool paso = false;
            Miembro miembro;
            if (!Validar())
                return;
            miembro = new Miembro();
            miembro = LlenaClase();
            if (MiembronumericUpDown.Value == 0)
            {

                paso = repositorio.Guardar(miembro);
            }
            else
            {
                if (!ExiteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No Se Puede Modificar No Exite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(miembro);
            }
            if (paso)
            {
                MessageBox.Show("Guardado con Exito", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}