﻿using ProyectoFinal.DAL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL
{
    public class RentaBLL
    {
        public static Usuario usuario = new Usuario();
        public static bool Guardar(Renta renta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.renta.Add(renta) != null)
                {
                    foreach (var item in renta.Detalles)
                    {

                        contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares = contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares - 1;
                    }
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Renta renta = contexto.renta.Find(id);
                if (renta != null)
                {
                    foreach (var item in renta.Detalles)
                    {
                        contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares = contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares + 1;
                    }
                    renta.Detalles.Count();
                    contexto.renta.Remove(renta);
                }
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }

            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static Renta Buscar(int id)
        {
            Renta renta = new Renta();
            Contexto contexto = new Contexto();
            try
            {
                renta = contexto.renta.Find(id);
                if (renta != null)
                {
                    renta.Detalles.Count();
                    foreach (var item in renta.Detalles)
                    {
                        string s = item.VideoJuego.Titulo;
                    }
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return renta;
        }

        public static bool Modificar(Renta renta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var rent = RentaBLL.Buscar(renta.RentaId);
                if (rent != null)
                {
                    foreach (var item in renta.Detalles)
                    {
                        contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares = contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares + 1;
                        if (!renta.Detalles.ToList().Exists(v => v.RentaId == item.RentaId))
                        {
                            item.VideoJuego = null;
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    foreach (var item in renta.Detalles)
                    {
                        contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares = contexto.videoJuego.Find(item.VideoJuegoId).CantidadEjemplares - 1;
                        var estado = item.RentaId > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }
                }
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception) { throw; }
            return paso;
        }
        public static List<Renta> GetList(Expression<Func<Renta, bool>> rentas)
        {
            List<Renta> renta = new List<Renta>();
            Contexto contexto = new Contexto();
            try
            {
                renta = contexto.renta.Where(rentas).ToList();
                foreach (var item in renta)
                {
                    item.Detalles.Count();
                }
            }
            catch (Exception)
            { throw; }
            finally
            { contexto.Dispose(); }
            return renta;
        }

        public static void UsuarioLogin(string nombre, int id)
        {
            usuario.UsuarioId = id;
            usuario.Nombre = nombre;
        }
        public static Usuario getUsuario()
        {
            return usuario;
        }

    }
}
