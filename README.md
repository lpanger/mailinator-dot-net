# mailinator-dot-net

A package to use Mailinator (http://www.mailinator.com) API's. Requires a paid API key from Mailinator.

#### Installation

Install via nuget package manager

#### Usage

```
var client = new Mailinator.Client("API_TOKEN_HERE");
var emailList = await client.GetEmailsAsync("sometestemail@mailinator.com");
```
