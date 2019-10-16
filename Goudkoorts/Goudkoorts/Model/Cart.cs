using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Cart : Runnable
    {
        private Rails _rails;

        public override void Run()
        {
            Move();
        }

        private void Move()
        {
            if (_rails.To != null && _rails.To.SetCart(_rails, this))
            {
                _rails.RemoveCart();
                _rails = _rails.To;
            }
            else
            {
                // Cart couldnt move
            }
        }
    }
}
