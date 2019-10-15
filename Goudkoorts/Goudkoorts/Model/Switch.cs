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
        public List<Rails> To { get; set; }

        // TODO: SET KEY
        public int Key = 0;

        public Switch(RailType type) : base (type)
        {

        }

        public void Toggle()
        {

        }
    }
}
