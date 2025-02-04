﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Warehouse : Rails, IRunnable
    {

        public char Key { get; private set; }

        public Warehouse(RailType type, char key) : base(type)
        {
            Key = key;
        }

        public new bool Run(Random random, Action<Cart> callback)
        {
            int a = random.Next(100);

            if (a < 10)
            {
                Spawn(callback);
            }

            return true;
        }

        private void Spawn(Action<Cart> callback)
        {
            Cart cart = new Cart() { Rails = (Rails)To };
            ((Rails)To).SetCart(null, cart);

            callback(cart);
        }
    }
}
