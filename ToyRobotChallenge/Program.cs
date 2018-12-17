using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            ToyRobot toyRobot = new ToyRobot();

            string fileChosen;
            string fileOutput = "output.txt";

            // generates valid commands from textfile specified in argument, defaults to Command Parsing.txt
            if (args.Length <1)
            {
                fileChosen = "Test - Robot movement.txt";
            }
            else
            {
                fileChosen = args[0];
            }
            List<string> cmdList = parser.GetCmdList(@"../../Test Data/"+ fileChosen);

            // runs through each command and passes it to toy robot to execute
            foreach (var cmd in cmdList)
            {
                // captures result from execution and writes to file
                string result = toyRobot.Execute(cmd);
                parser.WriteToFile(fileOutput, result);

                // resets after exit condition is 'echo' as report and validate are inconsistent
                if (cmd.StartsWith("echo"))
                {
                    toyRobot = new ToyRobot();
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
