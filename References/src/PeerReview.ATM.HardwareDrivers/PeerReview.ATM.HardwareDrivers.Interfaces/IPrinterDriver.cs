namespace PeerReview.ATM.HardwareDrivers.Interfaces
{
    using System;

    /// <summary>
    /// Interface to the printers
    /// </summary>
    public interface IPrinterDriver
    {
        /// <summary>
        /// Prints a receipt
        /// </summary>
        /// <param name="text">The text to print</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="text"/> is empty.</exception>
        void PrintReceipt(string text);
    }
}