Feature: Product

A short summary of the feature

Background: The user starts on the sign in page
	Given I am on the mainpage of the ["https://www.saucedemo.com/"] website

@AddProductToCart
Scenario: Adding product to cart
	Given I have logged in as standard_user with the password secret_sauce
	When I click on the item Sauce Labs Backpack
	Then I should redirect to the product detail page
	And I should add the product to the cart
