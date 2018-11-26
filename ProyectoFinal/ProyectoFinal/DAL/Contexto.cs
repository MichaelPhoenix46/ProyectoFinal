using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Miembro> miembros { get; set; }
        public DbSet<Renta> rentas { get; set; }
        public DbSet<RentaDetalle> rentadetalle { get; set; }


        public Contexto() : base("ConStr")
        { }
    }
}