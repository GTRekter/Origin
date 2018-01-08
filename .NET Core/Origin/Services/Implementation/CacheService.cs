using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Caching.Memory;
using Origin.Service.Interfaces;
using Origin.ViewModel.Elements;

namespace Origin.Service.Implementation
{
    public class CacheService : ICacheService
    {
        /// <summary>
        /// Cache key
        /// </summary>
        private const string CACHE_KEY_GETLOCALIZATIONS = "Origin.Service.CacheService.GetLocalizations";

        /// <summary>
        /// Configuration cache key
        /// </summary>
        private const string CACHE_KEY_GETCONFIGURATION = "Origin.Service.CacheService.GetConfiguration";

        /// <summary>
        /// cache object instance
        /// </summary>
        private IMemoryCache _cache;

        /// <summary>
        /// Absolute path received from the application which specify where the resources are stored
        /// </summary>
        private string _localizationPath;

        #region Constructor

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="memoryCache">Receive the cache from the caller</param>
        public CacheService(IMemoryCache memoryCache, string localizationPath)
        {
            _cache = memoryCache;
            _localizationPath = localizationPath;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Return the localizaion readed into a xml file
        /// </summary>
        /// <returns></returns>
        public Localization GetLocalizations()
        {
            Localization localization;

            // Look for cache key.
            if (!_cache.TryGetValue(CACHE_KEY_GETLOCALIZATIONS, out localization))
            {
                // Key not in cache, so get data.
                localization = GetLocalizationsFromXml();

                // Save data in cache.
                _cache.Set(CACHE_KEY_GETLOCALIZATIONS, localization);
            }

            return localization;
        }

        /// <summary>
        /// Return the configuration readed into a xml file
        /// </summary>
        /// <returns></returns>
        public Configuration GetConfiguration()
        {
            Configuration configuration;

            // Look for cache key.
            if (!_cache.TryGetValue(CACHE_KEY_GETLOCALIZATIONS, out configuration))
            {
                // Key not in cache, so get data.
                configuration = GetConfigurationFromXml();

                // Save data in cache.
                _cache.Set(CACHE_KEY_GETLOCALIZATIONS, configuration);
            }

            return configuration;
        }

        #endregion

        #region Private Methods

        public Localization GetLocalizationsFromXml()
        {
            var model = new Localization();

            try
            {
                var files = Directory.GetFiles(_localizationPath, "*.xml");
                var xp = "resources/resource";

                var f = files[0];

                var resources = new Dictionary<string, string>();
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

        private Configuration GetConfigurationFromXml()
        {
            Configuration configuration = new Configuration();

            try
            {
                // TODO: mettere in configurazione
                string configurationPath = @"C:\Users\ivanp\Desktop\Origin\Origin\_config\Development\settings.xml";

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

        /// <summary>
        /// Return the current date two days ahead
        /// </summary>
        /// <returns></returns>
        private DateTimeOffset GetDefaultDateTimeOffset()
        {
            return new DateTimeOffset(DateTime.Now.AddDays(2));
        }

        #endregion

    }
}
