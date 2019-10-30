using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace Clases_Instanciables
{
  public sealed class Profesor : Universitario
  {
    private Queue<Universidad.EClases> clasesDelDia;
    static Random random;


    #region Constructores
    static Profesor()
    {
      random = new Random();
    }

    public Profesor() : base()
    {

    }

    public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
    {
      this.clasesDelDia = new Queue<Universidad.EClases>();
      _randomClases();
    }


    #endregion

    #region Metodos
    private void _randomClases()
    {
      int length = Enum.GetValues(typeof(Universidad.EClases)).Length;
      for (int i = 0; i < 2; i++)
      {
        this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, length));
      }
    }


    protected override string MostrarDatos()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(base.MostrarDatos());
      sb.AppendLine(this.ParticiparEnClase());
      return sb.ToString();

    }

    protected override string ParticiparEnClase()
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendLine($"Clases del dia : ");
      foreach (Universidad.EClases item in clasesDelDia)
      {
        sb.AppendLine($"{item.ToString()}");
      }
      return sb.ToString();
    }


    public override string ToString()
    {
      return this.MostrarDatos();
    }

    #endregion

    #region Sobrecargas
    public static bool operator ==(Profesor i, Universidad.EClases clase)
    {

      foreach (Universidad.EClases item in i.clasesDelDia)
      {
        if (item == clase) return true;
      }
      return false;
    }

    public static bool operator !=(Profesor i, Universidad.EClases clase)
    {
      return !(i == clase);
    }


    #endregion
  }
}
