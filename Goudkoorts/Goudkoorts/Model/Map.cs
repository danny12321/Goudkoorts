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

        public List<IRunnable> Runnables = new List<IRunnable>();

        public List<Switch> Switches;

        public Map()
        {
            var mapBuilder = new MapBuilder();
            MapData = mapBuilder.GetMap();

            Runnables.AddRange(mapBuilder.Warehouses);
            Runnables.Add(mapBuilder.Wharf);
            Switches = mapBuilder.Switches;

        }

        public void ChangeSwitch(int key)
        {
            if (key > 0 && key <= Switches.Count)
            {
                Switches.Where(s => s.Key == key).ToList().ForEach(s => s.Toggle());
            }
        }
    }
}
