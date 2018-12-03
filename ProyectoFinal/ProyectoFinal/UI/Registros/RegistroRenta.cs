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
    public partial class RegistroRenta : Form
    {
        public RegistroRenta()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void LlenarComboBox()
        {
            RepositorioBase<VideoJuego> juegorep = new RepositorioBase<VideoJuego>();
            JuegocomboBox.DataSource = juegorep.GetList(c => true);
            JuegocomboBox.ValueMember = "VideoJuegoId";
            JuegocomboBox.DisplayMember = "Titulo";

            RepositorioBase<Miembro> miembrorep = new RepositorioBase<Miembro>();
            MiembrocomboBox.DataSource = miembrorep.GetList(x => true);
            MiembrocomboBox.ValueMember = "MiembroId";
            MiembrocomboBox.DisplayMember = "Nombre";

        }

        private void Limpiar()
        {
            RentaerrorProvider.Clear();
            RentanumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            MiembrocomboBox.Text = string.Empty;
            DevueltadateTimePicker.Value = DateTime.Today.AddDays(7);
            ImportetextBox.Text = string.Empty;
            PagotextBox.Text = string.Empty;
            DevueltatextBox.Text = string.Empty;
            JuegocomboBox.Text = string.Empty;

        }
        private Renta LlenaClase()
        {
            Renta renta = new Renta();
            renta.Pago = Convert.ToDecimal(PagotextBox.Text);
            renta.Devuelta = Convert.ToDecimal(DevueltatextBox.Text);
            renta.FechaRegistro = FechadateTimePicker.Value;
            renta.FechaDevuelta = DevueltadateTimePicker.Value;
            renta.MiembroId = Convert.ToInt32(MiembrocomboBox.SelectedValue);
            renta.RentaId = Convert.ToInt32(RentanumericUpDown.Value);


            return renta;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                errorProvider1.SetError(DescripcionTextBox,
                    "Llenar Campo Descripcion");
                paso = false;
            }
            if (string.IsNullOrEmpty(CostotextBox.Text))
            {
                errorProvider1.SetError(CostotextBox,
                    "Llenar Campo Articulo");
                paso = false;
            }
            if (string.IsNullOrEmpty(PreciotextBox.Text))
            {
                errorProvider1.SetError(PreciotextBox,
                    "Llenar Campo Precio");
                paso = false;
            }

            return paso;
        }

    }
}
