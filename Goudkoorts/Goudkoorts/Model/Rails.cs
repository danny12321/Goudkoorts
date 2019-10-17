using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Rails : Block, IRunnable
    {
        private Cart _cart = null;
        public RailType RailType { get; set; }

        public Rails(RailType type)
        {
            RailType = type;
        }

        public void Run(Random random, Action<Cart> callback)
        {
            _cart?.Run(random, callback);
        }

        public virtual bool SetCart(Rails from, Cart cart)
        {
            if (_cart == null)
            {
                _cart = cart;
                _cart.Rails = this;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveCart()
        {
            _cart = null;
        }

        public bool HasCart()
        {
            return _cart != null;
        }
    }
}
