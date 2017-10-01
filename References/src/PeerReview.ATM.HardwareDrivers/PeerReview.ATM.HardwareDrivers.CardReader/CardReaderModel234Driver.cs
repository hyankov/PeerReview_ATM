namespace PeerReview.ATM.HardwareDrivers.CardReader_Model234
{
    using System;
    using System.Diagnostics;
    using Interfaces.Cards;
    using Interfaces.Drivers;

    /// <summary>
    /// A hardware driver to the card reader device
    /// </summary>
    public class CardReaderModel234Driver : ICardReaderDriver
    {
        private Card insertedCard;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public CardReaderModel234Driver()
        {
            this.insertedCard = null;
        }

        /// <summary>
        /// Authenticates the card with a PIN
        /// </summary>
        /// <param name="pin">The PIN to the card</param>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        /// <returns>true - if the PIN matches the card, otherwise false</returns>
        public bool Authenticate(int pin)
        {
            if (this.insertedCard == null)
            {
                throw new InvalidOperationException("No inserted card");
            }

            Trace.TraceInformation("[HARDWARE] Authenticating card ...");

            return this.insertedCard.IsPinCorrect(pin);
        }

        /// <summary>
        /// "Eats" the currently inserted card
        /// </summary>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        public void EatCard()
        {
            if (this.insertedCard == null)
            {
                throw new InvalidOperationException("No inserted card");
            }

            Trace.TraceInformation("[HARDWARE] Card eaten.");
        }

        /// <summary>
        /// Ejects the currently inserted card
        /// </summary>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        public void EjectCard()
        {
            if (this.insertedCard == null)
            {
                throw new InvalidOperationException("No inserted card");
            }

            this.insertedCard = null;
            Trace.TraceInformation("[HARDWARE] Card ejected.");
        }

        /// <summary>
        /// Inserts a card into the ATM
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="cardToInsert"/> is null
        /// </exception>
        /// <exception cref="InvalidOperationException">When there is already an inserted card</exception>
        /// <param name="cardToInsert">The card to insert</param>
        public void InsertCard(Card cardToInsert)
        {
            if (this.insertedCard != null)
            {
                throw new InvalidOperationException("There is a card already inserted");
            }

            if (cardToInsert == null)
            {
                throw new ArgumentNullException(nameof(cardToInsert));
            }

            this.insertedCard = cardToInsert;
            Trace.TraceInformation("[HARDWARE] Card inserted.");
        }

        /// <summary>
        /// Reads the account number of the card
        /// </summary>
        /// <param name="pin">The PIN to the card</param>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        /// <returns>The account number associated with the card</returns>
        public string ReadAccountNumber(int pin)
        {
            if (this.insertedCard == null)
            {
                throw new InvalidOperationException("No inserted card");
            }

            if (!this.Authenticate(pin))
            {
                throw new ArgumentException("Could not authenticate!");
            }

            Trace.TraceInformation("[HARDWARE] Reading account number ...");

            return this.insertedCard.GetAccountNumber(pin);
        }
    }
}