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
        public int VideoJuegoId { get; set; }
        public string Titulo { get; set; }
        public int Cantidad { get; set; }
        [NotMapped]
        public decimal Importe { get; set; }

        public RentaDetalle(int detalleId, int rentaId, int videoJuegoId, string titulo, int cantidad, decimal importe)
        {
            DetalleId = detalleId;
            RentaId = rentaId;
            VideoJuegoId = videoJuegoId;
            Titulo = titulo;
            Cantidad = cantidad;
            Importe = importe;

        }
        public RentaDetalle()
        {
            DetalleId = 0;
            RentaId = 0;
            VideoJuegoId = 0;
            Titulo = string.Empty;
            Cantidad = 0;
            Importe = 0;

        }


    }

}