using System.Collections.Specialized;
using System.Text;
using DeFuncto.Extensions;

namespace RomanNumerals;

public class RomanNumeralGenerator
{
    public static string Convert(int dec)
    {
        var builder = new StringBuilder();

        foreach (var symbol in Symbols)
        {
            var (key, value) = symbol;
            while (dec >= key)
            {
                dec -= key;
                builder.Append(value);
            }
        }

        return builder.ToString();
    }

    public static string ConvertFunctional(int dec)
    {
        return Go(dec, new StringBuilder()).ToString();

        static StringBuilder Go(int dc, StringBuilder builder) =>
            Symbols
                .FirstOrNone(tpl => dc >= tpl.dec)
                .Map(tpl => Go(dc - tpl.dec, builder.Append(tpl.roman)))
                .DefaultValue(builder);
    }

    private static readonly List<(int dec, string roman)> Symbols =
        new ()
        {
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I")
        };
}
