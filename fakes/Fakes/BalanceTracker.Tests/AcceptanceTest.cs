using System;
using System.IO;
using Xunit;

namespace BalanceTracker.Tests;

public class AcceptanceTest
{
    [Fact(DisplayName = "Should accept amounts")]
    public void Test1()
    {
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var userInterface = new UserInterface();
        var balance = new Balance(userInterface);
        balance.Append(1);
        balance.Append(2);
        balance.Append(3);
        balance.Append(-2);
        balance.Print();
        Assert.Equal($"4{Environment.NewLine}", stringWriter.ToString());
    }
}
