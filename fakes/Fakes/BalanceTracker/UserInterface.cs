namespace BalanceTracker;

public interface IUserInterface
{
    void Print(string output);
}

public class UserInterface : IUserInterface
{
    public void Print(string output) =>
        Console.WriteLine(output);
}
