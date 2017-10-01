namespace PeerReview.ATM.HardwareDrivers.Interfaces.Exceptions
{
    /// <summary>
    /// An exception representing insufficient available cash in the dispenser
    /// </summary>
    public class InsufficientAvailableCashException : BaseCashDispenserException
    {
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public InsufficientAvailableCashException()
        {
        }

        /// <summary>
        /// Creates a new instance and initialize the message
        /// </summary>
        /// <param name="message">The message of the exception</param>
        public InsufficientAvailableCashException(string message)
            : base(message)
        {
        }
    }
}