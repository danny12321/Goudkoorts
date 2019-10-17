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
        private List<Cart> _tempCartList = new List<Cart>();

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
                ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input

                // We check input for a Digit
                if (char.IsDigit(UserInput.KeyChar))
                {
                    int key = int.Parse(UserInput.KeyChar.ToString());
                    Map.ChangeSwitch(key);
                    _view.RenderMap();
                }
            }
        }


        private void Run()
        {
            Random random = new Random();

            while (true)
            {
                _view.RenderMap();

                // Run all the Runnables
                Map.Runnables.ForEach(r => r.Run(random, (cart) =>
                {
                    _tempCartList.Add(cart);
                }));

                Map.Runnables.AddRange(_tempCartList);

                Thread.Sleep(_timer);
            }
        }
    }
}
