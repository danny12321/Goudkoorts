using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Map
    {
        private List<List<Rails>> _map;
        private List<Runnable> _runnables;

        public Map()
        {
            MapBuilder mapBuilder = new MapBuilder();
            // _map = mapBuilder.GetMap();
            // _runnable = mapBuilder.GetRunnable();
        }
    }
}
