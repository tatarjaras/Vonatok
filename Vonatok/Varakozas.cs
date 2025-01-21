using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vonatok
{
    internal class Varakozas
    {
        public string Allomas { get; set; }
        public string Erkezo { get; set; }
        public string Indulo { get; set; }
        public int VarakozasIdo { get; set; }
        public string Vonal { get; set; }

        public override string ToString()
        {
            return $"Vonal: {Vonal} Állomás: {Allomas}\nÉrkező: {Erkezo}\nInduló: {Indulo}\nMaximális várakozási idő: {VarakozasIdo}";
        }

        public bool VarakozikE(string erkezo,string indulo)
        {
            bool vajon;
            if (erkezo==indulo)
            {
                vajon = true;
            }
            else
            {
                vajon= false;
            }
            return vajon;
        }


    }
}
