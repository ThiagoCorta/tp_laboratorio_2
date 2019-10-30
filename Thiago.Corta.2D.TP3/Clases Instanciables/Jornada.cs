using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
  public class Jornada
  {
    private List<Alumno> alumnos;
    private Universidad.EClases clase;
    private Profesor instructor;

    #region Constructores
    public Jornada()
    {
      this.alumnos = new List<Alumno>();
    }

    public Jornada(Universidad.EClases clase, Profesor instructor) : this()
    {
      this.clase = clase;
      this.instructor = instructor;
    }
    #endregion

    #region Propiedades
    public List<Alumno> Alumnos
    {
      get
      {
        return this.alumnos;
      }
      set
      {
        this.alumnos = value;
      }
    }

    public Universidad.EClases Clase
    {
      get
      {
        return this.clase;
      }
      set
      {
        this.clase = value;
      }
    }

    public Profesor Instructor
    {
      get
      {
        return this.instructor;
      }
      set
      {
        this.instructor = value;
      }
    }
    #endregion

    #region Metodos

    public static bool Guardar(Jornada jornada)
    {
      Texto txt = new Texto();
      return txt.Guardar("jornada.log", jornada.ToString());
    }

    public static string Leer()
    {
      string aux = "";
      Texto txt = new Texto();
      txt.Guardar("jornada.log", aux);
      return aux;
    }

    public override string ToString()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append($"CLASE DE {this.clase} POR {this.instructor.ToString()}");
      sb.AppendLine("ALUMNOS :");
      foreach (Alumno item in this.alumnos)
      {
        sb.Append(item.ToString());
      }
      return sb.ToString();
    }
    #endregion

    #region Sobrecargas
    public static bool operator ==(Jornada j, Alumno a)
    {
      foreach (Alumno item in j.alumnos)
      {
        if (item.DNI == a.DNI) return true;
      }
      return false;
    }

    public static bool operator !=(Jornada j, Alumno a)
    {
      return !(j == a);
    }

    public static Jornada operator +(Jornada j, Alumno a)
    {
      if (j != a) j.alumnos.Add(a);
      return j;
    }

    #endregion
  }
}
