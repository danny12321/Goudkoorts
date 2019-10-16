using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Goudkoorts.Model;
using Goudkoorts.View;

namespace Goudkoorts.Controller
{
    class Goudkoorts
    {
        private int _timer = 1000;
        private ConsoleView _view;
        public Map Map;
        private int cycle = 0;

        public Goudkoorts()
        {
            _view = new ConsoleView(this);
            Map = new Map();

            _view.Welcome();

            new Thread(new ThreadStart(WatchInput)).Start();
            Run();
        }

        private void WatchInput()
        {
            while (true)
            {
                var key = Convert.ToInt32(Console.ReadKey().Key);
                Map.ChangeSwitch(key);
                _view.RenderMap();

            }
        }


        private void Run()
        {
            Random random = new Random();

            while (true)
            {
                _view.RenderMap();

                Map.Carts.ForEach(c => c.Run(random));
                Map.Warehouses.ForEach(w => w.Run(random));

                // for (int y = 0; y < Map.MapData.GetLength(0); y++)
                // {
                //     for (int x = 0; x < Map.MapData.GetLength(1); x++)
                //     {
                // 
                //         if (Map.MapData[y, x] is IRunnable)
                //         {
                //             ((IRunnable) Map.MapData[y, x])?.Run(random);
                //         }
                //     }
                // }

                cycle++;
                Thread.Sleep(_timer);
            }
        }
    }
}
