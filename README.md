# Peer Review - "ATM Software"

**Overview**

Implement software for controlling an ATM, using the Windows stack. ATM hardware & bank interaction is provided as compiled assemblies.

**What will be commented on the peer-review**

- Solution structure, code layering
- Architectural decisions
- Code quality, separation of concerns
- Code flexibility to changes
- Maintainability and extension
- Developer's rationale behind every implementation decisions
- Abiltiy to follow specifications

**Functional Requirements**

Basic workflow should be followed:
1. The user inserts a card (simulated by the <code>Card</code> class) in the _card reader_ (a hardware device)
2. The user must enter the correct PIN to the card
   - The _card reader_ should 'eat' (hold) the card if there are three (3) authentication fails in a row. Also a picture should be <code>taken</code> if there is a _camera_ available and it should be stored as a record.
3. The ATM should allow the user to:
   - Withdraw - the amount of money cannot be larger than the machine can dispense
     - A predefined amount of money (20, 40, 80, 100, 160, 200 or 400)
     - A custom amount (any positive integer)
   - Cancel - the _card reader_ ejects the card, workflow is complete
4. Withdraw:
   - Allow only if the selected amount is available in the ATM. Otherwise cancel.
   - Get the bank account # out of the card
   - Charge the bank account, using the provided bank APIs (Note: the bank may decline the charge - handle this)
   - <code>dispense</code> cash from the _cash dispenser_
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

The UI should allow the user to start over, without restarting the application.

**Non-functional requirements**

- The ATM should keep a local LOG of everything that happens.
- No unhandled exceptions should cause the application to crash. The ATM should be resilient to all kinds of errors.
- The implementation should allow for easy swap from one bank API to another (i.e. from <code>Bank1</code> to <code>Bank2</code>)
- The implementation should allow for easy swap of the user interface - e.g. switch from Console App, to WPF or Web frontend.
- The implementation should allow for easy swap of any of the hardware drivers or the lack of optional hardware such as:
   - Camera
   - Printer
- Printing a receipt is not critical and failure to print should not be catastrophic
- Taking a picture is not critical and failure to take a picture should not be catastrophic
- The ATM should **not** dispense money if the card's bank account cannot be charged


**Hardware**

The application can be installed on ATMs with varying hardware. At the moment we target the following known hardware, for which drivers are provided in this repository:
- Card Reader - model 'Model234'
- Printer - model 'Hyosung Nautilus'
- Cash Dispenser - model 'Money Rain 2017'
- Camera - model 'MegaPX'

Drivers to those devices are provided under <code>References\Compiled</code>. If the application will be installed on a different hardware, new drivers will be provided as DLLs.

All drivers adhere and will adhere to the predefined hardware interfaces assembly <code>PeerReview.ATM.HardwareDrivers.Interfaces</code>.

Hardware being "available" means that the instance of its driver is not <code>null</code>.
   
 **Bank APIs**
 
 Two bank API implementations are provided - <code>Bank1</code> and <code>Bank2</code>. They should be referenced by DLLs. The ATM should support both, but will need only one of those implementations at runtime. You can choose which one you use in runtime.
 
 There is no common interface provided between the bank APIs.

**Technical requirements**

- VisualStudio 2015 or compatible is to be used
- .NET ver 4.5.2
- Reference only the DLLs in <code>References\Compiled</code>. Their source code is provided for documentation only and cannot be modified.
- It is **not** required to swap the bank API or hardware drivers after deployment
- The user interface can be whatever you choose - Console App, WPF, Web front-end, Voice & Sound, etc
- Use Microsoft SQL Server to store the ATM records
   - Provide SQL schema creation script (as .sql)
- Use files for logging information
- Using third-party NuGet packages is **allowed**

**Other**

- Use the <code>PeerReview.ATM.HardwareDrivers.Interfaces -> CardFactory</code> class to get a "wallet" (list of <code>Card</code> emulations).
- The APIs are fully documented using XML, including the card PINs

_Code in this repository is subject to change_
