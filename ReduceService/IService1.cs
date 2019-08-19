using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ReduceService
{

    [ServiceContract]
    public interface IService1
    {

        // Implementation of the Reduce service interface.
        [OperationContract]
        Task<KeyValuePair<string, int>> ReduceAsync(IDictionary<string, int> wordDictionary); // endpoint
    }

}
