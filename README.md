
# RoadStatusCodingChallenge

 Steps

1.) Please add the API key and ApplicationId in the "..\RoadStatusCodingChallenge\App.config" file.

# To Build the solution

2.) Open solution in visual studio and Click on 'Build' ->'Build Solution' .
3.) The output window will show the status of build as 'Succeeded'.

# To Run Unit Tests

4.) The solution has Unit tests project called 'UnitTestRoadStatusCodingChallenge'.
5.) To run the tests , Click on 'Tests' -> 'Run' -> 'All Tests'. This will show the unit tests that are 
    currently being run on the Test explorer window. Once all the tests are run , the passed tests will have a green tick to indicate success.
    The failed tests(if any), will be highlighted in red.

# To Run the output 

6.) Once the solution has been built successfully. (As described in 'To Build the solution' section step 2), open the cmd prompt and browse to the location 
    of 'RoadStatusCodingChallenge.exe'.
7.) The command line client 'RoadStatusCodingChallenge.exe' accepts the road name as parameter. eg To find road status for
    "A2" road use C:\[pathofexe]\RoadStatusCodingChallenge.exe A2.
8.) If the road is valid the response will be displayed as "The status of the A2 is as follows
    Road Status is Good
    Road Status Description is No Exceptional Delays" 
9.) Incase of an invalid road name the response will be "[roadName] is not a valid road".


# Assumptions made
1.) The user will enter only one road name. 
2.) As the open data api uses 'https' protocol, for the course of the coding challenge , the code ignores the SSL certificate errors.

