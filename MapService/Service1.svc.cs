using System.Collections.Generic;
using System.ServiceModel;

namespace MapService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {
        // Maps an array of words to a dictionary of key-value pairs where
        // each word is a key & the value is the number of times the word occurs in wordsArray. 
        public IDictionary<string, int> MapFunction(string[] wordsArray)
        {
            IDictionary<string, int> mapReturn = new Dictionary<string, int>();
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
        }
    }
}
