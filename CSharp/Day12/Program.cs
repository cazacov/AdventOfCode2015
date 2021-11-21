using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Day12
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllText("input.txt");

            Puzzle1(input);
            Puzzle2(input);
        }

        private static void Puzzle2(string input)
        {
            var doc = JArray.Parse(input);
            Console.WriteLine(SumNumbers(doc));
        }

        public static int SumNumbers(JToken doc)
        {
            if (doc.Type == JTokenType.Integer)
            {
                return doc.Value<int>();
            }

            if (doc is JProperty pro)
            {
                return SumNumbers(pro.Value);
            }


            if (doc is JObject obj)
            {
                foreach (var prop in obj.Children<JProperty>())
                {
                    if (prop.Value.Type == JTokenType.String)
                    {
                        if (prop.Value.Value<string>() == "red")
                        {
                            return 0;
                        }
                    }
                }
            }

            if (doc.Type != JTokenType.Object && doc.Type != JTokenType.Array)
            {
                return 0;
            }
            
            var result = 0;
            foreach (var prop in doc)
            {
                result += SumNumbers(prop);
            }
            return result;
        }

        private static void Puzzle1(string input)
        {
            var pattern = "-*\\d+";
            var regex = new Regex(pattern);

            int sum = 0;

            var match = regex.Match(input);
            while (match.Success)
            {
                var val = Int32.Parse(match.Captures[0].Value);
                sum += val;
                match = match.NextMatch();
            }
            Console.WriteLine(sum);
        }
    }
}
