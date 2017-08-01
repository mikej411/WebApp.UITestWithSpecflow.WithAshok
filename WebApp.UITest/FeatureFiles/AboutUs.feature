Feature: AboutUs

@mytag
Scenario: Tests to verify assert
	Given User go to about us page
	And User navigated to home page
	And I have navigated back to the home page
	And I have navigated to the Home page again
	When User enter "blah" into the textbox
	Then The text box should contain "blah"
