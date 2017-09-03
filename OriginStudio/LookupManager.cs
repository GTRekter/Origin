using System.Collections.Generic;
using System.Linq;

namespace OriginStudio
{
    class LookupManager
    {
        public IEnumerable<OR_Lookup> GetLookups(OriginDataContext dataContext)
        {
            IEnumerable<OR_Lookup> lookups = dataContext.OR_Lookups;

            return lookups;
        }

        public OR_Lookup GetLookup(OriginDataContext dataContext, string lookupOriginId)
        {
            OR_Lookup lookup = dataContext.OR_Lookups
                .Where(f => f.OriginId.Equals(lookupOriginId))
                .FirstOrDefault();

            return lookup;
        }

        public List<OR_LookupValue> GetValuesByLookup(OriginDataContext dataContext, string lookupOriginId)
        {
            List<OR_LookupValue> values = dataContext.OR_LookupValues
                .Where(i => i.RelatedOriginId.Equals(lookupOriginId))
                .ToList();

            return values;
        }
    }
}
