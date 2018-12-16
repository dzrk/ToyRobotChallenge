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
            List<string> cmdList = parser.GetCmdList(@"../../Test Data/Example.txt");

            // runs through each command and passes it to toy robot to execute
            foreach (var cmd in cmdList)
            {
                toyRobot.Execute(cmd);
                // resets after exit condition VALIDATE as its the last command in example.txt
                if (cmd.StartsWith("VALIDATE"))
                {
                    toyRobot = new ToyRobot();
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
