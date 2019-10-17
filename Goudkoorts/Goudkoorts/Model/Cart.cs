using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Cart : IRunnable
    {
        public Rails Rails { get; set; }

        public bool Run(Random random, Action<Cart> callback)
        {
            return Move();
        }

        private bool Move()
        {
            // Return true if you won't be dead

            // Sometimes null pointer
            if (Rails.To != null)
            {
                var cartHasSet = ((Rails)Rails.To).SetCart(Rails, this);

                if (cartHasSet)
                {
                    var to = Rails.To;

                    Rails.RemoveCart();
                    Rails = (Rails)to;

                    return true;
                }
                else
                {
                    if (Rails is Parking) return true;
                    if (Rails.To is Switch) return true;

                    return false;
                }
            }
            else
            {
                // Cart couldnt move
                // Delete cart
                Rails.RemoveCart();
                Rails = null;

                return true;
            }
        }
    }
}
