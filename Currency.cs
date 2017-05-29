using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyFileConvertor
{
    public class Currency
    {
        public double rate { get; set; }
        public string value { get; set; }

        public Currency(string val, double rat){
            value = val;
            rate = rat;
        }

    }
}
