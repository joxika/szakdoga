﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Szakdoga_console
{
    class Mezo
    {
        public int tipus;
        public string tulajdonos;
        public bool idelepes;

        public Mezo(int tipus, string tulajdonos, bool idelepes)
        {
            this.tipus = tipus;
            this.tulajdonos = tulajdonos;
            this.idelepes = idelepes;
        }
    }
}
