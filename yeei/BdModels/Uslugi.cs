using System;
using System.Collections.Generic;

namespace yeei
{
    public partial class Uslugi
    {
        public int IdUslugi { get; set; }
        public string Nazvanie { get; set; } = null!;
        public string Cena { get; set; } = null!;
        public string Vremya { get; set; } = null!;
        public string Num { get; set; } = null!;
    }
}
