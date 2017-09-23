using System;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using OriginStudio.Models.Elements;

namespace OriginStudio
{
    public class LocalizationManager
    {

        public void Initialize()
        {
            GetLocalizations();
        }

        public Localization GetLocalizations()
        {
            var model = new Localization();

            try
            {
                var dir = ConfigurationSettings.AppSettings["ResourceFilesDirectory"];
                var files = Directory.GetFiles(dir, "*.xml");
                var xp = "resources/resource";

                var f = files[0];

                var resources = new Dictionary<string,string>();
                XmlDocument reader;

                using (XmlTextReader xmlReader = new XmlTextReader(f))
                {
                    reader = new XmlDocument();
                    reader.Load(xmlReader);
                }

                XmlNodeList list = reader.SelectNodes(xp);
                foreach (XmlNode node in list)
                {
                    resources.Add(              
                        node.Attributes["key"].InnerText,
                        node.Attributes["value"].InnerText
                    );
                }
                model.Resources = resources;

            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return model;
        }

    }
}
