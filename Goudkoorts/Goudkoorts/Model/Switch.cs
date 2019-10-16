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

        public override Block To
        {
            get
            {
                return PossibleTo[Key % PossibleTo.Count];
            }
        }

        public int Key = 1;

        public Switch(RailType type) : base(type)
        {
            From = new List<Block>();
            PossibleTo = new List<Block>();
        }

        public override bool SetCart(Rails from, Cart cart)
        {
            if (From[Key % From.Count] != from)
            {
                return false;
            }

            return base.SetCart(from, cart);
        }

        public void Toggle()
        {
            Key++;
        }
    }
}
