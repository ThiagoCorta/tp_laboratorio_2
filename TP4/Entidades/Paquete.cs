using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using

namespace Entidades
{
    
    public class Paquete : IMostrar<Paquete>
    {
        public delegate void DelegadoEstado();
        
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformarEstado;

        #region Propiedades


        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }
        #endregion

        #region Constructores
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingId;
            this.estado = EEstado.Ingresado;
        }

        #endregion

        #region Metodos

        public void MockCicloVida()
        {
            
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(400);
                this.estado++;
                this.InformarEstado += ;
                this.InformarEstado.Invoke();
                //TO DO : Mostrar estado actual por el evento informar estado
            }
            // TO DO: guardar datos de paquete en la bd

        }

        public string MostrarDatos(Paquete elemento)
        {
            return String.Format("{0} para {1}", elemento.trackingID,elemento.direccionEntrega);
        }


        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion
    }
}
