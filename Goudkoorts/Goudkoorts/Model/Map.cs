using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Map
    {
        public Rails[,] _map;
        private List<Runnable> _runnables;

        public Map()
        {
            // _map = mapBuilder.GetMap();
            // _runnable = mapBuilder.GetRunnable();

            var mapBuilder = new MapBuilder();
            _map = mapBuilder.GetMap();

            
        }
    }
}
