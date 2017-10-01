namespace PeerReview.ATM.HardwareDrivers.Printer_HyosungNautilus
{
    using System;
    using System.Diagnostics;
    using Interfaces.Drivers;

    /// <summary>
    /// A hardware driver to the printer device of the ATM
    /// <para>[DEV INFO] There is enough paper for 2 receipts</para>
    /// </summary>
    public class PrinterHyosungNautilusDriver : IPrinterDriver
    {
        private static object printLocker = new object();

        private int remainingReceipts;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        public PrinterHyosungNautilusDriver()
        {
            this.remainingReceipts = 2;
        }

        /// <summary>
        /// Prints a receipt
        /// </summary>
        /// <param name="text">The text to print</param>
        /// <exception cref="ArgumentOutOfRangeException">If <paramref name="text"/> is empty.</exception>
        public void PrintReceipt(string text)
        {
            lock (printLocker)
            {
                if (this.remainingReceipts <= 0)
                {
                    throw new ApplicationException("No paper");
                }

                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new ArgumentNullException(nameof(text));
                }

                // Hardware: Prints receipt ...
                Trace.TraceInformation("[HARDWARE] Printing ...");
                Trace.TraceInformation("[HARDWARE] > " + text);
                Trace.TraceInformation("[HARDWARE] Printed.");

                this.remainingReceipts--;
            }
        }
    }
}