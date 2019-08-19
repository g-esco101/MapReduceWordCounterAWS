using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace ReduceService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        // Reduces a dictionary of key-value pairs where each word is a key & the value is the number of times the word occurred
        // to a single key-value pair where the key is the thread id & the value is the total number of word occurrences.
        public async Task<KeyValuePair<string, int>> ReduceAsync(IDictionary<string, int> wordDictionary)
        {
            int sum = 0;
            string key;
            return await Task<KeyValuePair<string, int>>.Factory.StartNew(() =>
            {
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
                return new KeyValuePair<string, int>(key, sum);
            });
        }
    }
}