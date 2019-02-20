Feature: SkycopSteps

Scenario: Open Skycop claims page
	Given I navigate to claims
	Then I set Kaunas as departure airport
	And I set London Gatwick as arrival airport
	And I select Ryanair Airlines
	And I Choose flight number
	And I choose the flight date
	And I choose the flight date 18
	And I choose Flight delayed
	And I choose more then 3 hours
	And I choose reason Strike