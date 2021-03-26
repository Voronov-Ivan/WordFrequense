using System;
using System.Collections.Generic;

namespace work_with_list
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text1 = new Text("  Ivan , Voronov, like ,Voronov,     voronov Voronov every smile every day");
            text1.PrintAllWords();
            text1.UpdateWordFrequency();
            text1.PrintWordFrequency();
        }
    }
    class Text
    {
        private string text;
        private string[] allWords;
        public Dictionary<string, int> wordFrequency;
        public Text(string text)
        {
            this.text = text;
            allWords = text.ToLower().Split(new char[] {' ',',','.','!',':',';','?'}, StringSplitOptions.RemoveEmptyEntries);
            wordFrequency = new Dictionary<string, int>();
        }
        public Dictionary<string, int> UpdateWordFrequency()
        {
            foreach(var word in allWords)
            {
                if(!wordFrequency.ContainsKey(word))
                {
                    wordFrequency.Add(word,1);
                }
                else
                {
                    wordFrequency[word]++;
                }
            }
            return wordFrequency;
        }
        public string[] GetAllWords()
        {
            return allWords;
        }
        public Dictionary<string, int> GetWordFrequency()
        {
            return wordFrequency;
        }
        private string GetPlurealization(int i)
        {
            if((i % 10 == 2 || i % 10 == 3 || i % 10 == 4)&&(i != 12 || i != 13 || i !=14))
            {
                return "раза";
            }
            else
            { 
                return "раз";
            }
        }
        public void PrintWordFrequency()
        {
            
            foreach(var word in wordFrequency)
            {
                Console.WriteLine($"{word.Key} - {word.Value} {GetPlurealization(word.Value)}");
            }
        }
        public void PrintAllWords()
        {
            foreach(var word in allWords)
            {
                Console.Write("<"+word+">");
            }
            Console.WriteLine();
        }
    }
}
