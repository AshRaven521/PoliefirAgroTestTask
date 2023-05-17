using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestTask
{
    public static class TaskOne
    {
        public static void Do(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception("Такого файла не существует!");
            }
            
            string fileData = string.Empty;

            using (var streamReader = new StreamReader(path, Encoding.Default))
            {
                fileData = streamReader.ReadToEnd();
            }

            var words = fileData.Trim().Split(' ');

            var results = CountWordsOccurance(words).OrderByDescending(a => a.Value);

            Console.WriteLine("Слово из файла - количество вхождений:\n");
            foreach (KeyValuePair<string, int> result in results)
            {
                Console.WriteLine($"{result.Key} - {result.Value}");
            }
        }


        private static Dictionary<string, int> CountWordsOccurance(string[] array)
        {
            var dict = new Dictionary<string, int>();

            foreach (var arr in array)
            {
                int wordCount;

                if (!dict.TryGetValue(arr, out wordCount))
                {
                    wordCount = 0;
                }

                dict[arr] = wordCount + 1;
            }

            return dict;
        }
    }
}
