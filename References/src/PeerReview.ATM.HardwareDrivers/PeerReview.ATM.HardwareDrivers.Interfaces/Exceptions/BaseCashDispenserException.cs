namespace PeerReview.ATM.HardwareDrivers.Interfaces.Exceptions
{
    using System;

    /// <summary>
    /// A base class for all Cash Dispenser exceptions
    /// </summary>
    public abstract class BaseCashDispenserException : ApplicationException
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public BaseCashDispenserException()
        {
        }

        /// <summary>
        /// Creates a new instance and initializes the message of the exception
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public BaseCashDispenserException(string message)
            : base(message)
        {
        }
    }
}