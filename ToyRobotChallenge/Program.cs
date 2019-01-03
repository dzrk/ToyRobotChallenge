using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using CommandLine;

namespace ToyRobotChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Board board = new Board();
            ToyRobot robot = new ToyRobot();

            // parse cmd line arguments
            Options options = new Options();

            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => options = opts);

            List<string> cmdList = parser.GetCmdList(@"../../Test Data/" + options.InputFile);

            // runs through each command and passes it to toy robot to execute
            foreach (var cmd in cmdList)
            {
                // captures result from execution and writes to file

                var firstCmd = cmd.Split(' ')[0];
                string result = "";

                if (ToyRobot.IsToyCommand(firstCmd))
                {
                    result = robot.Execute(cmd, board);
                }else if (Board.IsBoardCommand(firstCmd))
                {
                    result = board.Execute(cmd, robot);
                }

                parser.WriteToFile(options.OutputFile, result);

                // resets after exit condition is 'echo' as report and validate are inconsistent
                if (cmd.StartsWith("echo"))
                {
                    board = new Board();
                    robot = new ToyRobot();
                }
            }
                   
                   
                
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
