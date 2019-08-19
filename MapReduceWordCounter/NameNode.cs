using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MapReduceWordCounter
{
    public class NameNode
    {
        private string[] allWords;
        private int partitionCount;
        private Dictionary<string, int> reduceOutput;

        // Constructor - stores the arguments as instance variables
        public NameNode(string[] allWordsArray, int partitionCount)
        {
            this.allWords = allWordsArray;
            this.partitionCount = partitionCount;
            reduceOutput = new Dictionary<string, int>();
        }

        // Divides the contents of the word file & calls Combiner.
        public async Task<int> Allocate()
        {
            int subStringLength = 0;
            int lastSubStringLength = 0;
            int allWordsLength = 0;
            string[][] partitons = new string[partitionCount][];
            try
            {
                allWordsLength = allWords.Length;
                subStringLength = allWordsLength / partitionCount;
                if (allWordsLength % partitionCount != 0 && partitionCount > 1)
                {
                    lastSubStringLength = allWordsLength - subStringLength * (partitionCount - 1);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("NameNode.allocate 1st Try ex.Message is " + ex.Message);
            }
            for (int i = 0; i < partitionCount; i++)
            {
                string[] subStr = new string[subStringLength];
                int sLength = subStringLength;
                try
                {
                    if (i == (partitionCount - 1) && lastSubStringLength != 0)
                    {
                        sLength = lastSubStringLength;
                        subStr = new string[lastSubStringLength];
                    }
                    Array.Copy(allWords, i * subStringLength, subStr, 0, sLength);
                    partitons[i] = subStr;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("NameNode.allocate 2nd Try ex.Message is " + ex.Message);
                }
            }
            return await Combiner(partitons);
        }

        // Calls MapReduce to begin counting the words. Calls AddReduceOutput to add the results of the
        // Reduce service to the reduceOutput property. 
        private async Task<int> Combiner(string[][] partitons)
        {
            TaskTracker worker = new TaskTracker();
            KeyValuePair<string, int>[] myKVPs = new KeyValuePair<string, int>[partitionCount];
            var tasks = new List<Task>();
            for (int i = 0; i < partitionCount; i++)
            {
                myKVPs[i] = await MapReduce(partitons[i]);
            }
            for (int i = 0; i < partitionCount; i++)
            {
                await AddReduceOutput(myKVPs[i]);
            }
            Task.WaitAll(tasks.ToArray());
            return await worker.Combine(reduceOutput);
        }

        // Calls Map & Reduce functions - which call their respective SOAP services.
        private async Task<KeyValuePair<string, int>> MapReduce(string[] partition)
        {
            TaskTracker worker = new TaskTracker();
            Dictionary<string, int> mapped = await worker.Map(partition);
            return await worker.Reduce(mapped);
        }

        // Adds the result of Reduce to the reduceOutput property.
        public Task AddReduceOutput(KeyValuePair<string, int> reduceReturn)
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    if (reduceOutput.ContainsKey(reduceReturn.Key))
                    {
                        reduceOutput[reduceReturn.Key] += reduceReturn.Value;
                    }
                    else
                    {
                        reduceOutput.Add(reduceReturn.Key, reduceReturn.Value);
                    }
                }
                catch { }
            });
        }
    }
}