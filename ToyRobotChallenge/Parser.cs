using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ToyRobotChallenge
{
    public class Parser
    {
        public List<string> GetCmdList(string fileName)
        {
            // gets list of valid commands

            List<List<string>> listOfLists = new List<List<string>>();

            // opens input file
            string[] lines = System.IO.File.ReadAllLines(fileName);

            // for loop to read input file line by line
            foreach (string line in lines)
            {
                List<string> tempList = new List<string>();
                tempList = CleanLine(line);

                // appends list of commands from line to temp listOfLists
                listOfLists.Add(tempList);
            }
            var flatList = listOfLists.SelectMany(x => x);
            //  run cleanLine method to return list of strings

            // returns flatten list 
            return flatList.ToList<string>();
        }

        public List<string> CleanLine(string line)
        {
            // returns list of cmds from line

            List<string> lineList = new List<string>();
            // splits each line and looks for keywords ie. PLACE, MOVE
            string[] lineSplit = line.Split(' ','\t');
            bool isPlace = false;
            bool isValidate = false;
            
            foreach(string word in lineSplit)
            {
                // passes whole line as command to echo into console then break
                if (word.StartsWith("echo"))
                {
                    lineList.Add(line);
                    break;
                }
                if(word == "PLACE")
                {
                    // used to concat next line to PLACE command if its in 'x,y,z' format
                    isPlace = true;
                }else if(word == "VALIDATE"){
                    // similiar to above
                    isValidate = true;
                }else if(isPlace || isValidate)
                {
                    // check if x,y,z format
                    string[] pos = word.Split(',');
                    if(pos.Count() == 3)
                    {
                        // produce PLACE or VALIDATE command and append to list of valid commands from this line
                        if(isValidInt(pos[0]) && isValidInt(pos[1]))
                        {
                            if (isPlace)
                            {
                                lineList.Add("PLACE " + word);
                                isPlace = false;
                            }
                            else if (isValidate)
                            {
                                lineList.Add("VALIDATE " + word);
                                isValidate = false;
                            }
                        }
                    }
                    else
                    {
                        // failed the hoops so all previous command is invalid
                        isPlace = false;
                        isValidate = false;
                    }
                }else if(word == "MOVE" || word == "LEFT" || word == "RIGHT" || word == "REPORT")
                {
                    // standard commands get appended to valid commands list
                    lineList.Add(word);
                }
            }

            return lineList;
        }

        public bool isValidInt(string inputValue)
        {
            bool isInt = false;
            int result;
            if(int.TryParse(inputValue, out result))
            {
                isInt = true;
            }
            return isInt;
        }

        public void WriteToFile(string fileName, string output)
        {
            if (output.Length > 1)
            {
                File.AppendAllText(@"../../Output/" + fileName, output + Environment.NewLine);
            }
        }
    }
}