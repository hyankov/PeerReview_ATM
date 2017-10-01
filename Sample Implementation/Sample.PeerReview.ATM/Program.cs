namespace Sample.PeerReview.ATM
{
    using System;
    using global::PeerReview.ATM.BankProviders.Bank1;
    using global::PeerReview.ATM.HardwareDrivers.Camera_MegaPX;
    using global::PeerReview.ATM.HardwareDrivers.CardReader_Model234;
    using global::PeerReview.ATM.HardwareDrivers.CashDispenser_MoneyRain2017;
    using global::PeerReview.ATM.HardwareDrivers.Interfaces.Cards;
    using global::PeerReview.ATM.HardwareDrivers.Printer_HyosungNautilus;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var cards = CardFactory.GetWallet();

            Console.WriteLine("Choose card from your wallet: ");
            int i = 1;
            foreach (var crd in cards)
            {
                Console.WriteLine("{0}) {1}", i, crd.CardNumber);
                i++;
            }

            var card = cards[int.Parse(Console.ReadKey().KeyChar.ToString()) - 1];

            Console.Write("\nPIN: ");
            var pin = int.Parse(Console.ReadLine());

            var cardReader = new CardReaderModel234Driver();
            cardReader.InsertCard(card);

            if (cardReader.Authenticate(pin))
            {
                Console.Write("Amount: ");
                var amount = int.Parse(Console.ReadLine());

                var cashDispenser = new CashDispenserMoneyRain2017Driver();
                if (amount <= cashDispenser.AvailableAmount)
                {
                    var accountNumber = cardReader.ReadAccountNumber(pin);
                    var cameraDriver = new CameraMegaPXDriver();
                    var picture = cameraDriver.TakePicture();
                    Guid transactionReference;
                    var bank1AccountProviderProxy = new Bank1AccountProviderProxy();
                    bank1AccountProviderProxy.Debit(accountNumber, amount, out transactionReference);
                    cashDispenser.Dispense(amount);
                    Console.WriteLine("Money withdrawn. Reference: " + transactionReference);

                    Console.Write("Print receipt (Y/N): ");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        var printerDriver = new PrinterHyosungNautilusDriver();
                        printerDriver.PrintReceipt(string.Format("{0} withdrawn from {1}", amount, accountNumber));
                        Console.WriteLine("\nReceipt printed.");
                    }
                    else
                    {
                        Console.WriteLine();
                    }

                    cardReader.EjectCard();
                }
                else
                {
                    Console.WriteLine("Insufficient funds in the ATM");
                }
            }
            else
            {
                cardReader.EatCard();
                Console.WriteLine("Authentication failed!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}