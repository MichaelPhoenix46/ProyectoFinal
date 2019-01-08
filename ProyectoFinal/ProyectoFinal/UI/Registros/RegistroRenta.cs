using ProyectoFinal.BLL;
using ProyectoFinal.DAL;
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
            DevueltadateTimePicker.Value = DateTime.Now.AddDays(7);
        }


        private bool Validar()
        {
            
            bool paso = true;
            if (string.IsNullOrWhiteSpace(MiembrocomboBox.Text) || string.IsNullOrWhiteSpace(MiembrocomboBox.Text))
            {
                RentaerrorProvider.SetError(MiembrocomboBox, "Campo Vacio ");
                paso = false;
            }
            /*if ((FechadateTimePicker.Value >= DateTime.Today) || FechadateTimePicker.Value <= DateTime.Today))
            {
                RentaerrorProvider.SetError(FechadateTimePicker, "Campo Vacio");
                paso = false;
            }*/
            if (PagonumericUpDown.Value<=0) 
            {
                RentaerrorProvider.SetError(PagonumericUpDown, "El pago no deberia ser 0 o negativo");
                paso = false;
            }
            if (ImportenumericUpDown.Value==0) 
            {
                RentaerrorProvider.SetError(ImportenumericUpDown, "Debe agregar al menos un detalle");
                paso = false;
            }
            if(DevueltanumericUpDown.Value < 0)
            {
                RentaerrorProvider.SetError(DevueltanumericUpDown, "La devuelta no debe ser menor que 0");
                paso = false;
            }


            if ((string.IsNullOrWhiteSpace(JuegocomboBox.Text)) || (string.IsNullOrEmpty(JuegocomboBox.Text)))
            {
                RentaerrorProvider.SetError(JuegocomboBox, "Debe seleccionar al menos un juego");
                paso = false;
            }





            return paso;
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
            ImportenumericUpDown.Value = 0;
            PagonumericUpDown.Value = 0;
            DevueltanumericUpDown.Value = 0;
            JuegocomboBox.Text = string.Empty;
            DetalledataGridView.DataSource = null;

        }

        public void LlenarCampos(Renta renta)
        {
            DevueltadateTimePicker.Value = renta.FechaDevuelta;
            FechadateTimePicker.Value = renta.FechaRegistro;
            DevueltanumericUpDown.Value = renta.Devuelta;
            PagonumericUpDown.Value = renta.Pago;
            ImportenumericUpDown.Value = renta.Importe;

        }

        private Renta LlenaClase()
        {
            Renta renta = new Renta
            {
                Pago = PagonumericUpDown.Value,
                Devuelta = DevueltanumericUpDown.Value,
                FechaRegistro = FechadateTimePicker.Value,
                FechaDevuelta = DevueltadateTimePicker.Value,
                MiembroId = Convert.ToInt32(MiembrocomboBox.SelectedValue),
                RentaId = Convert.ToInt32(RentanumericUpDown.Value),
                Importe = ImportenumericUpDown.Value,
                Detalles = this.Detalle
            };

            /*foreach (DataGridViewRow item in DetalledataGridView.Rows)
            {

                Detalle.Add
                (Convert.ToInt32(item.Cells["DetalleId"].Value),
                renta.RentaId,
                Convert.ToInt32(item.Cells["VideoJuegoId"].Value),
                Convert.ToString(item.Cells["Titulo"].Value),
                Convert.ToString(item.Cells["descripcion"].Value),
                ToInt(item.Cells["cantidad"].Value),
                ToDecimal(item.Cells["monto"].Value)
                  );


            }*/
            return renta;

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
                PagonumericUpDown.Value = renta.Pago;
                DevueltanumericUpDown.Value = renta.Devuelta;
                FechadateTimePicker.Value = renta.FechaRegistro;
                CargarGrid();

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
                videoJuegoId: (int)JuegocomboBox.SelectedValue,
                titulo:(string) BLL.RentaBLL.RetornarNombre(JuegocomboBox.Text)

                )
                
                );
            
            RentaerrorProvider.Clear();
            CargarGrid();
            DetalledataGridView.Columns.Remove("VideoJuego");
            Detalle.Count();
            ImportenumericUpDown.Text = (Convert.ToString(Detalle.Count() * 50));
        }

        private void Eliminarjbutton_Click(object sender, EventArgs e)
        {
            if (DetalledataGridView.Rows.Count > 0 && DetalledataGridView.CurrentRow != null)
            {
                Detalle.RemoveAt(DetalledataGridView.CurrentRow.Index);
                CargarGrid();
                
            }
            ImportenumericUpDown.Text = Convert.ToString(Detalle.Count() * 50);
           
        }


        private void PagonumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            DevueltanumericUpDown.Value = PagonumericUpDown.Value - ImportenumericUpDown.Value;
        }

        private void PagonumericUpDown_KeyUp(object sender, KeyPressEventArgs e)
        {
            PagonumericUpDown_ValueChanged(this.PagonumericUpDown, new EventArgs());

        }

        private void DevueltanumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ImportenumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void CantidadtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistroRenta_Load(object sender, EventArgs e)
        {

        }
    }
}


