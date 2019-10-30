using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
  public class Universidad
  {
    public enum EClases
    {
      Programacion,
      Laboratorio,
      Legislacion,
      SPD
    }

    private List<Alumno> alumnos;
    private List<Jornada> jornada;
    private List<Profesor> instructores;

    public Universidad()
    {
      this.alumnos = new List<Alumno>();
      this.jornada = new List<Jornada>();
      this.instructores = new List<Profesor>();
    }

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

    public List<Jornada> Jornada
    {
      get
      {
        return this.jornada;
      }
      set
      {
        this.jornada = value;
      }
    }

    public List<Profesor> Instructores
    {
      get
      {
        return this.instructores;
      }
      set
      {
        this.instructores = value;
      }
    }


    public Jornada this[int i]
    {
      get
      {
        return this.jornada[i];
      }
      set
      {
        this.jornada[i] = value;
      }
    }
    #endregion

    #region Metodos
    public static bool Guardar(Universidad uni)
    {
      Texto txt = new Texto();
     return txt.Guardar("archivos.log", uni.ToString());
     
    }

    public static bool Leer()
    {
      string aux = "";
      Texto txt = new Texto();
      txt.Guardar("jornada.log", aux);
      return true;
    }

    private string MostrarDatos(Universidad uni)
    {
      StringBuilder sb = new StringBuilder();

      sb.AppendLine("JORNADA: ");

      foreach (Jornada item in uni.jornada)
      {
        sb.AppendLine(item.ToString());
        sb.AppendLine("<------------------------------------------------>");
      }

      return sb.ToString();

    }

    public override string ToString()
    {
      return this.MostrarDatos(this);
    }

    #endregion

    #region Sobrecargas

    public static bool operator ==(Universidad uni, Alumno a)
    {
      foreach (Alumno item in uni.alumnos)
      {
        if (item == a) return true;
      }
      return false;
    }

    public static bool operator !=(Universidad uni, Alumno a)
    {
      return !(uni == a);
    }
    public static bool operator ==(Universidad uni, Profesor p)
    {
      foreach (Profesor item in uni.instructores)
      {
        if (item.DNI == p.DNI) return true;
      }
      return false;
    }

    public static bool operator !=(Universidad uni, Profesor p)
    {
      return !(uni == p);
    }

    public static Profesor operator ==(Universidad uni, Universidad.EClases clase)
    {
      Profesor aux = null;
      foreach (Profesor item in uni.instructores)
      {
        if (item == clase) aux = item;
      }
      if (aux is null) throw new Excepciones.SinProfesorException();
      return aux;
    }

    public static Profesor operator !=(Universidad uni, Universidad.EClases clase)
    {
      Profesor aux = null;
      foreach (Profesor item in uni.instructores)
      {
        if (item != clase) aux = item;
      }
      if (aux is null) throw new Excepciones.SinProfesorException();
      return aux;
    }

    public static Universidad operator +(Universidad uni, Universidad.EClases clase)
    {
      Jornada jor = new Jornada(clase, (uni == clase));
      foreach (Alumno item in uni.alumnos)
      {
        if (item == clase)
        {
          jor.Alumnos.Add(item);
        }
      }
      uni.Jornada.Add(jor);
      return uni;
    }

    public static Universidad operator +(Universidad uni, Alumno a)
    {
      if (uni != a)
      {
        uni.Alumnos.Add(a);
      }
      return uni;
    }

    public static Universidad operator +(Universidad uni, Profesor p)
    {
      if (uni != p)
      {
        uni.Instructores.Add(p);
      }
      return uni;
    }
    #endregion
  }
}
