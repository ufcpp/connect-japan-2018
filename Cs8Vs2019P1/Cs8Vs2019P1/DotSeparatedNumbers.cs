using System;

namespace Cs8Vs2019P1
{
    /// <summary>
    /// "123.456.789.012" みたいな . 区切りの数値を管理。
    /// </summary>
    public class DotSeparatedNumbers
    {
        private readonly string _text;
        private readonly int _i1, _i2, _i3;

        public DotSeparatedNumbers(string text)
        {
            _text = text;
            (_i1, _i2, _i3) = Split(text);
        }

        /// <summary>
        /// 遅延初期化で配列化したい。
        /// = 必ずしも使わないので最初からはアロケーションしたくない
        ///   かといって、使うときは何度も使うので毎回アロケーションしたくない
        /// </summary>
        public ReadOnlySpan<string> Substrings => _substrings ??= GetSubstrings();
        private string[] _substrings;

        /// <summary>
        /// . の位置だけ記録してる状態から、Substring で文字列を抜き出し。
        /// </summary>
        private string[] GetSubstrings()
        {
            var s = new string[4];
            s[0] = _text[.._i1];
            s[1] = _text[_i1 + 1.._i2];
            s[2] = _text[_i2 + 1.._i3];
            s[3] = _text[_i3 + 1..];
            return s;
        }

        /// <summary>
        ///  適当な書式で整形。
        ///  書式に改行とかを含むの @ を付けたい。
        /// </summary>
        public string GetHexString()
        {
            var strs = Substrings;
            Span<int> digis = stackalloc int[4];
            for (int i = 0; i < 4; i++) digis[i] = int.Parse(strs[i]);

            return @$"({digis[0]:X2})
{digis[1]:X2}-{digis[2]:X2}
{digis[3]:X2}
";
        }

        #region デモの目的とあんまり関係ない裏方

        private static (int, int, int) Split(string text)
        {
            var i = 0;
            Span<int> indexes = stackalloc int[3];
            foreach (ref var r in indexes)
            {
                for (; i < text.Length; i++)
                {
                    if (text[i] == '.')
                    {
                        r = i;
                        i++;
                        break;
                    }
                }
            }
            return (indexes[0], indexes[1], indexes[2]);
        }

        #endregion
    }
}
