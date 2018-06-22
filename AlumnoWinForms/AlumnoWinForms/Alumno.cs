using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnoWinForms
{
    public class Alumno
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }

        public override bool Equals(object obj)
        {
            Alumno alumno = obj as Alumno;
            if (obj == null)
                return false;

            return Id == alumno.Id &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   DNI == alumno.DNI;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Nombre.GetHashCode() ^ this.Apellidos.GetHashCode() ^ this.DNI.GetHashCode();
        }
    }



}
