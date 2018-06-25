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
    public partial class FormularioAlumno : Form, IAlumno
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FormularioAlumno));
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

            //Console.WriteLine(string.Format(@"ID: {0}, Nombre: {1}, Apellidos: {2}, DNI: {3}", alumno.Id
            //    , alumno.Nombre, alumno.Apellidos, alumno.DNI));

            Add(alumno);
        }

        public bool Add(Alumno alumno)
        {
            // Set up a simple configuration that logs on the console.
            BasicConfigurator.Configure();

            log.Info("Entrando en Add.");

            var addedCorrectly = true;
            //File.WriteAllText(@".\alumno.json", JsonConvert.SerializeObject(alumno));

            // serialize JSON directly to a file
            try
            {
                using (StreamWriter file = File.CreateText(@".\alumno.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, alumno);
                }
            }
            catch (Exception ex)
            {
                addedCorrectly = false;
                throw ex;
            }
            log.Info("Saliendo de Add.");
            return addedCorrectly;
        }
    }
}
