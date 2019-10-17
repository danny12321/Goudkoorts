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
        private List<Switch> _switches = new List<Switch>();
        public List<Cart> Carts = new List<Cart>();
        public List<Warehouse> Warehouses = new List<Warehouse>();

        public Map()
        {
            // _map = mapBuilder.GetMap();
            // _runnable = mapBuilder.GetRunnable();

            var mapBuilder = new MapBuilder(this);
            MapData = mapBuilder.GetMap();
            Warehouses = mapBuilder.Warehouses;


        }

        public void ChangeSwitch(int key)
        {

            _switches[key].Toggle();
            if (key >= 0 && key < _switches.Count)
            {
                _switches.Find(s => s.Key == key).Toggle();
            }
        }
    }
}
