﻿using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Program
    {
        static void Main(string[] args)
        {
            
            new Controller.Goudkoorts(args.Length > 0);
        }
    }
}
