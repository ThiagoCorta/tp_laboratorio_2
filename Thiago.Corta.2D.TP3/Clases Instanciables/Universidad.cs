using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

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
    /// <summary>
    /// Guarda toda la info de la universidad en un archivo
    /// </summary>
    /// <param name="uni"></param>
    /// <returns>true si pudo guardarlo false si no pudo</returns>
    public static bool Guardar(Universidad uni)
    {
      Xml<Universidad> xml = new Xml<Universidad>();
      try
      {
        if(xml.Guardar("archivos.log", uni))
        {
          return true;
        }
      }
      catch (Exception e)
      {
        throw new ArchivosException(e);
      }
      return false;
    }
    /// <summary>
    /// Lee de un archivo toda la info que tiene escrita.
    /// </summary>
    /// <returns>Un string con todo el texto que tiene la universidad</returns>
    public static bool Leer()
    {
      Universidad aux;
      Xml<Universidad> xml = new Xml<Universidad>();
      try
      {
        if(xml.Leer("archivos.log", out aux))
        {
          return true;
        }
      }
      catch(Exception e)
      {
        throw new ArchivosException(e);
      }
      return false;
    }
    /// <summary>
    /// Genera un string con toda la info de la universidad y jornadas
    /// </summary>
    /// <param name="uni"></param>
    /// <returns>devuelve el string generado</returns>
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
    /// <summary>
    /// Hace publica toda la info de la universidad usando metodos privados de la clase universidad
    /// </summary>
    /// <returns>el string con toda la info</returns>
    public override string ToString()
    {
      return this.MostrarDatos(this);
    }

    #endregion

    #region Sobrecargas
    /// <summary>
    /// Ve si un alumno esta en una universidad
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="a"></param>
    /// <returns>true si esta, false si no</returns>
    public static bool operator ==(Universidad uni, Alumno a)
    {
      foreach (Alumno item in uni.alumnos)
      {
        if (item == a) return true;
      }
      return false;
    }
    /// <summary>
    /// Ve si un alumno no esta en una universidad
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public static bool operator !=(Universidad uni, Alumno a)
    {
      return !(uni == a);
    }

    /// <summary>
    /// Ve si una universidad tiene a un profesor dando clases alli
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="p"></param>
    /// <returns>true si da clases en esa universidad, false si no</returns>
    public static bool operator ==(Universidad uni, Profesor p)
    {
      foreach (Profesor item in uni.instructores)
      {
        if (item.DNI == p.DNI) return true;
      }
      return false;
    }

    /// <summary>
    /// Ve si una universidad no tiene a un profesor dando clases alli
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static bool operator !=(Universidad uni, Profesor p)
    {
      return !(uni == p);
    }

    /// <summary>
    /// Ve en la universidad que profesor da la clase que se le pasa como parametro
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="clase"></param>
    /// <returns>el primer profesor que encuentra que da esa clase</returns>
    public static Profesor operator ==(Universidad uni, Universidad.EClases clase)
    {
      Profesor aux = null;
      foreach (Profesor item in uni.instructores)
      {
        if (item == clase)
        {
          aux = item;
          break;
        }
      }
      if (aux is null) throw new Excepciones.SinProfesorException();
      return aux;
    }

    /// <summary>
    /// Busca el primer profesor que no pueda dar esa clase que se le pasa como parametros
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="clase"></param>
    /// <returns>el primer profesor que no puede dar la clase</returns>
    public static Profesor operator !=(Universidad uni, Universidad.EClases clase)
    {
      Profesor aux = null;
      foreach (Profesor item in uni.instructores)
      {
        if (item != clase)
        {
          aux = item;
          break;
        }
      }
      if (aux is null) throw new Excepciones.SinProfesorException();
      return aux;
    }

    /// <summary>
    /// crea una jornada de la clase que se le pasa como parametro y agrega los alumnos que den esa clase
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="clase"></param>
    /// <returns> devuelve la universidad con la jornada creada</returns>
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

    /// <summary>
    /// Agrega un alumno a la universidad si es que no existe
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="a"></param>
    /// <returns>devuelve la universidad con el alumno cargado</returns>
    public static Universidad operator +(Universidad uni, Alumno a)
    {
      if (uni != a)
      {
        uni.Alumnos.Add(a);
      }
      return uni;
    }

    /// <summary>
    /// Agrega profesores a la universidad si es que no existen actualmente alli
    /// </summary>
    /// <param name="uni"></param>
    /// <param name="p"></param>
    /// <returns>la universidad con el profesor agregado</returns>
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
