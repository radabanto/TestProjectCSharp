@run_on @edgeBrowser
Feature: Test Project Sample Scenario on Edge
	Simple calculator for adding two numbers

@mytag
Scenario: Access Google
	Given I am a user
	When I access Google site
	Then I am directed to the site search page

Scenario: Perform Google Search
	Given I am a user
	When I access Google site
	And I perform search on 'About Google'
	Then I am directed to the site search results page