Feature: Parking
    In order to decide which lot to park in 
	As a customer
	I want to be told how much my parking will cost

Scenario: Park in the economy lot for an hour
	Given I park in Economy Parking
	And I enter at 1/1/2010 10:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 4.00
	
	Scenario: Park in the economy lot for two hours
	Given I park in Economy Parking
	And I enter at 1/1/2010 9:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 8.00

	Scenario: Park in the economy lot for three hours
	Given I park in Economy Parking
	And I enter at 1/1/2010 8:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 12.00


    Scenario: Park in the Short term lot for one hours
	Given I park in Short-Term Parking
	And I enter at 1/1/2010 10:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 2.00

	Scenario: Park in the Short term lot for two hours
	Given I park in Short-Term Parking
	And I enter at 1/1/2010 9:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 4.00


	Scenario: Park in the Short term lot for three hours
	Given I park in Short-Term Parking
	And I enter at 1/1/2010 8:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 4.00


	Scenario: Park in the Short term lot for four hours
	Given I park in Short-Term Parking
	And I enter at 1/1/2010 7:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 4.00


	Scenario: Park in the Short term lot for five hours
	Given I park in Short-Term Parking
	And I enter at 1/1/2010 6:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 4.00


	Scenario: Park in the Short term lot for aaa hours
	Given I park in Short-Term Parking
	And I enter at 1/1/2010 6:00 AM
	And I exit at 1/1/2010 11:00 AM
	Then The parking should cost $ 10.00