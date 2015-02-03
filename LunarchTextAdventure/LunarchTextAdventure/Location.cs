using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunarchTextAdventure
{
    class Location
    {
        string description;
        Dictionary<string, string> stateTransitions;

        public Location(string description, Dictionary<string, string> stateTransitions)
        {
            this.description = description;
            this.stateTransitions = stateTransitions;
        }

       
        }

    }
}
