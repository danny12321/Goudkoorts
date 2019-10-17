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
        private bool _god;

        public Goudkoorts(bool god)
        {
            _god = god;

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
            var dead = false;

            while (!dead || _god)
            {
                _view.RenderMap();
                if (dead) Console.WriteLine("\nShould be dead");

                dead = !RunRunnables();


                Thread.Sleep(_timer);
            }


            Console.WriteLine("\nGame is over");
        }

        private bool RunRunnables()
        {
            bool dead = false;
            Random random = new Random();
            var tempCartList = new List<Cart>();

            // Run all the Runnables
            foreach (var r in Map.Runnables)
            {
                dead = !r.Run(random, (cart) =>
                {
                    tempCartList.Add(cart);
                });

                if (dead) return false;
            }

            Map.Runnables.AddRange(tempCartList);

            return true;
        }
    }
}
