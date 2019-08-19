using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MapReduceWordCounter
{
    public class TaskTracker
    {
        // Given an array of strings, it returns IDictionary<string, int> where key is a word in wordArray
        // & value is the number of its occurences. 
        public async Task<Dictionary<string, int>> Map(string[] wordArray)
        {
            Dictionary<string, int> mapReturn = new Dictionary<string, int>();
            ServiceReference1.Service1Client myPxy = new ServiceReference1.Service1Client();
            try
            {
                mapReturn = await myPxy.MapAsync(wordArray);
                myPxy.Close();
                return mapReturn;
            }
            catch (CommunicationException e)
            {
                myPxy.Abort();
            }
            catch (TimeoutException e)
            {
                myPxy.Abort();
            }
            catch (Exception e)
            {
                myPxy.Abort();
                throw;
            }
            mapReturn.Add("MAP ERROR", 0);
            return mapReturn;           
        }

        // Given a dictionary of words (keys) & their occurences (values) , it sums the values & returns 
        // it in a KeyValuePair<string, int> with the thread id as the key.
        public async Task<KeyValuePair<string, int>> Reduce(Dictionary<string, int> wordCountDictionary)
        {
            KeyValuePair<string, int> reduceReturn;
            ServiceReference2.Service1Client myPxy = new ServiceReference2.Service1Client();
            try
            {
                reduceReturn = await myPxy.ReduceAsync(wordCountDictionary);
                myPxy.Close();
                return reduceReturn;
            }
            catch (CommunicationException e)
            {
                myPxy.Abort();
            }
            catch (TimeoutException e)
            {
                myPxy.Abort();
            }
            catch (Exception e)
            {
                myPxy.Abort();
                throw;
            }
            reduceReturn = new KeyValuePair<string, int>("REDUCE ERROR", 0);
            return reduceReturn;
        }

        // Given the result of all the Reduce SOAP calls (via the reduceOutput dictionary properth in,
        // NameNode) it returns the number of words in the uploaded file.
        public async Task<int> Combine(Dictionary<string, int> reduced)
        {
            int combineReturn = 0;
            ServiceReference3.Service1Client myPxy = new ServiceReference3.Service1Client();
            try
            {
                combineReturn = await myPxy.CombineAsync(reduced);
                myPxy.Close();
                return combineReturn;
            }
            catch (CommunicationException e)
            {
                myPxy.Abort();
            }
            catch (TimeoutException e)
            {
                myPxy.Abort();
            }
            catch (Exception e)
            {
                myPxy.Abort();
                throw;
            }
            return combineReturn;
        }
    }
}