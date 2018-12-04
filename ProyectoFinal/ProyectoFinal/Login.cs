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

namespace ProyectoFinal
{
    public partial class Login : Form
    {
      
        public Login()
        {
            InitializeComponent();
        }
        private void CleanProvider()
        {
            LogInerrorProvider.Clear();
        }


        private void logInbutton_Click(object sender, EventArgs e)
        {
            int paso=0;
            Expression<Func<Usuario, bool>> filtrar = x => true;
            List<Usuario> user = new List<Usuario>();

            CleanProvider();
            if (UsertextBox.Text == string.Empty)
            {
                paso = 1;
                LogInerrorProvider.SetError(UsertextBox, "Incorrecto");

            }
            if (passtextBox.Text == string.Empty)
            {
                paso = 1;
                LogInerrorProvider.SetError(passtextBox, "Incorrecto");

            }
            if (paso == 1)
            {
                MessageBox.Show("Campos Vacios!!");
                return;
            }
            if ((UsertextBox.Text == "Admin") && (passtextBox.Text == "123456"))
            {



                MainForm ver = new MainForm();
                ver.Show();
                this.Hide();

                
            }
            else
            {
                filtrar = t => t.UserName.Equals(UsertextBox.Text);
                RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
                user = repositorio.GetList(filtrar);

                if (user.Exists(x => x.UserName == UsertextBox.Text) && user.Exists(x => x.Password == passtextBox.Text))
                {
                    this.Hide();
                    MainForm ver = new MainForm();
                    ver.Show();

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña incorrecta!!");
                    LogInerrorProvider.SetError(passtextBox, "Incorrecto");
                    LogInerrorProvider.SetError(UsertextBox, "Incorrecto");
                }
            }

           
        }

    }
}

