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
        private ConsoleView _view;
        public Map Map;
        private bool _god;
        private bool _dead;

        public int Frame { get; private set; }
        public int FreezeTime = 15;

        public bool FreezeControls
        {
            get
            {
                return Frame % FreezeTime == 0;
            }
        }

        public Goudkoorts(bool god)
        {
            _god = god;

            _view = new ConsoleView(this);
            Map = new Map();

            _view.Welcome();

            new Thread(new ThreadStart(WatchInput)).Start();
            Run();

            // Hou de console open.
            Console.ReadKey();
        }

        private void WatchInput()
        {
            while (!_dead)
            {
                ConsoleKeyInfo UserInput = Console.ReadKey(); // Get user input
                if (FreezeControls) continue;

                // We check input for a Digit
                if (char.IsDigit(UserInput.KeyChar))
                {
                    int key = int.Parse(UserInput.KeyChar.ToString());
                    Map.ChangeSwitch(key);

                    if (!_dead) _view.RenderMap();
                }
            }
        }


        private void Run()
        {
            while (!_dead || _god)
            {

                _dead = !RunRunnables();

                Frame++;

                _view.RenderMap();

                if (_dead) Console.WriteLine("\nShould be dead");
                Thread.Sleep(2000 / (Map.GetPoints() / 5 + 1));
            }

            _view.GameOver();
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
