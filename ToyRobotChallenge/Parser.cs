using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobotChallenge
{
    class Parser
    {
        public List<string> GetCmdList(string fileName)
        {
            List<string> listOfLists = new List<string>();
            // opens input file
            // for loop to read input file line by line
            //  run cleanLine method to return list of strings
            //  append cleanLine to main list
            // flatten list
            return listOfLists;
        }

        public List<string> CleanLine(string line)
        {
            List<string> lineList = new List<string>();
            // splits each line and looks for keywords ie. PLACE, MOVE
            // if valid cmd, append to lineList
            // if PLACE && next item in ', , ' concat next item to PLACE string
            // returns list of cmds from line

            return lineList;
        }

    }
}
