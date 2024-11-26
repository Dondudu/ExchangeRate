## How to run
Open the solution in Visual Studio 2022 and press play. It should be configured to launch on http://localhost:5271.
You will need to supply your own API key in AppSettings.json for the ExchangeRate API key.

## How to test
Open CMD and run the following

```curl -X POST http://localhost:5271/ExchangeService -H "accept: text/plain" -H "Content-Type: application/json" -d "{\"amount\": 5, \"inputCurrency\": \"USD\", \"outputCurrency\": \"AUD\"}"```

This will convert 5 USD to AUD, which is about 7.7 AUD.

Only AUD and USD (bidirectional) are supported.
