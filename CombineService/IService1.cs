using System.Collections.Generic;
using System.ServiceModel;


namespace CombineService
{
    [ServiceContract]
    public interface IService1
    {
        // Implementation of the Combine service interface.
        [OperationContract]
        int CombineFunction(IDictionary<string, int> reduceOutput); //endpoint
    }
}