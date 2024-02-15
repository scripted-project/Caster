using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caster.Components
{
    internal class DataJSON
    {
        public string? Version { get; set; }
        public Dictionary<string, Profile>? Profiles { get; set; }

    }
    internal class Profile
    {
        public Defaults? Defaults { get; set; }
    }
    internal class Defaults
    {
        public string? Audio { get; set; }
        public string? Video { get; set; }
        public string? Output { get; set; }
    }
}
