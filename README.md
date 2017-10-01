# Peer Review - ATM

**Overview**

Implement software for controlling an ATM, using the Windows stack. ATM hardware & bank interaction is provided as compiled assemblies.

**What will be commented on the peer-review**

- Code quality
- Code flexibility to changes
- Developer's rationale behind implementation decisions
- Abiltiy to follow specifications

**Functional Requirements**

Basic workflow should be followed:
1. The user inserts a card (simulated by the <code>Card</code> class) in the _card reader_ (a hardware device)
2. The user must enter the correct PIN to the card
   - The _card reader_ should 'eat' (hold) the card if there are three (3) authentication fails in a row
3. The ATM should allow the user to:
   - Withdraw - the amount of money cannot be larger than the machine can dispense
     - A predefined amount of money (20, 40, 80, 100, 160, 200 or 400)
     - A custom amount (any positive integer)
   - Cancel - the _card reader_ ejects the card, workflow is complete
4. Withdraw:
   - Allow only if the selected amount is available in the ATM
   - First charge the bank account (acc# stored in the card), using the provided bank APIs
   - Then <code>dispense</code> cash from the _cash dispenser_
   - Then locally store a record, which includes:
     - a picture - **if _camera_ is available**
     - the amount of money withdrawn
     - the bank transaction reference ID
     - a unique identifier of the event within the ATM (ATM event id) 
5. Then **if _printer_ is available** the ATM asks the user if receipt should be printed
   - No - the _card reader_ ejects the card. Workflow is complete.
   - Yes - the ATM _printer_ (a hardware device) prints a receipt, then the _card reader_ ejects the card, workflow is complete. The receipt should include:
    - Card number
    - Bank reference ID
    - ATM event ID
    - Amount
    - Date

Additionally, the ATM should keep a local LOG of everything that happens.

The user interface can be whatever you decide - Console App, Web front-end, Voice & Sound, etc

**Non-functional requirements**

- The implementation should allow for easy swap of the user interface - e.g. switch from Console App, to WPF or Web frontend.
- The implementation should allow for easy swap of any of the hardware drivers or the lack of optional hardware such as:
  - Camera
  - Printer
- Printing a receipt is not critical and failure to print should not be catastrophic
- Taking a picture is not critical and failure to take a picture should not be catastrophic
- The ATM should **not** dispense money if the card's bank account cannot be charged


**Hardware**

The application can be installed on ATMs with varying hardware. At the moment we know of the following hardware:
- Card Reader - model 'Model234'
- Printer - model 'Hyosung Nautilus'
- Cash Dispenser - model 'Money Rain 2017'
- Camera - model 'MegaPX'

Drivers to those devices are provided under <code>References\Compiled</code>. If the application will be installed on a different hardware, new drivers will be provided as DLLs.

All drivers adhere and will adhere to the predefined hardware interfaces assembly <code>PeerReview.ATM.HardwareDrivers.Interfaces</code>.

**Technical requirements**
- Use Microsoft SQL Server to store the ATM records
- Provide SQL schema creation script (as .sql)
- Use files for logging information
- Third-party NuGet packages are **allowed**


_Code in this repository is subject to change_
