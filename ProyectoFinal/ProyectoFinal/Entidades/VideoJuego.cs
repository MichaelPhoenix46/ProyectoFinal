using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Entidades
{

    public class VideoJuego
    {
        [Key]
        public int VideoJuegoId { get; set; }
        public string Titulo { get; set; }
        public String Descripcion { get; set; }
        public String Plataforma { get; set; }
        public DateTime Lanzamiento { get; set; }
        public String Genero { get; set; }
        public int CantidadJugadores{ get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public string Desarrolladores { get; set; }
        public int CantidadEjemplares { get; set; }


        public VideoJuego()
        {
            VideoJuegoId = 0;
            Titulo = string.Empty;
            Descripcion = string.Empty;
            Plataforma = string.Empty;
            Lanzamiento = DateTime.Now;
            Genero = string.Empty;
            CantidadJugadores = 0;
            FechaDeRegistro = DateTime.Now;
            Desarrolladores = string.Empty;
            CantidadEjemplares = 0;
        }

        public VideoJuego(int videoJuegoId, string titulo, string descripcion, string plataforma, DateTime lanzamiento, string genero,int cantidadJugadores,DateTime fechaRegistro,string desarrolladores,int cantidadEjemplares)
        {
            VideoJuegoId = videoJuegoId;
            Titulo = titulo;
            Descripcion = descripcion;
            Plataforma = plataforma;
            Lanzamiento = lanzamiento;
            Genero = genero;
            CantidadJugadores = cantidadJugadores;
            FechaDeRegistro = fechaRegistro;
            Desarrolladores = desarrolladores;
            CantidadEjemplares = cantidadEjemplares;
        }
    }
}