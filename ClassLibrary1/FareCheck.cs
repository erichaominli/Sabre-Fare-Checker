using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCheck
{
    public class FareCheck
    {
        public string Input { get; set; }
        public string Output { get; set;  }

        FareCheck(string ip, string op = "")
        {
            Input = ip;
            Output = op;
        }

        public void result()
        {

        }
    }
}
