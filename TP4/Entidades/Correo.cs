using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {

        }

        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if(item != null && item.IsAlive) item.Abort();
            }
        }

        public string MostrarDatos(List<Paquete> elemento)
        {
            string retorno = "";
            foreach (Paquete item in elemento)
            {
                retorno += String.Format("{0} para {1} ({2})\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }
             return retorno;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if (item.TrackingID == p.TrackingID && item.DireccionEntrega == p.DireccionEntrega)
                {
                    return c;
                }
            }

            c.paquetes.Add(p);
            Thread t1 = new Thread(p.MockCicloVida);
            c.mockPaquetes.Add(t1);
            t1.Start();
        }
    }
}
