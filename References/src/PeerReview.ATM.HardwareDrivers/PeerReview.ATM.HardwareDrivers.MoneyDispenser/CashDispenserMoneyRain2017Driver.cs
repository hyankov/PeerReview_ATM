namespace PeerReview.ATM.HardwareDrivers.CashDispenser_MoneyRain2017
{
    using System;
    using System.Diagnostics;
    using Interfaces.Drivers;
    using Interfaces.Exceptions;

    /// <summary>
    /// A hardware driver to the cash dispenser device of the ATM
    /// <para>[DEV INFO] There is 600 initial balance in the ATM.</para>
    /// </summary>
    public class CashDispenserMoneyRain2017Driver : ICashDispenserDriver
    {
        private static object dispenseLocker = new object();

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public CashDispenserMoneyRain2017Driver()
        {
            AvailableAmount = 600;
        }

        /// <summary>
        /// Gets the available amount of cash in the ATM
        /// </summary>
        public int AvailableAmount { get; private set; }

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
        public void Dispense(int amount)
        {
            lock (dispenseLocker)
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Must be a positive number");
                }

                if (amount > AvailableAmount)
                {
                    throw new InsufficientAvailableCashException("Insufficient cash in the ATM");
                }

                // Hardware: Dispenses cash ...
                Trace.TraceInformation("[HARDWARE] Cash dispensed.");

                AvailableAmount = AvailableAmount - amount;
            }
        }
    }
}