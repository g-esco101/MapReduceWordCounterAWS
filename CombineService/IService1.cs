using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CombineService
{
    [ServiceContract]
    public interface IService1
    {
        // Implementation of the Combine service interface.
        [OperationContract]
        Task<int> CombineAsync(IDictionary<string, int> reduceOutput); //endpoint
    }
}