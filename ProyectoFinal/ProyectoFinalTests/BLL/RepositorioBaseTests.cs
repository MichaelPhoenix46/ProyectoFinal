using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {

        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            BLL.RepositorioBase<Usuario> repositorio = new BLL.RepositorioBase<Usuario>();
            Usuario usuario = new Usuario();
            bool paso;
            usuario.UsuarioId = 1;
            usuario.UserName = "hola";
            usuario.Nombre = "Michael";
            usuario.Telefono = "8093860441";
            usuario.Password = "lol";
            usuario.Cedula = "40228082463";
            usuario.Tipo = "Administrador";
            usuario.FechaRegistro = DateTime.Now;
            paso = repositorio.Guardar(usuario);
            Assert.Equals(paso, true);
        }

       /* private Usuario getUsuario()
        {


            Usuario usuario = new Usuario();
            bool paso;
            usuario.UsuarioId = 1;
            usuario.UserName = "hola";
            usuario.Nombre = "Michael";
            usuario.Telefono = "8093333333";
            usuario.Password = "lol";
            usuario.Cedula = "00000000000";
            usuario.Tipo = "Administrador";
            usuario.FechaRegistro = DateTime.Now;
            return usuario;
        }*/

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }
    }
}