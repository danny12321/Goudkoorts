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
        private bool _isRendering = false;

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
            if (_isRendering) return;
            _isRendering = true;

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
                            RenderSwitch((Switch) a, height);
                        }
                        else if (a is Parking)
                        {
                            RenderParking((Rails)a, height);
                        }
                        else if (a is Warehouse)
                        {
                            RenderWarehouse((Warehouse) a, height);
                        }
                        else if (a is Rails)
                        {
                            RenderRails((Rails) a, height);
                        }
                        else
                        {
                            Console.Write("   ");
                        }

                    }
                }
            }

            _isRendering = false;
        }

        private void RenderRails(Rails rail, int h)
        {
            char c = rail.HasCart() ? 'k' : '░';

            switch (rail.RailType)
            {
                case RailType.HORIZONTAL:
                    if (h == 0) Console.Write($" {c} ");
                    else if (h == 1) Console.Write("███");
                    else if (h == 2) Console.Write("   ");
                    break;

                case RailType.VERTICAL:
                    if (h == 0) Console.Write(" █ ");
                    else if (h == 1) Console.Write($" █{c}");
                    else if (h == 2) Console.Write(" █ ");
                    break;

                case RailType.BOTTOMLEFT:
                    if (h == 0) Console.Write("   ");
                    else if (h == 1) Console.Write("██ ");
                    else if (h == 2) Console.Write($"{c}█ ");
                    break;


                case RailType.BOTTOMRIGHT:
                    if (h == 0) Console.Write("   ");
                    else if (h == 1) Console.Write(" ██");
                    else if (h == 2) Console.Write($" █{c}");
                    break;

                case RailType.TOPLEFT:
                    if (h == 0) Console.Write($"{c}█ ");
                    else if (h == 1) Console.Write("██ ");
                    else if (h == 2) Console.Write("   ");
                    break;

                case RailType.TOPRIGHT:
                    if (h == 0) Console.Write($" █{c}");
                    else if (h == 1) Console.Write(" ██");
                    else if (h == 2) Console.Write("   ");
                    break;
            }

        }

        private void RenderWharf(int h)
        {
            if (h == 0) Console.Write(" K ");
            else if (h == 1) Console.Write("███");
            else if (h == 2) Console.Write("   ");
        }

        private void RenderSwitch(Switch s, int h)
        {
            char c = s.HasCart() ? 'k' : '░';
            RailType type = s.RailType;


            if ((s.Count % 2) == 1)
            {
                switch(s.RailType)
                {
                    case RailType.BOTTOMLEFT:
                        type = RailType.TOPLEFT;
                        break;
                    case RailType.BOTTOMRIGHT:
                        type = RailType.TOPRIGHT;
                        break;
                    case RailType.TOPLEFT:
                        type = RailType.BOTTOMLEFT;
                        break;
                    case RailType.TOPRIGHT:
                        type = RailType.BOTTOMRIGHT;
                        break;
                }
            }

            switch(type)
            {
                case RailType.BOTTOMLEFT:
                    if (h == 0) Console.Write($"{s.Key}▒ ");
                    else if (h == 1) Console.Write($"██{c}");
                    else if (h == 2) Console.Write(" █ ");
                    break;

                case RailType.BOTTOMRIGHT:
                    if (h == 0) Console.Write($" ▒{s.Key}");
                    else if (h == 1) Console.Write($"{c}██");
                    else if (h == 2) Console.Write(" █ ");
                    break;

                case RailType.TOPLEFT:
                    if (h == 0) Console.Write($"{s.Key}█ ");
                    else if (h == 1) Console.Write($"██{c}");
                    else if (h == 2) Console.Write(" ▒ ");
                    break;

                case RailType.TOPRIGHT:
                    if (h == 0) Console.Write($" █{s.Key}");
                    else if (h == 1) Console.Write($"{c}██");
                    else if (h == 2) Console.Write(" ▒ ");
                    break;

                default:
                    Console.WriteLine("idk");
                    break;
            }
        }

        private void RenderParking(Rails rail, int h)
        {
            char c = rail.HasCart() ? 'k' : '░';

            if (h == 0) Console.Write($" {c} ");
            else if (h == 1) Console.Write("▓▓▓");
            else if (h == 2) Console.Write("   ");
        }

        private void RenderWarehouse(Warehouse w, int h)
        {
            if (h == 0) Console.Write(" - ");
            else if (h == 1) Console.Write($"|{w.Key}|");
            else if (h == 2) Console.Write(" - ");
        }
    }
}
