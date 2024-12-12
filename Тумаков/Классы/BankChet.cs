namespace Тумаков
{
    public enum AccountType
    {
        Saving,
        Tekyshi,
    }
    public class BankChet
    {

        private static int accountNumberCounter = 0;
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;


        public BankChet(AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.accountType = accountType;
        }


        private static string GenerateAccountNumber()
        {
            accountNumberCounter++;
            return "ACC" + accountNumberCounter.ToString("D6");
        }


        public void SetBalance(decimal balance)
        {
            this.balance = balance;
        }


        public decimal GetBalance()
        {
            return balance;
        }


        public bool Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Недостаточно средств для снятия.");
                return false;
            }
            balance -= amount;
            Console.WriteLine($"Снято: {amount}. Остаток: {balance}");
            return true;
        }


        public void Deposit(decimal amount)
        {
            balance += amount;
            Console.WriteLine($"Внесено: {amount}. Новый баланс: {balance}");
        }


        public void PrintBankChet()
        {
            Console.WriteLine($"Номер счета {accountNumber}");
            Console.WriteLine($"Баланс {balance}");
            Console.WriteLine($"Тип банковского счета {accountType}");
        }
        public bool Perevod(BankChet bankChet, decimal amount)
        {
           if(bankChet.balance < amount || amount <= 0)
            {
                return false;
            }
            else
            {
                bankChet.balance -= amount;
                balance += amount;
                return true;
            }
        }
    }

}