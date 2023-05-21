using System;
using NUnit.Framework;

[TestFixture]
public class Tester
{
    private double epsilon = 1e-6;

    [Test]
    public void AccountCannotHaveNegativeOverdraftLimit()
    {
        Account account = new Account(-20);

        Assert.AreEqual(0, account.OverdraftLimit, epsilon);
    }
    [Test]
    public void DepositCannotAcceptNegativeAmount()
    {
        Account account = new Account(20);
        // Verify depositing a negative amount returns false
        Assert.AreEqual(false, account.Deposit(-20));
    }
    [Test]
    public void WithdrawCannotAcceptNegativeAmount()
    {
        Account account = new Account(20);
        // Verify withdrawing a negative amount returns false
        Assert.AreEqual(false, account.Withdraw(-20));
    }
    [Test]
    public void AccountCannotOverstepItsOverdraftLimit()
    {
        Account account = new Account(20);
        // Verifying account cannot withdraw past the overdraft limit, starting balance = 0
        Assert.AreEqual(false, account.Withdraw(30));
    }
    [Test]
    public void DepositAddsTheCorrectAmount()
    {
        Account account = new Account(20);
        // Verify Deposit deposits the correct amount
        double startingBalance = account.Balance;
        double amount = 20;
        account.Deposit(amount);
        Assert.AreEqual((startingBalance + amount), account.Balance);
    }
    [Test]
    public void WithdrawRemovesTheCorrectAmount()
    {
        Account account = new Account(50);
        // Verify Withdraw removes the correct amount
        double startingBalance = account.Balance;
        double amount = 30;
        account.Withdraw(amount);
        Assert.AreEqual((startingBalance - amount), account.Balance);
    }
    [Test]
    public void WithdrawReturnsCorrectResult()
    {
        Account account = new Account(20);
        // Verify Withdraw returns the correct results
        Assert.AreEqual(true, account.Withdraw(10));
    }
    [Test]
    public void DepositReturnsCorrectResult()
    {
        Account account = new Account(20);
        // Verify Deposit returns the correct results
        Assert.AreEqual(true, account.Deposit(10));
    }
}