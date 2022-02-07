using Xunit;

namespace BalanceTracker.Tests;

public class BalanceShould
{
    [Fact(DisplayName = "Should display a certain number as balance")]
    public void Test1()
    {
        var mokUi = new MockUserInterface();
        var balance = new Balance(mokUi);
        balance.Append(5);
        balance.Print();
        Assert.Equal("5", mokUi.Output);
    }
}

public class MockUserInterface : IUserInterface
{
    public string Output { get; private set; } = string.Empty;


    public void Print(string output) =>
        Output = output;
}
