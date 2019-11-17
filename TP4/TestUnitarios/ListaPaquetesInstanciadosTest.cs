using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
    [TestClass]
    public class ListaPaquetesInstanciadosTest
    {
        [TestMethod]
        public void InstanciarLista()
        {
            Correo cr = new Correo();
            Assert.IsNotNull(cr.Paquetes);
        }
    }
}
