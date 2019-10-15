using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.View
{
    class ConsoleView
    {

        public void Welcome()
        {
            Console.WriteLine("Welcome to Goudkoorts!");
            Console.WriteLine("Currently there is only one level.");
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
        }

        public void RenderMap()
        {
            Console.Clear();
            Console.WriteLine("This is a map.");
        }
    }
}
