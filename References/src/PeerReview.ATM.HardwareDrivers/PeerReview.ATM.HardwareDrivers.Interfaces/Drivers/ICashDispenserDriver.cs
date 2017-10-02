namespace PeerReview.ATM.HardwareDrivers.Interfaces.Drivers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface to the cash dispensers
    /// </summary>
    public interface ICashDispenserDriver
    {
        /// <summary>
        /// Gets the available banknotes in the ATM
        /// </summary>
        Dictionary<BanknoteKind, int> Inventory { get; }

        /// <summary>
        /// Dispenses cash
        /// </summary>
        /// <param name="banknotes">The banknotes to be dispensed.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the sum of <paramref name="banknotes"/> is less or equal to 0 or if any of the
        /// banknotes is unavailable
        /// </exception>
        void Dispense(Dictionary<BanknoteKind, int> banknotes);
    }
}