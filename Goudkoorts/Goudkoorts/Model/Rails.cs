﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Rails : Block
    {
        private Cart _cart;
        public Rails To { get; set; }
        public RailType RailType { get; set; }

        public Rails(RailType type)
        {
            RailType = type;
        }


        public virtual bool SetCart(Rails from, Cart cart)
        {
            if (_cart == null)
            {
                _cart = cart;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveCart()
        {
            _cart = null;
        }
    }
}
