# CSG-Assessment
Software Engineer II - Developer Practical Assessment

# Database
Database is a Mongo DB which can be started by executing: 
        mongod --dbpath <Path to database folder in clone>

Current documents in collection:

    {"_id":"8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995",
    "FirstName":"John",
    "LastName":"Doe",
    "Balance":9001.51,
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
    "Balance":2.21,
    "WithdrawalLimit":5000000.99}
    
Pre-hash Salt:ID:PIN = "CSG:8765876587658765:7531"
    
    
    
Id is a Sha-256 hash of "CSG:\<AccountNumber\>:\<Pin\>"

# Request formats
## Retrieve Account Information

### All Accounts

        Curl -k -X Get https://localhost:5001/api/useraccounts
Returns: [{"id":"8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995","firstName":"John","lastName":"Doe","balance":9001.98,"withdrawalLimit":100},
{"id":"2a8dcbb8b0c31e6424d46a1398ed438286ff36ba81825d81e69ee42437d4e474","firstName":"Jane","lastName":"Doe","balance":9002.41,"withdrawalLimit":250.99},
{"id":"9f95d559b7b3cf2cbdcbe75a7df20602deebb03fd2e0705a39b0a6d61f113aa6","firstName":"Jacob","lastName":"Doe","balance":99999999999.99,"withdrawalLimit":0.01},
{"id":"188d4c0162dcd641f0ee58bd5011099347f2a121a690db217455286e85533e60","firstName":"Jingleheimer","lastName":"Doe","balance":2.21,"withdrawalLimit":5000000.99}]

### Individual Account

        Curl -k -X Get https://localhost:5001/api/useraccounts/8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995

Returns: {"id":"8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995","firstName":"John","lastName":"Doe","balance":9001.51,"withdrawalLimit":100}

This serves to both authenticate an account/pin combination collected by the UI and provide current balance information to the end user.

## Update Account Information

        Curl -k -X Put -H "Content-Type: application/json" -d '{"id": "8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995", "Balance": 5001.98, "FirstName": "John", "LastName": "Doe", "WithdrawalLimit": 100}' https://localhost:5001/api/useraccounts/8494c6a8874a11984f2518c1350e579ab33baac5e9a5c5449ebe3a29079b9995
Returns: HTTP/2 204

Utilizing Http's put allows the client to make any updates they deem necessary to the records. 

# Todo
## Committed
    
Current state is the essence of 'technically correct is the best kind of correct'. I have _technically_ met the requirements as stated in the Assessment document, and have even fulfilled Additional Requirement 2 by providing to the terminal the balance limit for their use. Todo is to try to meet the spirit of the document and onload all of the logic and calculations onto the server as I suspect is intended.
    
## Uncommitted
    
1. Optional Requirement 1 to track each atm's balance and process transactions accordingly.
2. As this is ostensibly a financial handling application, It should be PCI compliant which I can't imagine it is.
3. Input Sanitization. Backend breaks if invalid data is entered.

