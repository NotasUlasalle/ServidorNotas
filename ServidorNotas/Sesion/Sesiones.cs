using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNotas.Sesion
{
    public class Sesiones
    {
        #region Singleton
        private static readonly Sesiones instancia = new Sesiones();
        private Sesiones() { }
        
        public static Sesiones Instancia
        {
            get { return instancia; }
        }
        #endregion

        private SynchronizedCollection<Sesion> ColeccionSesiones { get; } = new SynchronizedCollection<Sesion>();
        private static object syncRoot = new object();

        public Guid CrearSesion(string Dni)
        {
            Guid Id = Guid.NewGuid();
            DateTime Fecha = DateTime.Now;

            var sesion = new Sesion()
            {
                Dni = Dni,
                ID = Id,
                Fecha = Fecha
            };

            lock (syncRoot)
            {
                var s = ColeccionSesiones.Where(x => x.Dni == Dni).FirstOrDefault();
                if (s == null)
                    ColeccionSesiones.Add(sesion);
                else
                {
                    s.Fecha = sesion.Fecha;
                    s.ID = sesion.ID;
                }
            }

            return Id;
        }

        public bool BorrarSesion(Guid id)
        {
            bool res = false;
            lock (syncRoot)
            {
                var sesion = ColeccionSesiones.Where(x => x.ID == id).FirstOrDefault();
                res = ColeccionSesiones.Remove(sesion);
            }
            return res;
        }

        public bool RevisarSesion(Guid id)
        {
            var res = false;
            lock (syncRoot)
            {
                res = ColeccionSesiones.Select(x => x.ID == id).FirstOrDefault();
            }
            return res;
        }

        public List<Sesion> GetSesiones()
        {
            return ColeccionSesiones.ToList();
        }
    }
}