# Quickbooks Online - OAuth2 and Quickbooks Integration

This app has been created as a .Net Core MVC App with a shared external resource (QBO.Shared) for communicating with Quickbooks API

The main functionality is to be able to setup the initial connection with quicbooks after a ClientID and ClientSecret is provided viat the QBTokens.json, this will trigger a webpage redirect to Quickbooks site to authenicate and store the Access Token & Refresh Token. 

Once a token has been established the api workflow will try to use the refresh token to generate a new Access Token each page load to ensure a valid token is stored. 

In the QBO.Shared folder you will find a QBO.Local Object for interacting with the token, andn a QBO.Helper that has the service methods in it for getting and storing token information, as well as an additional method for making Quickbooks API requests.

### Customer Sample Requests

Included in the helper is a method for getting and storing customer information. On the main app home page, once you authenticate you will be presented with a customer link that you can click on and view the customer list on the quickbooks account, I added this as a helpful check once authenicated to see that data can successfully be pulled once authenicated.


#### API Configuration

After cloning or downloading the repo, you will need to update the [QBTokens.json](./QBO.Webapp/QBTokens.json) file to match your [apps](https://developer.intuit.com/app/developer/dashboard) `ClientId` and `ClientSecret`. These values are in the Keys & credentials section under `Development Settings` on your QBO app's dashboard.

```jsonc
{
  // The ClientId and ClientSecret
  // can be found in the QBO app on
  // the Keys & credentials page.
  "ClientId": "{your client id here}",
  "ClientSecret": "{your client secret here}",

  // Make sure this URL (or your custom URL) is
  // added to the redirect URLs in your QBO app.
  // 
  // Note: this URL can be anything as long as
  // it is listed in your QBO apps redirect URLs.
  "RedirectUrl": "https://localhost:7106/Receiver",

  // This will be filled after running
  // the app and authenticating.
  "AccessToken": null,
  "RefreshToken": null,
  "RealmId": null
}
```
