using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consultas
{
    public partial class ConsultaJuegos : Form
    {
        public ConsultaJuegos()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            Expression<Func<VideoJuego, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.VideoJuegoId == id
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 1:// Titulo
                    filtro = x => x.Titulo.Contains(CriteriotextBox.Text)
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 2:// Descripcion
                    filtro = x => x.Descripcion.Contains(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 3://Plataforma 
                    filtro = x => x.Plataforma.Contains(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 4://Lanzamiento
                    CriteriotextBox.ReadOnly = true;
                    DesdedateTimePicker.Visible = false;
                    HastadateTimePicker.Visible = false;
                    filtro = x => x.Lanzamiento.Year == LanzamientodateTimePicker.Value.Year;
                    break;
                case 5://Genero
                    filtro = x => x.Genero.Contains(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 6://Genero
                    filtro = x => x.Desarrolladores.Contains(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 7://Genero
                    filtro = x => x.Desarrolladores.Contains(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 8://Cantidad de ejemplares
                    filtro = x => x.CantidadEjemplares.Equals(Convert.ToInt32(CriteriotextBox))
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
            }
            RepositorioBase<VideoJuego> juegorep = new RepositorioBase<VideoJuego>();

            ConsultadataGridView.DataSource = juegorep.GetList(c => true);
            CriteriotextBox.Clear();
        }
    }
}
