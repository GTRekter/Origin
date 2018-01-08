using Origin.Service.Models;
using System;
using System.Runtime.Caching;

namespace Origin.Service.Implementation
{
    public class CacheService : ICacheService
    {
        /// <summary>
        /// Cache key
        /// </summary>
        private const string CACHE_KEY_GETLOCALIZATIONS = "OriginImplementation.CacheService.GetLocalizations";

        /// <summary>
        /// Configuration cache key
        /// </summary>
        private const string CACHE_KEY_GETCONFIGURATION = "OriginImplementation.CacheService.GetConfiguration";

        /// <summary>
        /// Localization service instance
        /// </summary>
        ILocalizationService localizationService = new LocalizationService();

        /// <summary>
        /// Configuration service instance
        /// </summary>
        IConfigurationService configurationService = new ConfigurationService();

        /// <summary>
        /// cache object instance
        /// </summary>
        ObjectCache cache = MemoryCache.Default;

        #region Public Methods

        /// <summary>
        /// Return the localizaion readed into a xml file
        /// </summary>
        /// <returns></returns>
        public Localization GetLocalizations()
        {
            var cacheKey = CACHE_KEY_GETLOCALIZATIONS;
            if (cache.Contains(cacheKey))
            {
                return (Localization)cache[cacheKey];
            }
            else
            {
                var data = localizationService.GetLocalizations();
                cache.Add(cacheKey, data, getDefaultDateTimeOffset());
                return data;
            }
        }

        /// <summary>
        /// Return the configuration readed into a xml file
        /// </summary>
        /// <returns></returns>
        public Configuration GetConfiguration()
        {
            var cacheKey = CACHE_KEY_GETCONFIGURATION;
            if (cache.Contains(cacheKey))
            {
                return (Configuration)cache[cacheKey];
            }
            else
            {
                var data = configurationService.GetConfiguration();
                cache.Add(cacheKey, data, getDefaultDateTimeOffset());
                return data;
            }
        }

        public void Initialize()
        {
            GetLocalizations();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Return the current date two days ahead
        /// </summary>
        /// <returns></returns>
        private DateTimeOffset getDefaultDateTimeOffset()
        {
            return new DateTimeOffset(DateTime.Now.AddDays(2));
        }

        #endregion

    }
}



