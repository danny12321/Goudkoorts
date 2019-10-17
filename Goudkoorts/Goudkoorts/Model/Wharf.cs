using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Wharf : Rails, IRunnable
    {
        public Boat Boat { get; private set; }
        public int Points { get; private set; }

        public Wharf(RailType type) : base (type)
        {
            Points = 0;
        }

        public bool Run(Random random, Action<Cart> callback)
        {
            // Dock new boat
            var ran = random.Next(100);
            if(ran < 20)
            {
                if (Boat == null)
                {
                    Boat = new Boat();
                }
            }

            // There is a cart stading on the Wharf
            if(_cart != null)
            {
                // Cart has Freight
                if (_cart.Freight)
                {
                    if (Boat != null)
                    {
                        if(Boat.AddFreight())
                        {
                            // Boat is full
                            Boat = null;
                            Points += 10;
                        }

                        Points++;
                    }
                }
            }

            return true;
        }

        public override bool SetCart(Rails from, Cart cart)
        {
            return base.SetCart(from, cart);
        }
    }
}
