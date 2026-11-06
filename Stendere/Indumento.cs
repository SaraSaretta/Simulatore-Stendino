using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Indumento
    {
        public string Codice { get; set; }
        public int Dimensione { get; set; }
        public Indumento(string codice, int dimensione)
        {
            Codice = codice;
            Dimensione = dimensione;
        }
    }
}