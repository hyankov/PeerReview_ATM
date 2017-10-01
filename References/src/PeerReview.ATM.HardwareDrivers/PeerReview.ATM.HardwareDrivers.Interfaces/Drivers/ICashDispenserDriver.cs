namespace PeerReview.ATM.HardwareDrivers.Interfaces.Drivers
{
    using System;
    using PeerReview.ATM.HardwareDrivers.Interfaces.Exceptions;

    /// <summary>
    /// Interface to the cash dispensers
    /// </summary>
    public interface ICashDispenserDriver
    {
        /// <summary>
        /// Gets the available amount of cash in the ATM
        /// </summary>
        int AvailableAmount { get; }

        /// <summary>
        /// Dispenses cash
        /// </summary>
        /// <param name="amount">The amount of cash to be dispensed. Must be a positive numbr.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="amount"/> is less or equal to 0.
        /// </exception>
        /// <exception cref="InsufficientAvailableCashException">
        /// If <see cref="AvailableAmount"/> is less than <paramref name="amount"/>.
        /// </exception>
        void Dispense(int amount);
    }
}