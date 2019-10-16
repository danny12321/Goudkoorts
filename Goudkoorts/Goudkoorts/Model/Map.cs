using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Map
    {
        public Block[,] MapData { get; }
        private List<Runnable> _runnables;
        private List<Switch> _switches= new List<Switch>();

        public Map()
        {
            // _map = mapBuilder.GetMap();
            // _runnable = mapBuilder.GetRunnable();

            var mapBuilder = new MapBuilder();
            MapData = mapBuilder.GetMap();


        }

        public void ChangeSwitch(int key)
        {
            if (key >= 0 && key < _switches.Count)
            {
                _switches.Find(s => s.Key == key).Toggle();
            }
        }
    }
}
