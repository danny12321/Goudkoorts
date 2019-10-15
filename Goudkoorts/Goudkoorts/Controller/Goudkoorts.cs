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
        private int _speed = 1000;
        private ConsoleView _view = new ConsoleView();
        private Map _map;

        public Goudkoorts()
        {
            _map = new Map();

            _view.Welcome();
            Run();
        }


        private void Run()
        {


            while (true)
            {
                _view.RenderMap();

                Thread.Sleep(_speed);
            }
        }
    }
}
