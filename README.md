Exercise of ASP.NET Web API about flights

GET METHODS:

http://localhost:50644/api/flight?passengers=2&origin=madrid&Destination=ibiza&dateIn=2017-09-1&roundTrip=false

http://localhost:50644/api/reservation

POST METHODS:

http://localhost:50644/api/reservation

JSON data:
```json
{
    "email": "test2@test.com",
    "creditCard": "00000222",
    "flights": [
        {
            "flightKey": "Flight0001",
            "passengers": [
                {
                    "name": "Kenzo Ferrara",
                    "numBags": 3,
                    "seat": 5
                }
            ]
        },
        {
            "flightKey": "Flight0002",
            "passengers": [
                {
                    "name": "Kenzo Ferrara",
                    "numBags": 5,
                    "seat": 1
                }
            ]
        }
    ]
}
'''
