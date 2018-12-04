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

            Usuario usuario = new Usuario();
            bool paso;
            usuario.UsuarioId = 1;
            usuario.Nombre = "Michael";
            usuario.Telefono = "809-333-3333";
            usuario.Password = "lol";
            usuario.Cedula = "000-0000000-0";
            usuario.Tipo = "Administrador";
            usuario.FechaRegistro = DateTime.Now;
            RepositorioBase<Usuario> repositorio = new RepositorioBase<Usuario>();
            paso = repositorio.Guardar(usuario);
            Assert.AreEqual(paso,true);
        }

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