using System.Xml.Serialization;
using System.IO;
using System;

namespace Origin.Service.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        public void Initialize()
        {
            GetConfiguration();
        }

        public Configuration GetConfiguration()
        {
            Configuration configuration = new Configuration();

            try
            {
                string configurationPath = System.Configuration.ConfigurationManager.AppSettings["ConfigurationDirectory"];

                XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

                using (StreamReader reader = new StreamReader(configurationPath))
                {
                    configuration = (Configuration)serializer.Deserialize(reader);
                    reader.Close();
                }

            }
            catch (Exception exc)
            {
                throw new Exception("Configuration not loaded. " + exc.Message);
            }

            return configuration;
        }
    }
}
