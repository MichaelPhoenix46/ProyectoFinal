using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{
    public class RentaDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int RentaId { get; set; }
        public int VideoJuegoId { get; set;  }
        

        [ForeignKey("VideoJuegoId")]
        public virtual VideoJuego VideoJuego { get; set; }

        public RentaDetalle(int detalleId, int rentaId, int videoJuegoId)
        {
            DetalleId = detalleId;
            RentaId = rentaId;
            VideoJuegoId = videoJuegoId;

        }
        public RentaDetalle()
        {
            DetalleId = 0;
            RentaId = 0;


        }


    }

}