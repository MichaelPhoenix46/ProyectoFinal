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
    public partial class ConsultaUsuarios : Form
    {
        public ConsultaUsuarios()
        {
            InitializeComponent();
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuario, bool>> filtro = x => true;

            int id;
            switch (FiltrocomboBox.SelectedIndex)
            {
                case 0://ID
                    id = Convert.ToInt32(CriteriotextBox.Text);
                    filtro = x => x.UsuarioId == id
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
                case 3://Telefono
                    filtro = x => x.Telefono.Contains(CriteriotextBox.Text)
                    && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 4://Username
                    filtro = x => x.UserName.Equals(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
                case 5://tipo
                    filtro = x => x.UserName.Contains(CriteriotextBox.Text)
                   && (x.FechaRegistro >= DesdedateTimePicker.Value && x.FechaRegistro <= HastadateTimePicker.Value);
                    break;
            }
            RepositorioBase<Usuario> usrep = new RepositorioBase<Usuario>();

            ConsultadataGridView.DataSource = usrep.GetList(c => true);
            CriteriotextBox.Clear();
        }
    }
}
