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

        public int Key = 0;

        public Switch(RailType type) : base (type)
        {

        }

        public override bool SetCart(Rails from, Cart cart)
        {
            if (From[Key % From.Count] != from)
            {

            }

            return true;
        }

        public void Toggle()
        {
            Key++;
        }
    }
}
