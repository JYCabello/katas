using Xunit;

namespace RomanNumerals.Test;

public class RomanNumeralGeneratorShould
{
    [Theory(DisplayName = "Converts using mutation")]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(5, "V")]
    [InlineData(7, "VII")]
    [InlineData(10, "X")]
    [InlineData(16, "XVI")]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(14, "XIV")]
    public void Test1(int dec, string roman) =>
        Assert.Equal(roman, RomanNumeralGenerator.Convert(dec));

    [Theory(DisplayName = "Converts functionally")]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(5, "V")]
    [InlineData(7, "VII")]
    [InlineData(10, "X")]
    [InlineData(16, "XVI")]
    [InlineData(4, "IV")]
    [InlineData(9, "IX")]
    [InlineData(14, "XIV")]
    public void Test2(int dec, string roman) =>
        Assert.Equal(roman, RomanNumeralGenerator.ConvertFunctional(dec));
}
