using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneScore.Models.Football
{
    public class Team
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Uri CrestUrl { get; set; }
        public Uri FixturesUrl { get; set; }
        public Uri PlayersUrl { get; set; }
    }
}
