Feature: User

@mytag
Scenario: Get User by Id and Fullname
	Given Id of user is 1
	And Fullname of user is Foued Amami
	When check in BDD
	Then the result should be
	| Id | Fullname    |
	| 1  | Foued Amami |