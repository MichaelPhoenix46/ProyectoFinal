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
    public partial class ConsultaMiembros : Form
    {
        public ConsultaMiembros()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Miembro, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.MiembroId == id
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 1:// Nombre
                    filtro = x => x.Nombre.Contains(CriteriotextBox.Text)
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 2:// Cedula
                    filtro = x => x.Cedula.Equals(CriteriotextBox.Text)
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 3://direccion
                    filtro = x => x.Direccion.Contains(CriteriotextBox.Text)
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 4://Telefono
                    filtro = x => x.Telefono.Equals(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
            }
            RepositorioBase<Miembro> miemrep = new RepositorioBase<Miembro>();

            ConsultadataGridView.DataSource = miemrep.GetList(c => true);
            CriteriotextBox.Clear();
        }
    }
}
