using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Entidades
{
    
    public class Paquete : IMostrar<Paquete>
    {
        /// <summary>
        /// Delegado para cambiar el estado mediante eventos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(Object sender, EventArgs e);
        
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


        /// <summary>
        /// Mientras que el estado del objeto no sea entregado va a iterar cada 2 segundos y va a cambiar el estado e invocar el evento para informar y cuando finaliza guardarlo en la base de datos con el estado entregado
        /// </summary>
        public void MockCicloVida()
        {
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(2000);
                this.estado++;
                this.InformarEstado.Invoke(this,new EventArgs());
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Muestra los datos del paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Retorna el string con la info</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", ((Paquete)elemento).trackingID,((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Sobreescribe el tostring de la clase paquete
        /// </summary>
        /// <returns>Devuevle un string con la info del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Dos paquetes son iguales si el tracking id es igual
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son igual false si no </returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.trackingID == p2.trackingID);
        }

        /// <summary>
        /// Dos paquetes son iguales si el tracking id es igual
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>true si son igual false si no </returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        #endregion
    }
}
