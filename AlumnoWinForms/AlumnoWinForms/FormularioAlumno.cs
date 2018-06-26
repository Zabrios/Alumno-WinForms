using Newtonsoft.Json;
using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Config;

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

            var parser = new JSONParser();
            parser.Add(alumno);

            txtApellidos.Clear();
            txtDNI.Clear();
            txtNombre.Clear();
            txtID.Clear();
        }
    }
}
