static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0.0m)
        {
            return 3.213f;
        } else if (balance >= 0.0m && balance < 1000.0m)
        {
            return 0.5f;
        } else if (balance >= 1000.0m && balance < 5000.0m)
        {
            return 1.621f;
        } else
        {
            return 2.475f;
        }
    }

    public static decimal Interest(decimal balance)
    {
        decimal interestRate = (decimal)InterestRate(balance);
        return balance * (interestRate / 100.0m);
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int yearsToTarget = 0;
        while(balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            yearsToTarget++;
        }
        return yearsToTarget;
    }
}
