using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CramerMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CramerMethod");
            Console.WriteLine("Enter your first equation without 1,2,3 near x");
            while (true)
            {
                string string1 = Read("first equation");
                string string2 = Read("second equation");
                string string3 = Read("thirt equation");
                var words1 = Split(string1);
                var words2 = Split(string2);
                var words3 = Split(string3);
                try
                {
                    var arg11 = Parses(words1[0]);
                    var arg12 = Parses(words1[1]);
                    var arg13 = Parses(words1[2]);
                    var arg21 = Parses(words2[0]);
                    var arg22 = Parses(words2[1]);
                    var arg23 = Parses(words2[2]);
                    var arg31 = Parses(words3[0]);
                    var arg32 = Parses(words3[1]);
                    var arg33 = Parses(words3[2]);
                    var answer1 = Parses(words1[3]);
                    var answer2 = Parses(words2[3]);
                    var answer3 = Parses(words3[3]);
                    var matrixIdentifier = arg11 * arg22 * arg33 + arg12 * arg23 * arg31 + arg13 * arg21 * arg32 - arg13 * arg22 * arg31 - arg12 * arg21 * arg33 - arg11 * arg23 * arg32;
                    Console.WriteLine($"Matrix identifier is {matrixIdentifier}");
                    var deltX1 = answer1 * arg22 * arg33 + arg12 * arg23 * answer3 + arg13 * answer2 * arg32 - arg13 * arg22 * answer3 - arg12 * answer2 * arg33 - answer1 * arg23 * arg32;
                    var deltX2 = arg11 * answer2 * arg33 + answer1 * arg23 * arg31 + arg13 * arg21 * answer3 - arg13 * answer2 * arg31 - answer1 * arg21 * arg33 - arg11 * arg23 * answer3;
                    var deltX3 = arg11 * arg22 * answer3 + arg12 * answer2 * arg31 + answer1 * arg21 * arg32 - answer1 * arg22 * arg31 - arg12 * arg21 * answer3 - arg11 * answer2 * arg32;
                    var x1 = deltX1 / matrixIdentifier;
                    var x2 = deltX2 / matrixIdentifier;
                    var x3 = deltX3 / matrixIdentifier;
                    Console.WriteLine($"x1 = {x1}, x2 = {x2}, x3 = {x3}");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bed input {ex.Message}, try again or click escape");
                }
            }
            
            Console.ReadKey();
        }
        static string Read (string read)
        {
            do
            {
                try
                {
                    Console.WriteLine($"Enter {read}");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        throw new OperationCanceledException();
                    }
                    var line = Console.ReadLine();
                    var keyLine = $"{key.KeyChar}{line}";
                    return keyLine;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Bed input {ex.Message}, try again or click Escape");
                }
            } while (true);
        }
        static string[] Split(string split)
        {
            return split.Split(new[] { ' ', 'x', '=' }, StringSplitOptions.RemoveEmptyEntries);
        }
        static double Parses (string pars)
        {
            return Double.Parse(pars);
        }
    }

}

