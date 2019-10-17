using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Switch : Rails
    {
        public List<Block> From { get; set; }
        public new List<Block> PossibleTo { get; set; }

        public int Key;

        public int Count { get; private set; }

        public override Block To
        {
            get
            {
                return PossibleTo[Count % PossibleTo.Count];
            }
        }


        public Switch(RailType type, int key) : base(type)
        {
            From = new List<Block>();
            PossibleTo = new List<Block>();
            Key = key;
        }

        public override bool SetCart(Rails from, Cart cart)
        {
            if (From[Count % From.Count] != from)
            {
                return false;
            }

            return base.SetCart(from, cart);
        }

        public void Toggle()
        {
            Count++;
        }
    }
}
