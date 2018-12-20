using System;

namespace Cs8Vs2019P1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = new DotSeparatedNumbers("192.168.100.1");

            foreach (var x in n.Substrings)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine(n.GetHexString());
        }
    }
}
