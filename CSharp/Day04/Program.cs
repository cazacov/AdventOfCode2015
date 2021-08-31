using System;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                long i = 0;
                do
                {
                    var str = $"ckczppom{i}";
                    var input = System.Text.Encoding.ASCII.GetBytes(str);
                    var hash = md5.ComputeHash(input);
                    if (hash[0] == 0 && hash[1] == 0 && hash[2] < 16)
                    {
                        Console.WriteLine($"First five bytes of hash for {i} are zeroes");
                        if (hash[2] == 0)
                        {
                            Console.WriteLine($"First six bytes of hash for {i} are zeroes");
                            break;
                        }
                    }
                    i++;
                } while (true);
            }
        }
    }
}
