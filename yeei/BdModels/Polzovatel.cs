using System;
using System.Collections.Generic;

namespace yeei
{
    public partial class Polzovatel
    {
        public int Idpolzovatel { get; set; }
        public string Login { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
