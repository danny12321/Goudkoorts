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


            while (true)
            {
                _view.RenderMap();

                Thread.Sleep(_timer);
            }
        }
    }
}
