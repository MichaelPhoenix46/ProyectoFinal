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
    }
}
