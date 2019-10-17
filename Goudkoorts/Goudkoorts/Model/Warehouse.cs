using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Warehouse : Rails, IRunnable
    {
        private Map _map;

        public Warehouse(RailType type, Map map) : base(type)
        {
            _map = map;
        }

        public new void Run(Random random, Action<Cart> callback)
        {
            int a = random.Next(100);

            if (a < 10)
            {
                Spawn(callback);
            }
        }

        private void Spawn(Action<Cart> callback)
        {
            Cart cart = new Cart();
            ((Rails)To).SetCart(null, cart);

            callback(cart);
        }
    }
}
