namespace PeerReview.ATM.HardwareDrivers.Interfaces
{
    using System;

    /// <summary>
    /// Interface to the card readers
    /// </summary>
    public interface ICardReaderDriver
    {
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
        bool AuthenticateCard(string cardNumber, int pin);

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
        string ReadAccountNumber(string cardNumber, int pin);
    }
}