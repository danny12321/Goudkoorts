using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goudkoorts.Model;

namespace Goudkoorts.View
{
    class ConsoleView
    {
        private Controller.Goudkoorts _controller;

        public ConsoleView(Controller.Goudkoorts controller)
        {
            _controller = controller;
        }

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
            Console.WriteLine("This is a map. \n");


            var map = _controller.Map.MapData;

            for (int y = 0; y < map.GetLength(0); y++)
            {

                for (int height = 0; height < 3; height++)
                {
                    // Create new line
                    Console.WriteLine();

                    for (int x = 0; x < map.GetLength(1); x++)
                    {
                        var a = map[y, x];
                        if (a is Wharf)
                        {
                            RenderWharf(height);
                        }
                        else if (a is Switch)
                        {
                            RenderSwitch(height);
                        }
                        else if (a is Parking)
                        {
                            RenderParking(height);
                        }
                        else if(a is Warehouse)
                        {
                            RenderWarehouse(height);
                        }
                        else if (a is Rails)
                        {
                            RenderRails(height);
                        }
                        else
                        {
                            Console.Write("   ");
                        }

                    }
                }
            }
        }

        private void RenderRails(int h)
        {
            if (h == 0) Console.Write("   ");
            else if (h == 1) Console.Write("███");
            else if (h == 2) Console.Write("   ");
        }

        private void RenderWharf(int h)
        {
            if (h == 0) Console.Write(" K ");
            else if (h == 1) Console.Write("███");
            else if (h == 2) Console.Write("   ");
        }

        private void RenderSwitch(int h)
        {
            if (h == 0) Console.Write(" █ ");
            else if (h == 1) Console.Write(" ██");
            else if (h == 2) Console.Write(" █ ");
        }

        private void RenderParking(int h)
        {
            if (h == 0) Console.Write("   ");
            else if (h == 1) Console.Write("▓▓▓");
            else if (h == 2) Console.Write("   ");
        }

        private void RenderWarehouse(int h)
        {
            if (h == 0) Console.Write(" - ");
            else if (h == 1) Console.Write("|1|");
            else if (h == 2) Console.Write(" - ");
        }
    }
}
