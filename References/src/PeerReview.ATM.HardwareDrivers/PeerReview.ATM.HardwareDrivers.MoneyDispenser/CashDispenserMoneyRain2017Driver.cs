namespace PeerReview.ATM.HardwareDrivers.CashDispenser_MoneyRain2017
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Interfaces;
    using Interfaces.Drivers;

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
            this.Inventory = new Dictionary<BanknoteKind, int>();
            this.Inventory.Add(BanknoteKind._5, 0);
            this.Inventory.Add(BanknoteKind._10, 1000);
            this.Inventory.Add(BanknoteKind._20, 800);
            this.Inventory.Add(BanknoteKind._50, 500);
            this.Inventory.Add(BanknoteKind._100, 100);
        }

        /// <summary>
        /// Gets the available banknotes in the ATM
        /// </summary>
        public Dictionary<BanknoteKind, int> Inventory { get; private set; }

        /// <summary>
        /// Dispenses cash
        /// </summary>
        /// <param name="banknotes">The banknotes to be dispensed.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the sum of <paramref name="banknotes"/> is less or equal to 0 or if any of the
        /// banknotes is unavailable
        /// </exception>
        public void Dispense(Dictionary<BanknoteKind, int> banknotes)
        {
            lock (dispenseLocker)
            {
                if (banknotes == null || banknotes.Keys.Count == 0 || banknotes.Values.Sum() == 0)
                {
                    throw new ArgumentNullException(nameof(banknotes));
                }

                // Validate that each of the banknotes is available in the requested amount
                foreach (var banknote in banknotes)
                {
                    if (!this.Inventory.ContainsKey(banknote.Key) || this.Inventory[banknote.Key] < banknote.Value)
                    {
                        throw new ArgumentOutOfRangeException(nameof(banknotes), string.Format("Banknote {0} unavailable", banknote.Key));
                    }
                }

                // Dispense
                Trace.TraceInformation("[HARDWARE] Dispensing ...");
                foreach (var banknote in banknotes)
                {
                    Trace.TraceInformation("[HARDWARE] Dispensing {0} x '{1}' ...", banknote.Value, (int)banknote.Key);
                    this.Inventory[banknote.Key] -= banknote.Value;
                }

                Trace.TraceInformation("[HARDWARE] Cash dispensed.");
            }
        }
    }
}