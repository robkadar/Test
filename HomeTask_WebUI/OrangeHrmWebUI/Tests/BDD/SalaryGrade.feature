Feature: SalaryGrade

Scenario to add new Pay Grade record and its currency

Background: Loading the webpage for testing
	Given start Google Chrome and load the "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login" webpage

@AddNewSalaryGrade
Scenario: Add new salary grade
	Given I am logged in to the website
	And I add a new product with its currency data
	When I click on the Save Currency button
	Then the entered currency info should be saved and displayed
