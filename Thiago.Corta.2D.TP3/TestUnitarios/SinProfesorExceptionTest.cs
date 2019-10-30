using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;
using Clases_Abstractas;
namespace TestUnitarios
{
    [TestClass]
    public class SinProfesorExceptionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Universidad uni = new Universidad();

            try
            {
                uni += Universidad.EClases.Programacion;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }

        }
    }
}
