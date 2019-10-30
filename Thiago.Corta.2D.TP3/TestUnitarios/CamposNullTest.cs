using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Clases_Abstractas;

namespace TestUnitarios
{
    [TestClass]
    public class CamposNullTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Profesor p1 = new Profesor(1, "Thiago", "Corta", "42096150", Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.Laboratorio, p1);
            uni += a1;
            uni += p1;
            uni.Jornada.Add(j1);
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.DNI);
            Assert.IsNotNull(a1.Nacionalidad);
            Assert.IsNotNull(p1.Nombre);
            Assert.IsNotNull(p1.Apellido);
            Assert.IsNotNull(p1.DNI);
            Assert.IsNotNull(p1.Nacionalidad);
            Assert.IsNotNull(j1.Alumnos);
            Assert.IsNotNull(j1.Clase);
            Assert.IsNotNull(j1.Instructor);
            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornada);

        }
    }
}
