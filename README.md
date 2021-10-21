# CSG-Assessment
Software Engineer II - Developer Practical Assessment

## Summary
I'm using C# with asp.net, and a mongodb backend.


# Database
Database is a Mongo DB which can be started by executing: 
        mongod --dbpath \<Path to database folder in clone\>

Current documents in collection:

    {"_id":"8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995",
    "FirstName":"John",
    "LastName":"Doe",
    "Balance":9001.70,
    "WithdrawalLimit":100}
    
Pre-hash Salt:ID:PIN = "CSG:1234123412341234:2468"
    
    {"_id":"2a8dcbb8b0c31e6424d46a1398ed438286ff36ba81825d81e69ee42437d4e474",
    "FirstName":"Jane",
    "LastName":"Doe",
    "Balance":9002.41,
    "WithdrawalLimit":250.99}
    
Pre-hash Salt:ID:PIN = "CSG:4321432143214321:8642"
    
    {"_id":"9f95d559b7b3cf2cbdcbe75a7df20602deebb03fd2e0705a39b0a6d61f113aa6",
    "FirstName":"Jacob",
    "LastName":"Doe",
    "Balance":99999999999.99,
    "WithdrawalLimit":0.01}
    
Pre-hash Salt:ID:PIN = "CSG:5678567856785678:1357"
    

    {"_id":"188d4c0162dcd641f0ee58bd5011099347f2a121a690db217455286e85533e60",
    "FirstName":"Jingleheimer",
    "LastName":"Doe",
    "Balance":2.01,
    "WithdrawalLimit":5000000.99}
    
Pre-hash Salt:ID:PIN = "CSG:8765876587658765:7531"
    
    
    
Id is a Sha-256 hash of "CSG:\<AccountNumber\>:\<Pin\>"

# Request formats
## Retrieve Account Information

        curl -k -X Get -H "Content-Type: application/json" -d '{"id": "8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995"}' https://localhost:5001/api/useraccounts/

Returns: {"id":"8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995","firstName":"John","lastName":"Doe","balance":8951.48,"withdrawalLimit":100}

This serves to both authenticate an account/pin combination collected by the UI and provide current balance information to the end user.
    
Definitions
    id: Sha-256 hash of value: "CSG:\<AccountNumber\>:\<PIN\>"

## Update Account Information
### Withrdawal
        curl -k -X Put -H "Content-Type: application/json" -d '{"id": "188d4c0162dcd641f0ee58bd5011099347f2a121a690db217455286e85533e60", "Type": "Withdrawal", "Amount": 79980.22}' https://localhost:5001/api/useraccounts/

Returns: {"status":"200","statusText":"Withdrawal Processed","newBalance":8901.26}


### Deposit
        curl -k -X Put -H "Content-Type: application/json" -d '{"id": "188d4c0162dcd641f0ee58bd5011099347f2a121a690db217455286e85533e60", "Type": "Withdrawal", "Amount": 79980.22}' https://localhost:5001/api/useraccounts/
        
 Returns: {"status":"200","statusText":"Deposit Accepted","newBalance":9001.70}

Definitions
    id: Sha-256 hash of value: "CSG:\<AccountNumber\>:\<PIN\>"
    Type: Must be either 'Withdrawal' or 'Deposit' in any casing
    Amount: Must be positive, if withdrawing funds, must be lower than withdrawal limit on account
    

# Todo
## Committed
None!
    
## Uncommitted
1. Optional Requirement 1 to track each atm's balance and process transactions accordingly.
2. As this is ostensibly a financial handling application, It should be PCI compliant which I can't imagine it is.

