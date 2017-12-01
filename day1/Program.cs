using System;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Test run");



                Console.WriteLine(Test("1122",3));
                Console.WriteLine(Test("1111", 4));
                Console.WriteLine(Test("1234", 0));
                Console.WriteLine(Test("91212129", 9));

                return;
            }

            Console.WriteLine(Calculate(args[0]));
            
        }

        static string Test(string input, long expected)
        {

            var result = Calculate(input);




            return $"{(result == expected ? "Success" : "Fail")} {input}: {result} (expected: {expected})";
        }

        static long Calculate(string s)
        {
            return Calculate(s, 0, -1);
        }

        static long Calculate(string s, int pos, int last)
        {
            if (pos > s.Length)
            {
                return 0;
            }
            if (int.TryParse(s[pos % s.Length].ToString(), out var current))
            {
                if (current == last)
                {
                    return current + Calculate(s, pos + 1, current);
                }

                return Calculate(s, pos + 1, current);
            }
            return 0;
        }


    }
}
