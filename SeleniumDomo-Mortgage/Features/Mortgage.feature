﻿Feature: Mortgage
	In order to get a mortage
	As a member of public
	I want to be told how much I can borrow

@mytag
Scenario Outline: Get a First Time Buyer mortgage
	Given I have navigated to the mortgage page
	When I select a mortgage reason of  "<Mortgage Reason>"
	And I enter "<Location>", "<Number of Applicants>", "<Number of Dependants>","<Annual Income>", "<Annual Bonus>" and "<Monthly Debt>" in the how much can I borrow tab
	And I click on calculate how much I can borrow button
	Then the offer amount should be "<Offer amount>"
Examples: 
| Mortgage Reason   | Location | Number of Applicants | Annual Income | Number of Dependants | Annual Bonus | Monthly Debt | Offer amount	|
| First time buyers | Scotland  | 1                    | 30000         | 2                    | 2000         | 500          |  80,940		|
| First time buyers | Wales		| 1                    | 40000         | 3                    |		0        | 200			|  165,970		|