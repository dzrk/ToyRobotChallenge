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

            // generates valid commands from textfile
            List<string> cmdList = parser.GetCmdList(@"../../Test Data/Test - Command Parsing.txt");

            // runs through each command and passes it to toy robot to execute
            foreach (var cmd in cmdList)
            {
                toyRobot.Execute(cmd);
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
