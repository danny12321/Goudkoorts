﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    interface IRunnable
    {
        bool Run(Random random, Action<Cart> callback);
    }
}
