using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class MapBuilder
    {
        public MapBuilder()
        {

            
        }

        public List<List<Rails>> GetMap()
        {
            var map = new List<List<Rails>>();

            // De map wordt vanaf links boven gemaakt
            // Bovenste rij
            for (int i = 0; i < 12; i++)
            {
                if (i == 9)
                {
                    map[0][i] = new Warehouse();
                }
                else
                {
                    map[0][i] = new Rails();
                }
            }

            //Rechts bove
            for (int i = 0; i < 3; i++)
            {
                map[i][11] = new Rails();
            }

            map[3][10] = new Rails();
            map[3][9] = new Switch();

            for (int i = 5; i < 10; i++)
            {
                map[2][i] = new Rails();
            }

            map[3][5] = new Switch();
            map[3][4] = new Rails();
            map[3][3] = new Switch();

            for (int i = 1; i < 3; i++)
            {
                map[2][i] = new Rails();
            }

            for (int i = 1; i < 3; i++)
            {
                map[4][i] = new Rails();
            }

            map[4][5] = new Rails();
            map[4][6] = new Rails();
            map[4][8] = new Rails();
            map[4][9] = new Rails();

            map[5][6] = new Switch();
            map[5][7] = new Rails();
            map[5][8] = new Switch();

            for (int i = 1; i < 7; i++)
            {
                map[6][i] = new Rails();
            }

            for (int i = 8; i < 12; i++)
            {
                map[6][i] = new Rails();
            }

            for (int i = 1; i < 9; i++)
            {
                map[7][i] = new Parking();
            }

            for (int i = 8; i < 12; i++)
            {
                map[7][i] = new Rails();
            }

            return map;
        }
    }
}
