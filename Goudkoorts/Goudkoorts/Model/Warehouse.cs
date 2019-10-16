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

        public void Run(Random random)
        {
            int a = random.Next(100);

            if (a < 10)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            Cart cart = new Cart();
            ((Rails)To).SetCart(null, cart);

            _map.Carts.Add(cart);
        }
    }
}
