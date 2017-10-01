namespace PeerReview.ATM.BankProviders.Bank2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Wrapper to Bank2
    /// <para>[DEV INFO] Available accounts:</para>
    /// <para>{account number} - {balance}</para>
    /// <para>0000 0000 0000 0001 - 1,520.56</para>
    /// <para>0000 0000 0000 0002 - 320.78</para>
    /// </summary>
    public class Bank2AccountProviderWrapper
    {
        private static object accountLocker = new object();
        private readonly Dictionary<string, decimal> accounts;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public Bank2AccountProviderWrapper()
        {
            this.accounts = new Dictionary<string, decimal>();
            this.accounts.Add("0000 0000 0000 0001", 1520.56m);
            this.accounts.Add("0000 0000 0000 0002", 320.78m);
        }

        /// <summary>
        /// Adds the <paramref name="amount"/> to the balance of the account.
        /// </summary>
        /// <param name="accountNumber">The number of the account</param>
        /// <param name="amount">The amount to add. Must be a positive number</param>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="accountNumber"/> is empty
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="accountNumber"/> is not recognized
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="amount"/> is not a positive number
        /// </exception>
        /// <returns>The transaction reference</returns>
        public string Credit(string accountNumber, decimal amount)
        {
            lock (accountLocker)
            {
                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    throw new ArgumentNullException(nameof(accountNumber), "Empty account number");
                }

                if (!this.accounts.ContainsKey(accountNumber))
                {
                    throw new ArgumentOutOfRangeException(nameof(accountNumber), "Unrecognized account");
                }

                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Invalid amount - must be positive number");
                }

                // Perform the credit
                this.accounts[accountNumber] = this.accounts[accountNumber] + amount;

                return "BANK2_CRDT_" + Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// Deducts the <paramref name="amount"/> from the balance of the account.
        /// </summary>
        /// <param name="accountNumber">The number of the account</param>
        /// <param name="amount">The amount to deduct. Must be a positive number</param>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="accountNumber"/> is empty
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="accountNumber"/> is not recognized
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="amount"/> is not a positive number
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="amount"/> is less than the available balance of the account
        /// </exception>
        /// <returns>The transaction reference</returns>
        public string Debit(string accountNumber, decimal amount)
        {
            lock (accountLocker)
            {
                if (string.IsNullOrWhiteSpace(accountNumber))
                {
                    throw new ArgumentNullException(nameof(accountNumber), "Empty account number");
                }

                if (!this.accounts.ContainsKey(accountNumber))
                {
                    throw new ArgumentOutOfRangeException(nameof(accountNumber), "Unrecognized account");
                }

                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Invalid amount - must be positive number");
                }

                if (this.accounts[accountNumber] < amount)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Insufficient funds");
                }

                // Perform the debit
                this.accounts[accountNumber] = this.accounts[accountNumber] - amount;

                return "BANK2_DBT_" + Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// Gets the balance of the account.
        /// </summary>
        /// <param name="accountNumber">The number of the account</param>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="accountNumber"/> is empty
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="accountNumber"/> is not recognized
        /// </exception>
        /// <returns>The balance of the account</returns>
        public decimal GetBalance(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentNullException(nameof(accountNumber));
            }

            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentNullException(nameof(accountNumber));
            }

            if (!this.accounts.ContainsKey(accountNumber))
            {
                throw new ArgumentOutOfRangeException(nameof(accountNumber));
            }

            return this.accounts[accountNumber];
        }
    }
}