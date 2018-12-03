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
        List<RentaDetalle> Detalle = new List<RentaDetalle>();
        
        public int Index { get; set; }
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

            if (string.IsNullOrEmpty(PagotextBox.Text))
            {
                RentaerrorProvider.SetError(PagotextBox,
                    "Llenar Campo Pago");
                paso = false;
            }
            if (string.IsNullOrEmpty(MiembrocomboBox.Text))
            {
                RentaerrorProvider.SetError(MiembrocomboBox,
                    "Llenar Campo Miembro");
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
            Renta renta;
            bool paso = false;

            if (Validar())
            {

                renta = LlenaClase();


                if (RentanumericUpDown.Value == 0)
                {
                    paso = RentaBLL.Guardar(renta);
                    MessageBox.Show("Guardado!!", "Exito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int id = Convert.ToInt32(RentanumericUpDown.Value);
                    renta = RentaBLL.Buscar(id);

                    if (renta != null)
                    {
                        paso = RentaBLL.Modificar(LlenaClase());
                        MessageBox.Show("Modificado!!", "Exito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Id no existe", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error!!", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (paso)
            {
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RentanumericUpDown.Value);

            Renta renta = RentaBLL.Buscar(id);
            if (renta != null)
            {
                if (RentaBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                    MessageBox.Show("No se pudo eliminar!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No existe!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(RentanumericUpDown.Value);
            Renta renta = RentaBLL.Buscar(id);
            
            if (renta != null)
            {
                MiembrocomboBox.SelectedValue = renta.MiembroId;
                DevueltadateTimePicker.Value = renta.FechaDevuelta;  
                PagotextBox.Text = renta.Pago.ToString();
                DevueltatextBox.Text = renta.Devuelta.ToString() ;
                FechadateTimePicker.Value = renta.FechaRegistro;

            }
            else
                RentaerrorProvider.SetError(RentanumericUpDown, "No Existe");
        }

        private void CargarGrid()
        {
            DetalledataGridView.DataSource = null;
            DetalledataGridView.DataSource = Detalle;
        }

        public bool ValidarRemover()
        {
            bool paso = true;
            if (DetalledataGridView.SelectedRows == null)
            {
                paso = false;
            }
            return paso;
        }
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(Index);
                CargarGrid();
                Index = -1;
            }
        }

        private void DetalledataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Index = e.RowIndex;
        }



        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.DataSource != null)
                this.Detalle = (List<RentaDetalle>)DetalledataGridView.DataSource;
            this.Detalle.Add(new RentaDetalle(
                0,
                rentaId: (int)RentanumericUpDown.Value,
                videoJuegoId: (int)JuegocomboBox.SelectedValue

                ));
            RentaerrorProvider.Clear();
            CargarGrid();
            foreach (var item in Detalle)
            {
                ImportetextBox.Text += Convert.ToDecimal(50);
                
            }
            
        }
    }
}

