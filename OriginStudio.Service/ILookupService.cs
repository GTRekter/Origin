using System.Collections.Generic;
using System.ServiceModel;

namespace OriginStudio.Service
{
    [ServiceContract]
    public interface ILookupService
    {
        [OperationContract]
        List<OR_Lookup> GetLookups();

        [OperationContract]
        OR_Lookup GetLookup(string lookupOriginId);

        [OperationContract]
        List<OR_LookupValue> GetValuesByLookup(string lookupOriginId);
    }
}
