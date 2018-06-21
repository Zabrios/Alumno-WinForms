using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumnoWinForms
{
    public partial class FormularioAlumno : Form
    {
        public FormularioAlumno()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var alumno = new Alumno();
            alumno.Apellidos = txtApellidos.Text;
            alumno.DNI = txtDNI.Text;
            alumno.Nombre = txtNombre.Text;
            alumno.Id = txtID.Text;

            Console.WriteLine(string.Format(@"ID: {0}, Nombre: {1}, Apellidos: {2}, DNI: {3}", alumno.Id
                , alumno.Nombre, alumno.Apellidos, alumno.DNI));
        }

        private void Add(Alumno alumno)
        {

        }
    }
}
