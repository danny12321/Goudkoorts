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

        public void Run(Random random, Action<Cart> callback)
        {
            Move();
        }

        private void Move()
        {


            if (Rails.To != null)
            {

                var cartHasSet = ((Rails)Rails.To).SetCart(Rails, this);

                if (cartHasSet)
                {
                    var to = Rails.To;

                    Rails.RemoveCart();
                    Rails = (Rails)to;
                }
            }
            else
            {
                // Cart couldnt move
            }
        }
    }
}
