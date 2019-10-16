using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Wharf : Rails
    {
        private Boat _boat;
        public Wharf(RailType type) : base (type)
        {

        }

        public override bool SetCart(Rails from, Cart cart)
        {
            return true;
        }
    }
}
