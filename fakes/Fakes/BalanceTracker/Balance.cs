namespace BalanceTracker;

public class Balance
{
    private readonly IUserInterface userInterface;
    private int balance = 0;

    public Balance(IUserInterface userInterface) =>
        this.userInterface = userInterface;

    public void Append(int amount) =>
        balance += amount;

    public void Print() =>
        userInterface.Print(balance.ToString());
}
