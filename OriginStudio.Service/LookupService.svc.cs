using System.Linq;
using System.Collections.Generic;

namespace OriginStudio.Service
{
    public class LookupService : ILookupService
    {
        private OriginDataContext _dataContext;

        public LookupService()
        {
            _dataContext = new OriginDataContext();
        }

        public List<OR_Lookup> GetLookups()
        {
            List<OR_Lookup> lookups = _dataContext.OR_Lookups.ToList();

            return lookups;
        }

        public OR_Lookup GetLookup(string lookupOriginId)
        {
            OR_Lookup lookup = _dataContext.OR_Lookups
                .Where(f => f.OriginId.Equals(lookupOriginId))
                .FirstOrDefault();

            return lookup;
        }

        public List<OR_LookupValue> GetValuesByLookup(string lookupOriginId)
        {
            List<OR_LookupValue> values = _dataContext.OR_LookupValues
                .Where(i => i.RelatedOriginId.Equals(lookupOriginId))
                .ToList();

            return values;
        }
    }
}
