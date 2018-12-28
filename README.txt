Toy Robot Challenge by Derrick Phung

Description

As outlined on https://bitbucket.org/simonpb/toy-robot-challenge/wiki/What%20Is%20The%20Toy%20Robot%20Challenge

The test data given is a little inconsistent with the example input, so take a look at \ToyRobotChallenge\ToyRobotChallenge\Test Data\ to see the expected input data

By default, the program will run "Test - Command parsing.txt" but the user can change that by modifying the command line arguments. 
You can do this by right clicking Project name in Solution explorer -> Debug -> add a command line argument of the textfile name in quotes.

Two issues with the test data given:

Test 7 of Robot placement runs as intended but there is a typo with the expected output (should be 4,4,WEST)

Test 4 of Commands parsing expects a successful vadiation but fails validation due to a missing command. The robot is never placed so validation should always fail.

Running the tests

To run the automated tests for this program, under the Test drop down nav bar at the top, select Run -> All Tests
These test check if the program is parsing the correct data to Toy Robot as well as checking if the Toy Robot performs its actions correctly

Logic

Program.cs contains the Main method.
The classes are split up in a way where Parser.cs handles the cleaning of the input and prepares a command list for ToyRobot.cs to execute. 
The Execute method in ToyRobot manages what the robot does. The comments in the code should be enough to follow. 
If not, feel free to email me Derrick.phung12@gmail.com.

Update 1:

Command line argument parsing added for input/output. 
Can specify text file input name and output name in the format:
-i "Test - Robot movement.txt" -o "New output.txt"