using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Switch : Rails
    {
        public List<Rails> From { get; set; }
        public new List<Rails> To { get; set; }

        public Switch(RailType type) : base (type)
        {
            From = new List<Rails>();
            To = new List<Rails>();
        }
    }
}
