using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge
{
    public class Options
    {
        [Option('i', "input", Default = "Test - Command Parsing.txt",
    HelpText = "Input file to be processed. Default file is 'Test - Command Parsing.txt'")]
        public string InputFile { get; set; }

        [Option('o', "output", Default = "Output.txt",
    HelpText = "Name of output file. Default file is 'Output.txt'")]
        public string OutputFile { get; set; }

    }
}
