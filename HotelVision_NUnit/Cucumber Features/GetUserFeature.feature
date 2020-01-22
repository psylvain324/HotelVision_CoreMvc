Feature: GetUserFeature
	In order to get user information from the API
	As an API consumer
	I want to get users by ID

Scenario: Get user by Id
	Given that a user exists in the system
	When I request to get the user by Id
	Then the user should be returned in the response
	And the response status code is '200 OK'

Scenario: Get non-existing user by Id
	Given that a user does not exist in the system
	When I request to get the user by Id
	Then no user should be returned in the response
	And the response status code is '404 Not Found'
