Checkout
==========
tags: checkoutspec

Test1
-----------------
tags: checkoutscenario1

* LogIn with email "email4@mail.com" and password "123456"
* Click Women button in the header
* Click the product with name Faded Short Sleeve T-shirts
* Click Add to card
* Click Proceed to checkout0
* Click Proceed to checkout1
* Click Proceed to checkout2
* Click by Terms of service to agree
* Click Proceed to checkout3
* Click by payment method Pay by bank wire
* Click I confirm my order
* Check Order confirmation page contains "?controller=order-confirmation"
* Check The order is "complete"
* Check Current page is the last step of ordering