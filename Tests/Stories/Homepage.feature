# With a lack of business requirements and rules to adhear to it was not possible for me to formulate a well written feature file
# These tests are simply created to verify some basic features of the derivco landing page to help showcase the framework I have written
Feature: Homepage

As a user on the Devrico Homepage, I expect all of the content to be correct and all of the external links to work

@Smoke
Scenario: The homepage loads with the main page banner displayed
	Given I navigate to the homepage
	Then I should see the page banner is displayed

Scenario: The community section is displayed with the correct articles
	Given I navigate to the homepage
	Then the community section should be displayed
	And each of the expected articles is displayed with the correct title
	
	| post      | title                                                |
	| post-5579 | Could Derivco Isle of Man be looking for you?        |
	| post-5563 | Starting at Derivco IOM during lockdown              |
	| post-4291 | A Day In the Life: Leon Triggs, IT Software Engineer |

Scenario Outline: The community articles redirect to the correct Url
	Given I navigate to the homepage
	When I click on <post>
	Then I expect the page URL to be <URL>

	# Data like this would normally be injected from some sort of database or configuration but for simplicity I am setting the data in the feature like so.
	Examples: 
	| post      | URL                                                               |
	| post-5579 | https://derivco.com/could-derivco-isle-of-man-be-looking-for-you/ |
	| post-5563 | https://derivco.com/first-month-at-derivco-iom/                   |
	| post-4291 | https://derivco.com/day-life-leon-triggs-software-engineer/       |