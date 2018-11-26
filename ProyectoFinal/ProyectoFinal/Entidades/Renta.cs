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
        public decimal Pago { get; set; }
        public decimal Devuelta { get; set; }    //Esta devuelta se refiere a devuelta de dinero  
        public DateTime FechaDevuelta { get; set; }

        public virtual List<RentaDetalle> VideoJuegos { get; set; }

        public Renta()
        {
            RentaId = 0;
            FechaRegistro = DateTime.Now;
            UsuarioId = 0;
            MiembroId = 0;
            Pago = 0;
            Devuelta = 0;
            FechaDevuelta = DateTime.Now;
            VideoJuegos = new List<RentaDetalle>();

        }

        public Renta(int rentaId,DateTime fechaRegistro,int usuarioId,int miembroId,decimal pago,decimal devuelta,DateTime fechaDevuelta, List<RentaDetalle> videoJuegos)
        {
            RentaId = rentaId;
            FechaRegistro = fechaRegistro;
            UsuarioId = usuarioId;
            MiembroId = miembroId;
            Pago = pago;
            Devuelta = devuelta;
            FechaDevuelta = fechaDevuelta;
            VideoJuegos = videoJuegos;
        }
    }

  

}