using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarchTextAdventure
{
    class Program
    {
        static int consoleWidth;
        static void Main(string[] args)
        {
            consoleWidth = 140;
            Console.SetWindowSize(consoleWidth, 60);

            Dictionary<string, State> stateDict = getStateDict();
            State state = stateDict["bedroom"];

            string input;

            while (true)
            {
                TextWrapper.print("\n" + state.description + " " + state.getStateTransitionData(stateDict), consoleWidth);
                Console.Write("\n\n>> ", consoleWidth);
                input = Console.ReadLine();
                state = getNextState(stateDict, state, input);
            }
        }

        static State getNextState(Dictionary<string, State> stateDict, State currentState, string action)
        {
            try
            {
                return stateDict[currentState.stateTransitions[action]];
            }
            catch
            {
                Console.WriteLine("\nYour command was not recognized. Here's a list of all valid commands from your current state: \n");

                for (int i = 0; i < currentState.stateTransitions.Count; i++)
                {
                    Console.WriteLine("\"" + currentState.stateTransitions.ElementAt(i).Key + "\"");
                }

                return currentState;
            }
        }

        static Dictionary<string, State> getStateDict()
        {
            return new Dictionary<string, State>() {
                    {"bedroom", new State(

                        "your bedroom", // name of state

                        "You are in your bedroom. Your monitors emit a soft glow, and the source code of a text-based game is just barely visible from your " + 
                        "bed. You suddenly remember you have an interview with Lunarch Studios today - you should probably head southeast to their office. " + 
                        "But on the other hand, there's always interesting stuff going on in MC...", // description that is output when in this state
                        
                        new Dictionary<string,string>(){
                        {"west", "MC CnD"}, // all possible transitions from this state
                        {"east", "Uni/King"}
                        })},

                    {"MC CnD", new State(

                        "the MC Coffee and Donut Shop",

                        "You are in the MC C&D. Amidst the frantic League of Legends-related clicking, students are working on their assignments and socializing. " + 
                        "Members of the Hearthstone cult sit at tables, paying their tithes to RNJesus and muttering to each other about pay2win. You're tempted to " + 
                        "go preach the wonders of RNGless competitive strategy games to them, but that's probably not socially acceptable.",

                        new Dictionary<string,string>(){
                        {"east", "Uni/King"},
                        {"preach", "MC CnD-preach"}
                        })},

                    {"MC CnD-preach", new State(

                        "the MC Coffee and Donut Shop",

                        "You are in the MC C&D. You just went up to a bunch of people playing Hearthstone and started telling them their game sucked. They pretty much " + 
                        "ignored you, which you feel you should probably have seen coming.",

                        new Dictionary<string,string>(){
                        {"east", "Uni/King"}
                        })},

                    {"Uni/King", new State(

                        "the University/King intersection",

                        "You are at University and King. It is so damn cold your fingers might freeze off. A faint, appetizing smell of hot wings extends from the north. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Morty's"},
                        {"south", "Starbucks"}
                        })},

                    {"Morty's", new State(

                        "Morty's",

                        "You are at Morty's. The delicious smell of hot wings reaches your nostrils. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"south", "Uni/King"}
                        })},

                    {"Starbucks", new State(

                        "a Starbucks",

                        "You are at Starbucks. Girls enjoying their pumpkin spice lattes are abundant, and the beard to male ratio is significantly higher than average. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Uni/King"},
                        {"south", "LCBO"}
                        })},

                    {"LCBO", new State(

                        "LCBO",

                        "You are at LCBO. You're tempted to ditch your interview and just get really drunk. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Starbucks"},
                        {"south", "Lunarch Office"}
                        })},

                    {"Lunarch Office", new State(

                        "the Lunarch office",

                        "You are at the Lunarch office. Alex notices you at the door and waves from his desk. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Lunarch bathroom"},
                        {"west", "interview room"}
                        })},

                    {"interview room", new State(

                        "the Lunarch interview room",

                        "You are at the Lunarch interview room. Elyot sits down and shakes your hand. At his request, you pull out your laptop and open a text adventure game you made to demo. He smiles and realizes you're incredibly hilarious (and modest to boot). Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"leave", "bedroom"}
                        })},
            };
        }
    }
}
