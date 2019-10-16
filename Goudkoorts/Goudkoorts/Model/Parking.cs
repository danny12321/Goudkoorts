using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Parking : Rails
    {
        public Parking(RailType type) : base (type)
        {

        }

        public virtual bool SetCart(Rails from, Cart cart)
        {
            return true;
        }
    }
}