using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MapService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        // Maps an array of words to a dictionary of key-value pairs where
        // each word is a key & the value is the number of times the word occurs in wordsArray. 
        public async Task<IDictionary<string, int>> MapAsync(string[] wordsArray)
        {
            IDictionary<string, int> mapReturn = new Dictionary<string, int>();
            //StartNew(Action) - creates and starts a task.
            return await Task<IDictionary<string, int>>.Factory.StartNew(() =>
            {
                try
                {
                    foreach (string word in wordsArray)
                    {
                        if (mapReturn.ContainsKey(word))
                        {
                            mapReturn[word] = mapReturn[word] + 1;
                        }
                        else mapReturn.Add(word, 1);
                    }
                }
                catch
                {
                    mapReturn.Add("MAP SERVICE ERROR", 0);
                }
                return mapReturn;
            });
        }
    }
}
