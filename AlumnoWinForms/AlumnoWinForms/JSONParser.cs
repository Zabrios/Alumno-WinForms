using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace AlumnoWinForms
{
    public class JSONParser : IAlumnoRepository
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FormularioAlumno));

        public bool Add(Alumno alumno)
        {
            BasicConfigurator.Configure();

            log.Info("Entrando en Add.");

            var addedCorrectly = true;
            //File.WriteAllText(@".\alumno.json", JsonConvert.SerializeObject(alumno));

            // serialize JSON directly to a file
            try
            {
                using (StreamWriter file = File.CreateText(@"..\..\alumno.json"))
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
