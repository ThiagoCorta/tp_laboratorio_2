using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Excepciones;
using Clases_Abstractas;

namespace TestUnitarios
{
    [TestClass]
    public class NacionalidadInvalidaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string dni = "42096150";

            try
            {
                Alumno thiago = new Alumno(1, "Thiago", "Corta", dni, Clases_Abstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            

        }
    }
}
