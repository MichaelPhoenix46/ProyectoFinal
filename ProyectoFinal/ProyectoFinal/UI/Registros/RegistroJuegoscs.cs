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
    public partial class RegistroJuegoscs : Form
    {
        public RegistroJuegoscs()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            JuegonumericUpDown.Value = 0;
            TitulotextBox.Text = string.Empty;
            DescripciontextBox.Text = string.Empty;
            LanzamientodateTimePicker.Value = DateTime.Now;
            PlataformacomboBox.Text = string.Empty;
            GenerotextBox.Text = string.Empty;
            CantidadnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;

        }

        private bool ExiteEnLaBaseDeDatos()
        {
            RepositorioBase<VideoJuego> repositorio = new RepositorioBase<VideoJuego>();
            VideoJuego videoJuego = repositorio.Buscar((int)JuegonumericUpDown.Value);
            return (videoJuego != null);
        }

        public void LlenarCampos(VideoJuego videoJuego)
        {
            TitulotextBox.Text = videoJuego.Titulo;
            FechadateTimePicker.Value = videoJuego.FechaRegistro;
            PlataformacomboBox.Text = videoJuego.Plataforma;
            LanzamientodateTimePicker.Value = videoJuego.Lanzamiento;
            DescripciontextBox.Text = videoJuego.Descripcion;
            GenerotextBox.Text = videoJuego.Genero;
            CantidadnumericUpDown.Value = videoJuego.CantidadEjemplares;

        }

        private VideoJuego LlenaClase()
        {
            VideoJuego videoJuego = new VideoJuego();
            videoJuego.VideoJuegoId = Convert.ToInt32(JuegonumericUpDown.Value);
            videoJuego.Titulo = TitulotextBox.Text;
            videoJuego.FechaRegistro = FechadateTimePicker.Value;
            videoJuego.Descripcion = DescripciontextBox.Text;
            videoJuego.Genero = GenerotextBox.Text;
            videoJuego.Lanzamiento = LanzamientodateTimePicker.Value;
            videoJuego.Plataforma = PlataformacomboBox.Text;
            return videoJuego;
        }
        private bool Validar()
        {

            bool paso = true;
            if (string.IsNullOrWhiteSpace(TitulotextBox.Text) || string.IsNullOrWhiteSpace(TitulotextBox.Text))
            {
                videoJuegoserrorProvider.SetError(TitulotextBox, "Campo Vacio ");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DescripciontextBox.Text) || string.IsNullOrWhiteSpace(DescripciontextBox.Text))
            {
                videoJuegoserrorProvider.SetError(DescripciontextBox, "Campo Vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(PlataformacomboBox.Text) || string.IsNullOrWhiteSpace(PlataformacomboBox.Text))
            {
                videoJuegoserrorProvider.SetError(PlataformacomboBox, "Campo Vacio");
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(GenerotextBox.Text) || string.IsNullOrWhiteSpace(GenerotextBox.Text))
            {
                videoJuegoserrorProvider.SetError(GenerotextBox, "Campo Vacio");
                paso = false;
            }
            if (CantidadnumericUpDown.Value == 0)
            {
                videoJuegoserrorProvider.SetError(CantidadnumericUpDown, "Campo Vacio");
                paso = false;
            }
            return paso;
            }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<VideoJuego> repositorio = new RepositorioBase<VideoJuego>();
            bool paso = false;
            VideoJuego videoJuego;
            if (!Validar())
                return;
            videoJuego = new VideoJuego();
            videoJuego = LlenaClase();
            if (JuegonumericUpDown.Value == 0)
            {

                paso = repositorio.Guardar(videoJuego);
            }
            else
            {
                if (!ExiteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No Se Puede Modificar No Exite", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(videoJuego);
            }
            if (paso)
            {
                MessageBox.Show("Guardado con Exito", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No Se Puede Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Eliminarbutton_Click_1(object sender, EventArgs e)
        {
            RepositorioBase<VideoJuego> repositorio = new RepositorioBase<VideoJuego>();
            int id;
            int.TryParse(JuegonumericUpDown.Text, out id);
            if (!ExiteEnLaBaseDeDatos())
            {
                videoJuegoserrorProvider.SetError(JuegonumericUpDown, "Este Juego No Exite");
                JuegonumericUpDown.Focus();
                return;
            }
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Juego Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se Pudo Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

