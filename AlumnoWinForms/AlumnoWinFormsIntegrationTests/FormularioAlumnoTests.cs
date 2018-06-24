using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CSharp;
using Xunit;
using Newtonsoft;
using AlumnoWinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlumnoWinForms.Unit.Tests
{
    [TestClass()]
    public class FormularioAlumnoTests
    {
        IAlumno itfAlumno = new FormularioAlumno();

        //[TestMethod()]
        //public void FormularioAlumnoTest()
        //{
        //    Assert.Fail();
        //}

        [Fact]
        public void AddTest()
        {
            var alumno = new Alumno { Id = "1", Nombre = "test", Apellidos = "test2", DNI = "4444" };
            if (itfAlumno.Add(alumno))
            {
                using (StreamReader file = File.OpenText(@".\alumno.json"))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject al = (JObject)JToken.ReadFrom(reader);
                    dynamic result = JsonConvert.DeserializeObject<dynamic>(Convert.ToString(al));
                    var alumnoJson = new Alumno { Id = result.Id, Nombre = result.Nombre, Apellidos = result.Apellidos, DNI = result.DNI };
                    Xunit.Assert.True(alumno.Equals(alumnoJson));
                }
            }
        }
    }
}