using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class Renta
    {
        [Key]
        public int RentaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioId { get; set; }
        public int MiembroId { get; set; }
        public DateTime FechaDevuelta { get; set; }
        public decimal Devuelta { get; set; }    //Esta devuelta se refiere a devuelta de dinero
        public decimal Pago { get; set; }


        public virtual List<RentaDetalle> Detalles { get; set; }

        public Renta()
        {
            this.RentaId = 0;
            this.FechaRegistro = DateTime.Now;
            this.UsuarioId = 0;
            this.MiembroId = 0;
            this.FechaDevuelta = DateTime.Now;
            this.Devuelta = 0;
            this.Pago = 0;
            Detalles = new List<RentaDetalle>();
            

        }

        public Renta(int rentaId, DateTime fechaRegistro, int usuarioId, int miembroId, DateTime fechaDevuelta,decimal devuelta,decimal pago, List<RentaDetalle> detalles)
        {
            RentaId = rentaId;
            FechaRegistro = fechaRegistro;
            UsuarioId = usuarioId;
            MiembroId = miembroId;
            FechaDevuelta = fechaDevuelta;
            Devuelta = devuelta;
            Pago = pago;
            Detalles = detalles;
        }
    }



}