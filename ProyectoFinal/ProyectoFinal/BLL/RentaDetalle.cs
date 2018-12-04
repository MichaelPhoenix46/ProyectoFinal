using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProyectoFinal.BLL
{
    public class RentaDetalleBLL
    {
        public static List<RentaDetalle> GetList(Expression<Func<RentaDetalle, bool>> expression)
        {
            List<RentaDetalle> renta = new List<RentaDetalle>();
            Contexto contexto = new Contexto();
            try
            {
                renta = contexto.rentaDetalles.Where(expression).ToList();
                renta.ToList().Count();
            }
            catch (Exception) { throw; }
            return renta;
        }


    }
}