using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Warehouse : Rails
    {
        public Warehouse(RailType type) : base(type)
        {

        }

        public override void Run()
        {
            Random rnd = new Random();
            int a = rnd.Next(100);

            if (a < 10)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            Cart cart = new Cart();
            ((Rails)To).SetCart(null, cart);
        }
    }
}
