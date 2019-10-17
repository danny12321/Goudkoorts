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

        public Map()
        {
            // _map = mapBuilder.GetMap();
            // _runnable = mapBuilder.GetRunnable();

            var mapBuilder = new MapBuilder();
            MapData = mapBuilder.GetMap();

            Runnables.AddRange(mapBuilder.Warehouses);
            Runnables.AddRange(mapBuilder.Switches);
        }

        public void ChangeSwitch(int key)
        {
            if (key > 0 && key < Runnables.Count)
            {
                Runnables.Where(s => s is Switch && ((Switch)s).Key == key).ToList().ForEach(s => ((Switch)s).Toggle());
            }
        }
    }
}
