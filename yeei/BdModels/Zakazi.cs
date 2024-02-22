using System;
using System.Collections.Generic;

namespace yeei
{
    public partial class Zakazi
    {
        public int IdZakazi { get; set; }
        public string Familia { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Otchestvo { get; set; } = null!;
        public string Adres { get; set; } = null!;
        public string Vremya { get; set; } = null!;
        public string Nomer { get; set; } = null!;
        public string Usluga { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
