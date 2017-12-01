using System;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Test run");

                Console.WriteLine("Part 1:");

                Console.WriteLine(TestPart1("1122", 3));
                Console.WriteLine(TestPart1("1111", 4));
                Console.WriteLine(TestPart1("1234", 0));
                Console.WriteLine(TestPart1("91212129", 9));

                Console.WriteLine("Part 2:");

                Console.WriteLine(TestPart2("1212", 6));
                Console.WriteLine(TestPart2("1221", 0));
                Console.WriteLine(TestPart2("123425", 4));
                Console.WriteLine(TestPart2("123123", 12));
                Console.WriteLine(TestPart2("12131415", 4));

                return;
            }

            switch (args[0])
            {
                case "1":
                    Console.WriteLine(CalculatePart1(args[1]));
                    break;
                case "2":
                    Console.WriteLine(CalculatePart2(args[1]));
                    break;
            }



        }

        static string TestPart1(string input, long expected)
        {

            var result = CalculatePart1(input);




            return $"{(result == expected ? "Success" : "Fail")} {input}: {result} (expected: {expected})";
        }

        static long CalculatePart1(string s)
        {
            return CalculatePart1(s, 0, -1);
        }

        static long CalculatePart1(string s, int pos, int last)
        {
            if (pos > s.Length)
            {
                return 0;
            }
            if (int.TryParse(s[pos % s.Length].ToString(), out var current))
            {
                if (current == last)
                {
                    return current + CalculatePart1(s, pos + 1, current);
                }

                return CalculatePart1(s, pos + 1, current);
            }
            return 0;
        }


        static string TestPart2(string input, long expected)
        {

            var result = CalculatePart2(input);




            return $"{(result == expected ? "Success" : "Fail")} {input}: {result} (expected: {expected})";
        }

        static long CalculatePart2(string s)
        {
            return CalculatePart2(s, 0);
        }

        static long CalculatePart2(string s, int pos)
        {
            if (pos >= s.Length)
            {
                return 0;
            }
            if (int.TryParse(s[pos % s.Length].ToString(), out var current) && int.TryParse(s[(pos + (s.Length / 2)) % s.Length].ToString(), out var halfWay))
            {
                if (current == halfWay)
                {
                    return current + CalculatePart2(s, pos + 1);
                }

                return CalculatePart2(s, pos + 1);
            }
            return 0;
        }

    }
}
