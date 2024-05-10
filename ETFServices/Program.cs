using System;
using System.Collections.Generic;

namespace FinancialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            ETFService etfService = new ETFService();

            while (true)
            {
                Console.WriteLine("Financial Application");
                Console.WriteLine("1. Banking System");
                Console.WriteLine("2. ETF Application");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunBankingSystem(bank);
                        break;
                    case "2":
                        RunETFApplication(etfService);
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void RunBankingSystem(Bank bank)
        {
            while (true)
            {
                Console.WriteLine("Banking System");
                Console.WriteLine("1. Register new account");
                Console.WriteLine("2. Deposit funds");
                Console.WriteLine("3. Withdraw funds");
                Console.WriteLine("4. Close account");
                Console.WriteLine("5. Get account details");
                Console.WriteLine("6. Get customer details");
                Console.WriteLine("7. Return to main menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter customer address: ");
                        string address = Console.ReadLine();
                        bank.RegisterAccount(name, address);
                        break;
                    case "2":
                        Console.Write("Enter account number: ");
                        int depositAccNum = int.Parse(Console.ReadLine());
                        Console.Write("Enter amount to deposit: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        bank.DepositFunds(depositAccNum, depositAmount);
                        break;
                    case "3":
                        Console.Write("Enter account number: ");
                        int withdrawAccNum = int.Parse(Console.ReadLine());
                        Console.Write("Enter amount to withdraw: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        bank.WithdrawFunds(withdrawAccNum, withdrawAmount);
                        break;
                    case "4":
                        Console.Write("Enter account number: ");
                        int closeAccNum = int.Parse(Console.ReadLine());
                        bank.CloseAccount(closeAccNum);
                        break;
                    case "5":
                        Console.Write("Enter account number: ");
                        int accDetailsNum = int.Parse(Console.ReadLine());
                        bank.GetAccountDetails(accDetailsNum);
                        break;
                    case "6":
                        Console.Write("Enter account number: ");
                        int custDetailsNum = int.Parse(Console.ReadLine());
                        bank.GetCustomerDetails(custDetailsNum);
                        break;
                    case "7":
                        Console.WriteLine("Returning to main menu...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void RunETFApplication(ETFService etfService)
        {
            while (true)
            {
                Console.WriteLine("ETF Application");
                Console.WriteLine("1. User Registration");
                Console.WriteLine("2. ETF Search and Discovery");
                Console.WriteLine("3. Portfolio Management");
                Console.WriteLine("4. Real-Time Market Data");
                Console.WriteLine("5. Buy/Sell Orders");
                Console.WriteLine("6. Portfolio Analysis");
                Console.WriteLine("7. Risk Assessment and Management");
                Console.WriteLine("8. Tax Optimization");
                Console.WriteLine("9. Educational Resources");
                Console.WriteLine("10. Account Management");
                Console.WriteLine("11. Return to main menu");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        etfService.UserRegistration();
                        break;
                    case "2":
                        etfService.ETFSearchAndDiscovery();
                        break;
                    case "3":
                        etfService.PortfolioManagement();
                        break;
                    case "4":
                        etfService.RealTimeMarketData();
                        break;
                    case "5":
                        etfService.BuySellOrders();
                        break;
                    case "6":
                        etfService.PortfolioAnalysis();
                        break;
                    case "7":
                        etfService.RiskAssessmentAndManagement();
                        break;
                    case "8":
                        etfService.TaxOptimization();
                        break;
                    case "9":
                        etfService.EducationalResources();
                        break;
                    case "10":
                        etfService.AccountManagement();
                        break;
                    case "11":
                        Console.WriteLine("Returning to main menu...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    class Account
    {
        public int AccountNumber { get; }
        public Customer Owner { get; }
        public decimal Balance { get; set; }

        public Account(int accountNumber, Customer owner)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = 0;
        }
    }

    class Bank
    {
        private List<Account> accounts;
        private int nextAccountNumber;

        public Bank()
        {
            accounts = new List<Account>();
            nextAccountNumber = 1;
        }

        public void RegisterAccount(string name, string address)
        {
            Customer customer = new Customer { Name = name, Address = address };
            Account account = new Account(nextAccountNumber++, customer);
            accounts.Add(account);
            Console.WriteLine("Account registered successfully. Account number: " + account.AccountNumber);
        }

        public void DepositFunds(int accountNumber, decimal amount)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Balance += amount;
                Console.WriteLine("Amount deposited successfully. New balance: " + account.Balance);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void WithdrawFunds(int accountNumber, decimal amount)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                if (amount <= account.Balance)
                {
                    account.Balance -= amount;
                    Console.WriteLine("Amount withdrawn successfully. New balance: " + account.Balance);
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void CloseAccount(int accountNumber)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                if (account.Balance == 0)
                {
                    accounts.Remove(account);
                    Console.WriteLine("Account closed successfully.");
                }
                else
                {
                    Console.WriteLine("Cannot close account. Withdraw all funds first.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void GetAccountDetails(int accountNumber)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine("Account Number: " + account.AccountNumber);
                Console.WriteLine("Customer Name: " + account.Owner.Name);
                Console.WriteLine("Customer Address: " + account.Owner.Address);
                Console.WriteLine("Balance: " + account.Balance);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void GetCustomerDetails(int accountNumber)
        {
            Account account = FindAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine("Customer Name: " + account.Owner.Name);
                Console.WriteLine("Customer Address: " + account.Owner.Address);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private Account FindAccount(int accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }
    }

    class ETF
    {
        // Properties and methods for ETF
    }

    class Portfolio
    {
        // Properties and methods for portfolio
    }

    class ETFService
    {
        private List<User> users = new List<User>();
        private List<ETF> etfs = new List<ETF>();
        private List<Portfolio> portfolios = new List<Portfolio>();

        public void UserRegistration()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User user = new User(name, email, password);
            users.Add(user);
            Console.WriteLine("User registered successfully.");
        }

        public void ETFSearchAndDiscovery()
        {
            // Implementation for ETF search and discovery
            Console.WriteLine("ETF search and discovery functionality.");
        }

        public void PortfolioManagement()
        {
            // Implementation for portfolio management
            Console.WriteLine("Portfolio management functionality.");
        }

        public void RealTimeMarketData()
        {
            // Implementation for real-time market data
            Console.WriteLine("Real-time market data functionality.");
        }

        public void BuySellOrders()
        {
            // Implementation for buy/sell orders
            Console.WriteLine("Buy/sell orders functionality.");
        }

        public void PortfolioAnalysis()
        {
            // Implementation for portfolio analysis
            Console.WriteLine("Portfolio analysis functionality.");
        }

        public void RiskAssessmentAndManagement()
        {
            // Implementation for risk assessment and management
            Console.WriteLine("Risk assessment and management functionality.");
        }

        public void TaxOptimization()
        {
            // Implementation for tax optimization
            Console.WriteLine("Tax optimization functionality.");
        }

        public void EducationalResources()
        {
            // Implementation for educational resources
            Console.WriteLine("Educational resources functionality.");
        }

        public void AccountManagement()
        {
            // Implementation for account management
            Console.WriteLine("Account management functionality.");
        }
    }

    class User
    {
        public string Name { get; }
        public string Email { get; }
        private string Password { get; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
