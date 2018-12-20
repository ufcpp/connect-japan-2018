﻿#pragma warning disable 219
#pragma warning disable 642
#pragma warning disable 649

namespace IdentifierScope.EmbeddedStatement
{
    using System;

    class Program
    {
        static void DeclarationInEmbeddedStatement()
        {
#if InvalidCode
            if (true)
                int x = 10; // コンパイル エラー
#endif

            if (true)
            {
                int x = 10; // これなら OK
            }

#if InvalidCode
            foreach (var n in new[] { 1 })
                int x = 10; // コンパイル エラー
#endif

            foreach (var n in new[] { 1 })
            {
                int x = 10; // これなら OK
            }
        }

        static void M(object obj)
        {
            if (obj is int x1) // 条件式内
                ;

            foreach (var n in obj is int x2 ? "a" : "b") // foreach の () 内
                ;

            for (var n = 0; obj is int x3 ? n < x3 : false; n++) // for の () 内
                ;

            if (true)
                Console.WriteLine(obj is int x4 ? 1 : 2); // 埋め込みステートメント内

            foreach (var n in "a")
                Console.WriteLine(obj is int x5 ? 1 : 2); // 埋め込みステートメント内
        }

        static int SwitchCaseSample(object obj)
        {
            switch (obj)
            {
                case int x: return x;
                case string x: return x.Length; // int x の方とは別になる
                default: throw new IndexOutOfRangeException();
            }
        }

        static void ErroneousSample(object obj)
        {
            if (true)
            {
                Console.WriteLine(obj is int x ? 1 : 2); // もちろん、ブロック内がスコープ
                x = 1; // これは OK
            }

            if (true)
                Console.WriteLine(obj is int x ? 1 : 2); // 埋め込みステートメント内がスコープ

            foreach (var n in obj is int x ? "a" : "b") // foreach 内がスコープ
                ;

            for (var n = 0; obj is int x ? n < x : false; n++) // for 内がスコープ
                ;

            using (obj is IDisposable x ? x : null) // using 内がスコープ
                ;

            while (obj is int x) // while 内がスコープ
            {
                obj = "";
            }

#if InvalidCode
            // どの x ももうスコープ外。コンパイル エラー
            x = 10;
#endif
        }

        static void ForIncrementSample(object obj)
        {
            for (int i = 0; i < 100; i += obj is int x ? x : 1) // この x はこの式内でだけ使える
            {
                var x = "別の値"; // OK。更新式内の x とは別物
            }
        }

        static void SuccessfulSample(object obj)
        {
            if (obj is int x1) // 条件式内
            {
            }
            else
            {
                x1 = 10; // ここも x1 のスコープ
            }

            Console.WriteLine(x1); // ここも x1 のスコープ
        }

#if InvalidCode
        static int _field = int.TryParse("123", out var x) ? x : 0;
#endif
    }
}
