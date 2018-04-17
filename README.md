# BankAccountApp
Simple Console App. 

Bank account application

Scenario: You need to implement an application to handle new customer bank account requests.

Requirements:
- Read a .csv file of names, social security numbers, account type, and initial deposit
- Use proper data structure to hold all these accounts
- Both savings and checking(daily use) accounts share the following properties:
	deposit()
  withdraw()
  transfer()
  showInfo()
   
 - 11- Digit Account Number (generated with the following process: 1 or 2 depending on Savings or Checking,
	last two digits of SSN, unique 5- digit number, and random 3-digit number)
- Savings Account holders are given Safety Deposit Box, identified by 3 digit number and accessed with 4- digit code
- Checking Account holders are assigned a Debit Card with 12- digit number nad 4-digit PIN
- Both accounts will use an interface that determines the base interest rate.
  Savings accounts will use 0.25 points less than the base rate
- The ShowInfo method should reveal relevant account information as well as information specific to the Checking or Saving account.
