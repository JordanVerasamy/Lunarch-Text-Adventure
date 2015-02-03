using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarchTextAdventure
{
    class State
    {
        public string name;
        public string description;
        public Dictionary<string, string> stateTransitions;

        public State(string name, string description, Dictionary<string, string> stateTransitions)
        {
            this.name = name;
            this.description = description;
            this.stateTransitions = stateTransitions;
        }

        public string getStateTransitionData(Dictionary<string, State> stateDict)
        {
            Random rnd = new Random();
            int n;
            int numChoices = 3;
            string output = "";

            for (int i = 0; i < this.stateTransitions.Count; i++)
            {
                var currentElement = this.stateTransitions.ElementAt(i);

                if (currentElement.Key == "west" ||
                    currentElement.Key == "east" ||
                    currentElement.Key == "north" ||
                    currentElement.Key == "south")
                {
                    n = rnd.Next(numChoices);

                    if (n == 1)
                        output = output + "To the " + currentElement.Key + " lies " + stateDict[currentElement.Value].name + ". ";
                    else if (n == 2)
                        output = output + "To your " + currentElement.Key + ", there's " + stateDict[currentElement.Value].name + ". ";
                    else
                        output = output + TextHelper.UppercaseFirst(stateDict[currentElement.Value].name) + " is to the " + currentElement.Key + ". ";
                }
                else
                {
                    continue;
                }
            }

            return output;

        }
        

    }
}
