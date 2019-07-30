using System.Collections.Generic;
using System.ServiceModel;

namespace ReduceService
{

    [ServiceContract]
    public interface IService1
    {

        // Implementation of the Reduce service interface.
        [OperationContract]
        IDictionary<string, int> ReduceFunction(IDictionary<string, int> wordDictionary);   // endpoint
    }

}
