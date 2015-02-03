using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarchTextAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static Dictionary<string, Location> getStateDict()
        {
            var n = new Dictionary<string, Location>() {
                    {"bedroom", new Location(

                        "You are in your bedroom. Your monitors emit a soft glow, and the source code of a text-based game is just barely visible from your bed. Extend this eventually.", 
                        
                        new Dictionary<string,string>(){
                        {"west", "MC Coffee and Donut Shop"},
                        {"east", "Uni/King"}
                        })},

                    {"MC Coffee and Donut Shop", new Location(

                        "You are at MC CnD. Members of the Hearthstone cult sit at tables, paying their tithes to RNJesus and muttering to each other about pay2win. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"east", "Uni/King"}
                        })},

                    {"Uni/King", new Location(

                        "You are at University and King. It is so damn cold your fingers might freeze off. A faint, appetizing smell of hot wings extends from the north. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Morty's"},
                        {"south", "Starbucks"}
                        })},

                    {"Morty's", new Location(

                        "You are at Morty's. The delicious smell of hot wings reaches your nostrils. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"south", "Uni/King"}
                        })},

                    {"Starbucks", new Location(

                        "You are at Starbucks. Girls enjoying their pumpkin spice lattes are abundant, and the beard to male ratio is significantly higher than average. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Uni/King"},
                        {"south", "LCBO"}
                        })},

                    {"LCBO", new Location(

                        "You are at LCBO. You're tempted to ditch your interview and just get really drunk. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Starbucks"},
                        {"south", "Lunarch Office"}
                        })},

                    {"Lunarch Office", new Location(

                        "You are at the Lunarch office. Alex notices you at the door and waves from his desk. Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"north", "Lunarch bathroom"},
                        {"west", "interview room"}
                        })},

                    {"interview room", new Location(

                        "You are at the Lunarch interview room. Elyot sits down and shakes your hand. At his request, you pull out your laptop and open a text adventure game you made to demo. He smiles and realizes you're incredibly hilarious (and modest to boot). Extend this eventually.", 

                        new Dictionary<string,string>(){
                        {"leave", "bedroom"}
                        })},
            };

            return n;
        }

        static Location getNewState()
        {

        }
    }
}
