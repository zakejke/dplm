using System;
using System.Collections.Generic;

namespace yeei
{
    public partial class Client
    {
        public int Idclient { get; set; }
        public string Fio { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Usluga { get; set; } = null!;
    }
}
