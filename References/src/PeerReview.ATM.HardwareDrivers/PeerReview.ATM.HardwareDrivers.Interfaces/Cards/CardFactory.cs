namespace PeerReview.ATM.HardwareDrivers.Interfaces.Cards
{
    using System.Collections.Generic;

    /// <summary>
    /// Factory of example cards
    /// </summary>
    public static class CardFactory
    {
        /// <summary>
        /// Gets a 'wallet' (list) of sample cards
        /// </summary>
        /// <returns>
        /// <list type="Card">
        /// <item>Card # - 0001, PIN - 1000, Initial Balance - 1,520.56</item>
        /// <item>Card # - 0002, PIN - 2000, Initial Balance - 320.78</item>
        /// </list>
        /// </returns>
        public static List<Card> GetWallet()
        {
            var wallet = new List<Card>();

            wallet.Add(new Card("0001", 1000, "0000 0000 0000 0001"));
            wallet.Add(new Card("0002", 2000, "0000 0000 0000 0002"));

            return wallet;
        }
    }
}