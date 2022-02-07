using Xunit;

namespace BalanceTracker.Tests;

public class AcceptanceTest
{
    [Fact(DisplayName = "Should accept amounts")]
    public void Test1()
    {
        var userInterface = new UserInterface();
        var balance = new Balance(userInterface); // shoes
        balance.Append(1);
        balance.Append(2);
        balance.Append(3);
        balance.Append(-2);
        balance.Print();
    }
}
