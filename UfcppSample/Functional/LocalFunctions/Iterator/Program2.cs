// 「null を渡すとおかしくなるよね」というのを示すためのコードなので意図的に無視
#pragma warning disable 8604

namespace LocalFunctions.Iterator2
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            IEnumerable<string>? input = null;

            // この場合は期待通りここで例外
            var output = input.Where(x => x.Length < 10);

            Console.WriteLine("ここが表示されるとおかしい"); // ちゃんと表示されない

            foreach (var x in output)
            {
                Console.WriteLine(x);
            }
        }
    }
}
