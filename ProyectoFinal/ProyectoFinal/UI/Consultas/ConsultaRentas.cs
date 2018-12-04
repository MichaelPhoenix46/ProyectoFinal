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
    public partial class ConsultaRentas : Form
    {
        public ConsultaRentas()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Renta, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://RentaId
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.RentaId == id
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 1:// MiembroId
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.MiembroId == id
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;

            }
            RepositorioBase<Renta> rep = new RepositorioBase<Renta>();

            ConsultadataGridView.DataSource = rep.GetList(c => true);
            CriteriotextBox.Clear();

        }
    }
}
