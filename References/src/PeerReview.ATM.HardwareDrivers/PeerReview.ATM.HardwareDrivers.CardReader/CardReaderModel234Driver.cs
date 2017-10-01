namespace PeerReview.ATM.HardwareDrivers.CardReader_Model234
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using PeerReview.ATM.HardwareDrivers.Interfaces;

    /// <summary>
    /// A hardware driver to the card reader device
    ///
    /// [DEV INFO] Available cards:
    /// <para>{card number} - {pin}</para>
    /// <para>0001 - 1000</para>
    /// <para>0002 - 2000</para>
    /// [DEV INFO] Available accounts:
    /// <para>{card number} - {account number}</para>
    /// <para>0001 - 0000 0000 0000 0001</para>
    /// <para>0002 - 0000 0000 0000 0002</para>
    /// </summary>
    public class CardReaderModel234Driver : ICardReaderDriver
    {
        private readonly Dictionary<string, string> cardAccounts;
        private readonly Dictionary<string, int> cardPins;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public CardReaderModel234Driver()
        {
            this.cardAccounts = new Dictionary<string, string>();
            this.cardAccounts.Add("0001", "0000 0000 0000 0001");
            this.cardAccounts.Add("0002", "0000 0000 0000 0002");

            this.cardPins = new Dictionary<string, int>();
            this.cardPins.Add("0001", 1000);
            this.cardPins.Add("0002", 2000);
        }

        /// <summary>
        /// Authenticates the card with a PIN
        /// </summary>
        /// <param name="cardNumber">The card number</param>
        /// <param name="pin">The PIN to the card</param>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="cardNumber"/> is empty
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="cardNumber"/> is not recognized
        /// </exception>
        /// <returns>true - if the PIN matches the card, otherwise false</returns>
        public bool AuthenticateCard(string cardNumber, int pin)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                throw new ArgumentNullException(nameof(cardNumber), "Empty account number");
            }

            if (!this.cardPins.ContainsKey(cardNumber))
            {
                throw new ArgumentOutOfRangeException(nameof(cardNumber), "Unrecognized card");
            }

            Trace.TraceInformation("[HARDWARE] Authenticating card ...");

            return this.cardPins[cardNumber] == pin;
        }

        /// <summary>
        /// Reads the account number of the card
        /// </summary>
        /// <param name="cardNumber">The card number</param>
        /// <param name="pin">The PIN to the card</param>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="cardNumber"/> is empty
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="cardNumber"/> is not recognized
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="cardNumber"/> is not authenticated
        /// </exception>
        /// <returns>The account number associated with the card</returns>
        public string ReadAccountNumber(string cardNumber, int pin)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                throw new ArgumentNullException(nameof(cardNumber), "Empty account number");
            }

            if (!this.cardAccounts.ContainsKey(cardNumber))
            {
                throw new ArgumentOutOfRangeException(nameof(cardNumber), "Unrecognized card");
            }

            if (!this.AuthenticateCard(cardNumber, pin))
            {
                throw new ArgumentException("Could not authenticate!");
            }

            Trace.TraceInformation("[HARDWARE] Reading account number ...");

            return this.cardAccounts[cardNumber];
        }
    }
}