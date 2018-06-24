using Newtonsoft.Json;
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

namespace AlumnoWinForms
{
    public partial class FormularioAlumno : Form, IAlumno
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

            //Console.WriteLine(string.Format(@"ID: {0}, Nombre: {1}, Apellidos: {2}, DNI: {3}", alumno.Id
            //    , alumno.Nombre, alumno.Apellidos, alumno.DNI));

            Add(alumno);
        }

        public bool Add(Alumno alumno)
        {
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
            return addedCorrectly;


            //using (StreamReader file = File.OpenText(@".\alumno.json"))
            //using (JsonTextReader reader = new JsonTextReader(file))
            //{
            //    JObject al = (JObject)JToken.ReadFrom(reader);
            //    dynamic result = JsonConvert.DeserializeObject<dynamic>(Convert.ToString(al));
            //    var alumnoJson = new Alumno { Id = result.Id, Nombre = result.Nombre, Apellidos = result.Apellidos, DNI = result.DNI };
            //    var alumnoTest = new Alumno { Id = "1", Nombre = "dad", Apellidos = "rer", DNI = "4444" };
            //    //Console.WriteLine((alumnoTest.Equals(alumnoJson)));
            //    if (alumnoTest.Equals(alumnoJson))
            //        MessageBox.Show(String.Format("Son iguales. Hash json : {0}, Hash test : {1}", alumnoJson.GetHashCode(), alumnoTest.GetHashCode()));

            //    //Console.WriteLine(string.Format(@"{0} {1}", id, name));
            //}
        }
    }
}
