using ProyectoFinal.UI.Consultas;
using ProyectoFinal.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void consultaDeJuegosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaJuegos c = new ConsultaJuegos();
            c.Show();
        }

        private void registroDeJuegosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroJuegoscs r = new RegistroJuegoscs();
            r.Show();

        }

        private void registroDeMiembrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroMiembro r = new RegistroMiembro();
            r.Show();
        }

        private void registroDeRentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroRenta r = new RegistroRenta();
            r.Show();
        }

        private void registroDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroUsuarios r = new RegistroUsuarios();
            r.Show();
        }

        private void consultaDeMiembrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaMiembros c = new ConsultaMiembros();
            c.Show();
        }

        private void consultaDeRentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaRentas c = new ConsultaRentas();
            c.Show();
        }
    }
}
