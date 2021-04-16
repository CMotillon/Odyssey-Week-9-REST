using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Contract
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public int Batteries {get; set;}
        public int Columns {get ; set;}
        public int Elevators {get; set;}
        public int Buttons {get; set;}
        public int Doors {get; set;} 
        public int Display {get; set;}
         

    }
}
