using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;
namespace TestUnitarios
{
    [TestClass]
    public class ValidarNumericoTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Alumno thiago = new Alumno(1, "Thiago", "Corta", "42096150", Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            try
            {
                thiago.DNI = -23212323;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
    }
}
