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
        static Dictionary<string, State> stateDict;
        static void Main(string[] args)
        {
            consoleWidth = 140;
            Console.SetWindowSize(consoleWidth+4, 60);

            stateDict = getStateDict();
            State state = stateDict["bedroom"];
            List<State> endgameStates = new List<State>();

            endgameStates.Add(stateDict["bedroom-dreamt"]);
            endgameStates.Add(stateDict["bedroom-dreamt-drunk"]);

            string input;

            while (true)
            {
                TextHelper.print("\n" + state.description + " " + state.getStateTransitionData(stateDict), consoleWidth);

                if (endgameStates.Contains(state))
                {
                    TextHelper.print("\nGame over!", consoleWidth);
                    Console.ReadLine();
                }

                Console.Write("\n\n>> ", consoleWidth);
                input = Console.ReadLine();
                state = getNextState(state, input);
            }
        }

        // returns the next state, given the user input and current state info
        static State getNextState(State currentState, string action)
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

                    {"bedroom-dreamt", new State(

                        "your bedroom",

                        "You are in your bedroom. Wait, what the- You had the Lunarch interview, didn't you!? You glance at the clock - 2:36 PM. You mean that " +
                        "entire thing was a dream...? Ugh. Guess you better go nail that interview again, except in real life this time.",
                        
                        new Dictionary<string,string>(){
                        })},

                    {"bedroom-dreamt-drunk", new State(

                        "your bedroom",

                        "You are in your bedroom. Wait, what the- You had the Lunarch interview, didn't you!? You glance at the clock - 2:36 PM. Whew, " +
                        "you didn't ACTUALLY vomit all over your face before meeting Elyot for the first time. Looks like you better do a better job in the " +
                        "real interview...",
                        
                        new Dictionary<string,string>(){
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

                        "You are at University and King. It is so damn cold your fingers might freeze off. A faint, appetizing smell of hot wings extends from the north.", 

                        new Dictionary<string,string>(){
                        {"north", "Morty's"},
                        {"south", "Starbucks"}
                        })},

                    {"Uni/King-drunk", new State(

                        "the University/King intersection",

                        "You are at University and King. It's oddly warm. You remember you were supposed to go south, but can't remember why.", 

                        new Dictionary<string,string>(){
                        {"south", "Starbucks-drunk"}
                        })},

                    {"Morty's", new State(

                        "Morty's",

                        "You are at Morty's. The delicious smell of hot wings reaches your nostrils. A handful of people, mostly students, are sitting inside drinking and " + 
                        "having a good time - maybe you should order a pitcher...", 

                        new Dictionary<string,string>(){
                        {"south", "Uni/King"},
                        {"order pitcher", "Starbucks-drunk"}
                        })},

                    {"Starbucks", new State(

                        "a Starbucks",

                        "You are at Starbucks. Girls enjoying their pumpkin spice lattes are abundant, and the beard to male ratio is significantly higher than average. There's " +
                        "also some kids playing Magic: the Gathering. You mutter something to yourself about RNJesus topdeck bullshit, before walking up to the counter and ordering a coffee.", 

                        new Dictionary<string,string>(){
                        {"north", "Uni/King"},
                        {"south", "Lunarch Office"}
                        })},

                    {"Starbucks-drunk", new State(

                        "a Starbucks bathroom",

                        "You are at Starbucks. Specifically, a Starbucks bathroom. There's vomit on your face. How the hell did this happen?", 

                        new Dictionary<string,string>(){
                        {"north", "Uni/King-drunk"},
                        {"south", "Lunarch Office-drunk"}
                        })},

                    {"Lunarch Office", new State(

                        "the Lunarch office",

                        "You are at the Lunarch office. Alex recognizes you at the door and waves from his desk. After you've been standing near the door for a few seconds, Elyot walks up " +
                        "to you and introduces himself. He says to follow him before walking towards a meeting room to the west.", 

                        new Dictionary<string,string>(){
                        {"west", "interview room"}
                        })},

                    {"Lunarch Office-drunk", new State(

                        "the Lunarch office",

                        "You are at the Lunarch office. You are also having difficulty walking... You notice a bathroom. That seems like a good idea, huh?", 

                        new Dictionary<string,string>(){
                        {"north", "Lunarch bathroom"},
                        {"west", "interview room"}
                        })},

                    {"Lunarch bathroom", new State(

                        "the Lunarch bathroom",

                        "You make it to the bathroom safely and manage to wipe the vomit off your face. You're starting to sober up, you hope - hopefully Elyot didn't notice " +
                        "and you can still make a good impression.", 

                        new Dictionary<string,string>(){
                        {"west", "interview room-drunk"}
                        })},

                    {"interview room", new State(

                        "the Lunarch interview room",

                        "You are at the Lunarch interview room. Elyot sits down and shakes your hand. At his request, you pull out your laptop and open a text adventure " +
                        "game you made to demo. He smiles and realizes you're incredibly hilarious (and modest to boot). The rest of the interview goes well , and you " +
                        "nail the algorithm questions. At the end, Elyot says the job is yours. You're smiling so hard you might break your face. Now you just need to " +
                        "leave and celebrate.", 

                        new Dictionary<string,string>(){
                        {"leave", "bedroom-dreamt"}
                        })},

                    {"interview room-drunk", new State(

                        "the Lunarch interview room",

                        "You are at the Lunarch interview room. Elyot sits down and shakes your hand. He asks you, \"Is that vomit?\" and you stand up and " +
                        "walk out of the office without a word. Man, the Luminary chat is gonna be awkward now...", 

                        new Dictionary<string,string>(){
                        {"leave", "bedroom-dreamt-drunk"}
                        })},
            };
        }
    }
}
