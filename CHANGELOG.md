## 2.7.2
* Added BillingAddressId to CreditCardRequest
* Allow searching on Subscriptions that are currently in a trial period using InTrialPeriod

## 2.7.1
* Added support for non-US cultures.  Decimal values are now correctly formatted for the gateway and parsed for the client.

## 2.7.0

* Added ability to perform multiple partial refunds on Transactions
* Added RevertSubscriptionOnProrationFailure flag to Subscription update that specifies how a Subscription should react to a failed proration charge
* Deprecated Transaction RefundId in favor of RefundIds
* Deprecated Subscription NextBillAmount in favor of NextBillingPeriodAmount
* Added new properties to Subscription:
  * Balance
  * PaidThroughDate
  * NextBillingPeriodAmount

## 2.6.0

* Added AddOns/Discounts
* Enhanced Subscription search
* Enhanced Transaction search
* Made gateway operations threadsafe when using multiple configurations
* Added VerificationStatus Enumeration
* Added EXPIRED and PENDING statuses to Subscription
* Allowed ProrateCharges to be specified on Subscription update
* Added AddOn/Discount details to Transactions that were created from a Subscription
* All Braintree Exceptions now inherit from BraintreeException superclass
* Added new properties to Subscription:
  * BillingDayOfMonth
  * DaysPastDue
  * FirstBillingDate
  * NeverExpires
  * NumberOfBillingCycles

## 2.5.1

* Updated the Environment class to lazily use environment variables -- this enables use when access to environment variables is restricted

## 2.5.0

* Added ability to specify Country using CountryName, CountryCodeAlpha2, CountryCodeAlpha3, or CountryCodeNumeric
* Added GatewayRejectionReason to Transaction and Verification
* Added Message to Result
* Added BuildTrData method to TransparentRedirectGateway

## 2.4.0

* Added unified TransparentRedirect url and confirm methods and deprecated old methods
* Renamed CreditCard.Default to IsDefault
* Added methods to CreditCardGateway to allow searching on expiring and expired credit cards
* Added ability to update a customer, credit card, and billing address in one request
* Allow updating the payment method token on a subscription
* Added methods to navigate between a Transaction and its refund (in both directions)

## 2.3.0

* Return AvsErrorResponseCode, AvsPostalCodeResponseCode, AvsStreetAddressResponseCode, CurrencyIsoCode, CvvResponseCode with Transaction
* Return CreatedAt, UpdatedAt with Address
* Allow verification against a specified merchant account when creating or updating a CreditCard
* Return SubscriptionId with Transaction

## 2.2.0

* Prevent race condition when pulling back collection results -- search results represent the state of the data at the time the query was run
* Rename ResourceCollection's ApproximateCount to MaximumCount because items that no longer match the query will not be returned in the result set
* Correctly handle HTTP error 426 (Upgrade Required) -- the error code is returned when your client library version is no longer compatible with the gateway
* Properly handle Transaction Options in TR Data

## 2.1.0

* Added transaction advanced search
* Added ability to partially refund transactions
* Added ability to manually retry past-due subscriptions
* Added new transaction error codes
* Allow merchant account to be specified when creating transactions
* Allow creating a transaction with a vault customer and new credit card
* Allow existing billing address to be updated when updating credit card
* **Backwards incomaptible change**: CreditCardRequest.BillingAddress has changed from type AddressRequest to CreditCardAddressRequest

## 2.0.0

* Updated IsSuccess() on transaction results to return false on declined transactions
* Search results now implement IEnumerable and will automatically paginate data

## 1.2.1

* Escape all XML
* Updated quick start example in README

## 1.2.0

* Added subscription search
* Return associated subscriptions when finding credit cards
* Added option to change default credit card for a customer
* Added an All method to ValidationErrors to return List of all errors at that level
* Added a DeepAll method to ValidationErrors to return List of all errors at that level and all errors below
* Renamed DeepSize() to DeepCount
* Added ProcessorAuthorizationCode to Transaction
* Allow setting MerchantAccountId when creating or updating subscriptions
* Updated ForObject to return an empty ValidationErrors object instead of null if there are no errors
* Raise down for maintenance exception instead of forged query string when down for maintenance
* Fixed bug in TotalPages if there are zero total items

