// See https://aka.ms/new-console-template for more information

using BalanceTracker;

var balance = new Balance(new UserInterface());
balance.Append(8);
balance.Print();
