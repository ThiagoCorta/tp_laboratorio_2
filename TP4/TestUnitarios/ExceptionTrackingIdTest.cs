﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class ExceptionTrackingIdTest
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void DosPaquetesDelMismoTipo()
        {
            Correo cr = new Correo();
            Paquete p1 = new Paquete("utn", "12345678");
            Paquete p2 = new Paquete("utn2", "12345678");
            cr += p1;
            cr += p2;
            cr.FinEntregas();
        }
    }
}
