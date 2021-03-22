using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Tracks
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Image { get; set; }
        public string Preview { get; set; }
        public string SpotifyId { get; set; }
    }
}
