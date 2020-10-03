Feature: Test ReqRes api

Scenario: Get details of single user
    Given ReqRes endpoint is set
	When I set user id in request
	And Send GET HTTP request
	Then I receive valid HTTP response code

Scenario: Get details of invalid user
    Given ReqRes endpoint is set
	When I set invalid user id in request
	And Send GET HTTP request to get details
	Then I receive invalid HTTP response code

Scenario: POST request to create new user
    Given ReqRes endpoint is set
	When Provide new user details
	And Send POST HTTP request
	Then I receive valid POST HTTP response code

Scenario: PUT request to create new user
    Given ReqRes endpoint is set
	When Provide new user details for PUT
	And Send PUT HTTP request
	Then I receive valid PUT HTTP response code

Scenario: DELETE request to remove user
    Given ReqRes endpoint is set
	When Provide user id in delete endpoint
	And Send DELETE HTTP request
	Then I receive DELETE HTTP response code