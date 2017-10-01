# Peer Review - ATM

**Overview**

Implement software for controlling an ATM, using the Windows stack. ATM hardware & bank interaction is provided as compiled assemblies.

**Functional Requirements**

Basic workflow should be followed:
1. The user inserts a card (simulated by the <code>Card</code> class) in the _card reader_ (a hardware device)
2. The user must enter the correct PIN to the card
   - The _card reader_ should 'eat' (hold) the card if there are three (3) authentication fails in a row
3. The ATM should allow the user to:
   - Withdraw - the amount of money cannot be larger than the machine can dispense
     - A predefined amount of money (20, 40, 80, 100, 160, 200 or 400)
     - A custom amount (any positive integer)
   - Cancel (ejects the card), workflow is complete
   
   On withdrawal of money, picture should be taken using the ATM's _camera_ (a hardware device) and a record should be kept, which includes:
  - the picture
  - the amount of money withdrawn
  - the bank transaction reference ID
  - a unique identifier of the event within the ATM (ATM event id) 
  
4. Then the ATM asks the user if receipt should be printed
   - No - the _card reader_ ejects the card. Workflow is complete.
   - Yes - the ATM _printer_ (a hardware device) prints a receipt, then the _card reader_ ejects the card, workflow is complete. The receipt should include:
    - Card number
    - Bank reference ID
    - ATM event ID
    - Amount
    - Date
  
- User interface can be anything - Console App, Web front-end, Voice & Sound, etc

Non-functional requirements:
- The implementation should allow for easy swap of the user interface
- The application can be installed on ATMs with varying hardware periphery. Drivers will be provided. All drivers adhere to the predefined hardware interfaces assembly.

Technical requirements:
- The application should be in .NET

Hardware:


# Hard-coded cards:
- Card 1 with PIN 1000 has 1,520.56 balance
- Card 2 with PIN 2000 has 320.78 balance

What will be judged:
- Code quality
- Implementation flexibility to changes
- Abiltiy to follow specifications

Code is subject to change
