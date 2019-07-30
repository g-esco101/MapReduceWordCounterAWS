using System.Collections.Generic;
using System.ServiceModel;


namespace MapService
{
    [ServiceContract]
    public interface IService1
    {
        // Implementation of the Map service interface.
        [OperationContract]
        IDictionary<string, int> MapFunction(string[] wordsArray);  // endpoint
    }
}
