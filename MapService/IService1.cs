using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MapService
{
    [ServiceContract]
    public interface IService1
    {
        // Implementation of the Map service interface.
        [OperationContract]
        Task<IDictionary<string, int>> MapAsync(string[] wordsArray);  // endpoint
    }
}
