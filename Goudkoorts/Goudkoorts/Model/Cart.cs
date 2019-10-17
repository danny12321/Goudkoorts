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


            var oldRails = Rails;

            if (Rails.To != null && ((Rails)Rails.To).SetCart(Rails, this))
            {
                oldRails.RemoveCart();
            }
            else
            {
                // Cart couldnt move
            }
        }
    }
}
