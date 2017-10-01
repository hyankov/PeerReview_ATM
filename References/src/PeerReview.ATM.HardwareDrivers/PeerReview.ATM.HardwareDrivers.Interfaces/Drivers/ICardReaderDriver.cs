namespace PeerReview.ATM.HardwareDrivers.Interfaces.Drivers
{
    using System;
    using Cards;

    /// <summary>
    /// Interface to the card readers
    /// </summary>
    public interface ICardReaderDriver
    {
        /// <summary>
        /// Authenticates the currently inserted card with a PIN
        /// </summary>
        /// <param name="pin">The PIN to the card</param>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        /// <returns>true - if the PIN matches the card, otherwise false</returns>
        bool Authenticate(int pin);

        /// <summary>
        /// "Eats" the currently inserted card
        /// </summary>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        void EatCard();

        /// <summary>
        /// Ejects the currently inserted card
        /// </summary>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        void EjectCard();

        /// <summary>
        /// Inserts a card into the ATM
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// When the <paramref name="cardToInsert"/> is null
        /// </exception>
        /// <exception cref="InvalidOperationException">When there is already an inserted card</exception>
        /// <param name="cardToInsert">The card to insert</param>
        void InsertCard(Card cardToInsert);

        /// <summary>
        /// Reads the account number of the currently inserted card
        /// </summary>
        /// <param name="pin">The PIN to the card</param>
        /// <exception cref="InvalidOperationException">When there is no inserted card</exception>
        /// <returns>The account number associated with the card</returns>
        string ReadAccountNumber(int pin);
    }
}