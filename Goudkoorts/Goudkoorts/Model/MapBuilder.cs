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

        public Rails[,] GetMap()
        {
            Rails[,] map = new Rails[8,12];

            // De map wordt vanaf links boven gemaakt
            // Bovenste rij
            for (int i = 0; i < 12; i++)
            {
                if (i == 9)
                {
                    map[0, i] = new Wharf(RailType.HORIZONTAL);
                }
                else
                {
                    if(i == 11)
                    {
                        map[0, i] = new Rails(RailType.BOTTOMLEFT);
                    } else
                    {
                        map[0, i] = new Rails(RailType.HORIZONTAL);
                    }
                }
            }

            //Rechts boven
            for (int i = 1; i < 4; i++)
            {
                if(i == 3)
                {
                    map[i, 11] = new Rails(RailType.TOPLEFT);
                } else
                {
                    map[i, 11] = new Rails(RailType.VERTICAL);
                }
            }

            map[3, 10] = new Rails(RailType.HORIZONTAL);
            map[3, 9] = new Switch(RailType.TOPRIGHT);

            for (int i = 5; i < 10; i++)
            {
                if(i == 9)
                {
                    map[2, i] = new Rails(RailType.BOTTOMLEFT);
                } else if(i == 5)
                {
                    map[2, i] = new Rails(RailType.BOTTOMRIGHT);

                } else
                {
                    map[2, i] = new Rails(RailType.HORIZONTAL);
                }
            }

            map[3, 5] = new Switch(RailType.TOPLEFT);
            map[3, 4] = new Rails(RailType.HORIZONTAL);
            map[3, 3] = new Switch(RailType.BOTTOMRIGHT);

            for (int i = 1; i < 4; i++)
            {
                if(i == 3)
                {
                    map[2, i] = new Rails(RailType.BOTTOMLEFT);
                } else
                {
                    map[2, i] = new Rails(RailType.HORIZONTAL);
                }
            }

            for (int i = 1; i < 4; i++)
            {
                if(i == 3)
                {
                    map[4, i] = new Rails(RailType.TOPLEFT);
                } else
                {
                    map[4, i] = new Rails(RailType.HORIZONTAL);
                }
            }

            map[4, 5] = new Rails(RailType.TOPRIGHT);
            map[4, 6] = new Rails(RailType.BOTTOMLEFT);
            map[4, 8] = new Rails(RailType.BOTTOMRIGHT);
            map[4, 9] = new Rails(RailType.TOPLEFT);

            map[5, 6] = new Switch(RailType.BOTTOMRIGHT);
            map[5, 7] = new Rails(RailType.HORIZONTAL);
            map[5, 8] = new Switch(RailType.BOTTOMLEFT);

            for (int i = 1; i < 7; i++)
            {
                if (i == 6)
                {
                    map[6, i] = new Rails(RailType.TOPLEFT);
                } else
                {
                    map[6, i] = new Rails(RailType.HORIZONTAL);
                }
            }

            for (int i = 8; i < 12; i++)
            {
                if(i == 8)
                {
                    map[6, i] = new Rails(RailType.TOPRIGHT);

                } else if(i == 11)
                {

                    map[6, i] = new Rails(RailType.BOTTOMLEFT);
                } else
                {
                    map[6, i] = new Rails(RailType.HORIZONTAL);
                }
            }

            for (int i = 1; i < 9; i++)
            {
                map[7, i] = new Parking(RailType.HORIZONTAL);
            }

            for (int i = 8; i < 12; i++)
            {
                if(i == 11)
                {
                    map[7, i] = new Rails(RailType.TOPLEFT);
                } else
                {
                    map[7, i] = new Rails(RailType.HORIZONTAL);
                }
            }

            LinkMap(map);

            return map;
        }

        private void LinkMap(Rails[,] map)
        {
            for (int i = 11; i <= 1; i--)
            {
                map[0, i].To = map[0, i - 1];
            }

            for (int i = 3; i <= 1; i--)
            {
                map[i, 11].To = map[i - 1, 11];
            }

            map[10, 3].To = map[11, 3];

            ((Switch)map[9, 3]).To.Add(map[10, 3]);
            ((Switch)map[9, 3]).From.Add(map[9, 2]);
            ((Switch)map[9, 3]).From.Add(map[9, 4]);

            map[9, 2].To = map[9, 3];
            map[8, 2].To = map[9, 2];
            map[7, 2].To = map[8, 2];
            map[6, 2].To = map[7, 2];
            map[5, 2].To = map[6, 2];

            ((Switch)map[5, 3]).To.Add(map[5, 2]);
            ((Switch)map[5, 3]).To.Add(map[5, 4]);
            ((Switch)map[5, 3]).From.Add(map[4, 3]);

            map[4, 3].To = map[5, 3];

            ((Switch)map[3, 3]).To.Add(map[4, 3]);
            ((Switch)map[3, 3]).From.Add(map[3, 2]);
            ((Switch)map[3, 3]).From.Add(map[3, 4]);

            map[4, 3].To = map[5, 3];
            // Wip
        }
    }
}
