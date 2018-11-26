using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int VideoJuegoId { get; set; }
        public decimal Importe { get; set; }
    }
}
