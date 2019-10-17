using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Boat : IRunnable
    {
        private int _maxPoints = 5;

        public int Points { get; private set; }
        public Boat()
        {
            Points = 0;
        }

        public bool AddFreight()
        {
            Points++;

            return Points >= _maxPoints;
        }

        public bool Run(Random random, Action<Cart> callback)
        {
            return true;
        }
    }
}
