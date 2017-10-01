namespace PeerReview.ATM.HardwareDrivers.Interfaces.Cards
{
    using System;

    /// <summary>
    /// Emulates a hard-copy bank card
    /// </summary>
    public class Card
    {
        private readonly string accountNumber;
        private readonly int pin;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="cardNumber">The card number</param>
        /// <param name="pin">The PIN to access the card</param>
        /// <param name="accountNumber">The account number associated with this card</param>
        internal Card(string cardNumber, int pin, string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                throw new ArgumentNullException(nameof(cardNumber));
            }

            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentNullException(nameof(accountNumber));
            }

            if (pin < 1000 || pin > 9999)
            {
                throw new ArgumentOutOfRangeException(nameof(pin));
            }

            this.CardNumber = cardNumber;
            this.pin = pin;
            this.accountNumber = accountNumber;
        }

        /// <summary>
        /// Gets the card number
        /// </summary>
        public string CardNumber { get; private set; }

        /// <summary>
        /// Gets the account number, if the PIN is correct
        /// </summary>
        /// <param name="pin">The PIN to the card</param>
        /// <returns>Returns the account number</returns>
        public string GetAccountNumber(int pin)
        {
            if (!this.IsPinCorrect(pin))
            {
                throw new ArgumentOutOfRangeException(nameof(pin));
            }

            return this.accountNumber;
        }

        /// <summary>
        /// Try a PIN
        /// </summary>
        /// <param name="pin">The PIN</param>
        /// <returns>true - the PIN is correct, otherwise false</returns>
        public bool IsPinCorrect(int pin)
        {
            return this.pin == pin;
        }
    }
}