Feature: LoginTests

Why preconditions are not used:
I assume that there are already some number of real users and using their credentials 
we can access the system through the UI.

Scenario: Login screen displayed when user is not logged in
	When I navigate to the 'main' page
	Then the current page is the 'login' page
	And the login form is displayed on the Login page

Scenario: User logs in successfully with valid credentials
	When I navigate to the 'login' page
	And I submit the login form with credentials of the user with 'validUser' alias on the Login page
	Then the current page is the 'main' page
