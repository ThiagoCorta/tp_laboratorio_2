using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class AlumnoRepeteidoExceptionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Thiago", "Corta", "42096150",
            Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(1, "Thiago", "Corta", "42096150",
            Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            uni += a1;

            try
            {
                uni += a2;
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }

           
        }
    }
}
