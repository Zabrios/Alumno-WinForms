using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AlumnoWinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnoWinForms.Unit.Tests
{
    [TestClass()]
    public class FormularioAlumnoTests
    {
        private IAlumno mockObject;

        [TestInitialize]
        public void Setup()
        {
            var mock = new Mock<IAlumno>();
            var alumno = new Alumno { Id = "1", Nombre = "test", Apellidos = "test2", DNI = "4444" }; 
            mock.Setup(x => x.Add(alumno)).Returns(true);
            mockObject = mock.Object;
        }

        //[TestMethod()]
        //public void FormularioAlumnoTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void AddTest()
        {
            var alumno = new Alumno { Id = "1", Nombre = "test", Apellidos = "test2", DNI = "4444" };
            var result = mockObject.Add(alumno);
            Assert.AreEqual(true, result);
        }
    }
}