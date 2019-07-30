using System;
using System.Collections.Generic;
using System.Reflection;

namespace MapReduceWordCounter
{
    public class TaskTracker
    {
        // Calls Map & Reduce functions.
        public IDictionary<string, int> MapReduce(string mapUrl, string reduceUrl, string[] wordsArray)
        {
            return Reduce(reduceUrl, Map(mapUrl, wordsArray));
        }

        // Dynamically binds to map service. 
        // Given the URL of the map service's wsdl & an array of strings, it returns IDictionary<string, int> where string is a word in wordArray
        // & int is the number of times that word appears in the array. 
        public IDictionary<string, int> Map(string wsdlUri, string[] wordArray)
        {
            ServiceInstantiation serviceIntantiator = new ServiceInstantiation();
            IDictionary<string, int> mapReturn = new Dictionary<string, int>();
            object serviceInstance = serviceIntantiator.instantiateService(wsdlUri);
            MethodInfo methodInformation = null;
            try
            {
                string[] methodNames = serviceIntantiator.getMethodNames(serviceInstance);
                methodInformation = serviceInstance.GetType().GetMethod(methodNames[0]);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TaskTracker.Map 1st Try ex.Message is " + ex.Message);
            }
            Object[] parames = new Object[1];
            parames[0] = wordArray;

            try
            {
                mapReturn = (IDictionary<string, int>)methodInformation.Invoke(serviceInstance, parames);
            }
            catch (Exception ex)
            {
                mapReturn.Add("MAP ERROR", 0);
                System.Diagnostics.Debug.WriteLine("TaskTracker.Map 2nd Try ex.Message is " + ex.Message);

            }
            return mapReturn;
        }

        // Dynamically binds to reduce service.
        // Given the URL of the reduce service's wsdl & an array of strings, it returns IDictionary<string, int> where string is a word in wordArray
        // & int is the number of times that word appears in the array. 
        public IDictionary<string, int> Reduce(string wsdlUri, IDictionary<string, int> wordCountDictionary)
        {
            ServiceInstantiation serviceIntantiator = new ServiceInstantiation();
            IDictionary<string, int> reduceReturn = new Dictionary<string, int>();
            object serviceInstance = serviceIntantiator.instantiateService(wsdlUri);
            MethodInfo methodInformation = null;
            try
            {
                string[] methodNames = serviceIntantiator.getMethodNames(serviceInstance);
                methodInformation = serviceInstance.GetType().GetMethod(methodNames[0]);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TaskTracker.Reduce 1st Try ex.Message is " + ex.Message);
            }
            Object[] parames = new Object[1];
            parames[0] = wordCountDictionary;

            try
            {
                reduceReturn = (IDictionary<string, int>)methodInformation.Invoke(serviceInstance, parames);
            }
            catch (Exception ex)
            {
                reduceReturn.Add("REDUCE ERROR", 0);
                System.Diagnostics.Debug.WriteLine("TaskTracker.Reduce 2nd Try ex.Message is " + ex.Message);
            }
            return reduceReturn;
        }
    }
}