using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Rails
    {
        public Rails To { get; set; }
        public RailType RailType { get; set; }

        public Rails(RailType type)
        {
            RailType = type;
        }
    }
}
