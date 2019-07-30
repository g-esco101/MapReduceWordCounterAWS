using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;


namespace ReduceService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        // Reduces a dictionary of key-value pairs where each word is a key & the value is the number of times the word occurred
        // to a single key-value pair where the key is the thread id & the value is the total number of word occurrences.
        public IDictionary<string, int> ReduceFunction(IDictionary<string, int> wordDictionary)
        {
            IDictionary<string, int> reduceReturn = new Dictionary<string, int>();
            int sum = 0;
            string key;
            try
            {
                foreach (var element in wordDictionary)
                {
                    sum += element.Value;
                }
                key = Convert.ToString(Thread.CurrentThread.ManagedThreadId);
            }
            catch
            {
                key = "REDUCE SERVICE ERROR";
                sum = 0;
            }
            reduceReturn.Add(key, sum);
            return reduceReturn;
        }
    }
}