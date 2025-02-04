﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class MapBuilder
    {
        public List<Warehouse> Warehouses { get; set; }
        public List<Switch> Switches { get; set; }

        public Wharf Wharf { get; set; }

        public MapBuilder()
        {
            Warehouses = new List<Warehouse>();
            Switches = new List<Switch>();
        }

        public Block[,] GetMap()
        {
            Block[,] map = new Rails[8,12];

            // De map wordt vanaf links boven gemaakt
            // Bovenste rij
            for (int i = 0; i < 12; i++)
            {
                if (i == 9)
                {
                    var w = new Wharf(RailType.HORIZONTAL);
                    map[0, i] = w;
                    Wharf = w;
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

            var s1 = new Switch(RailType.TOPRIGHT, 3);
            map[3, 9] = s1;
            Switches.Add(s1);

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

            var s2 = new Switch(RailType.TOPLEFT, 2);
            map[3, 5] = s2;
            Switches.Add(s2);

            map[3, 4] = new Rails(RailType.HORIZONTAL);

            var s3 = new Switch(RailType.TOPRIGHT, 1);
            map[3, 3] = s3;
            Switches.Add(s3);

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

            var s4 = new Switch(RailType.TOPRIGHT, 4);
            map[5, 6] = s4;
            Switches.Add(s4);

            map[5, 7] = new Rails(RailType.HORIZONTAL);

            var s5 = new Switch(RailType.TOPLEFT,5);
            map[5, 8] = s5;
            Switches.Add(s5);

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

            // Warehouses
            var w1 = new Warehouse(RailType.HORIZONTAL, 'A');
            var w2 = new Warehouse(RailType.HORIZONTAL, 'B');
            var w3 = new Warehouse(RailType.HORIZONTAL, 'C');

            Warehouses.Add(w1);
            Warehouses.Add(w2);
            Warehouses.Add(w3);

            map[2, 0] = w1;
            map[4, 0] = w2;
            map[6, 0] = w3;

            map = LinkMap(map);

            return map;
        }

        private Block[,] LinkMap(Block[,] map)
        {
            for (int i = 11; i >= 1; i--)
            {
                map[0, i].To = map[0, i - 1];
            }

            for (int i = 3; i >= 1; i--)
            {
                map[i, 11].To = map[i - 1, 11];
            }

            map[3, 10].To = map[3, 11];

            ((Switch)map[3, 9]).PossibleTo.Add(map[3, 10]);
            ((Switch)map[3, 9]).From.Add(map[2, 9]);
            ((Switch)map[3, 9]).From.Add(map[4, 9]);

            map[2, 9].To = map[3, 9];
            map[2, 8].To = map[2, 9];
            map[2, 7].To = map[2, 8];
            map[2, 6].To = map[2, 7];
            map[2, 5].To = map[2, 6];

            ((Switch)map[3, 5]).PossibleTo.Add(map[2, 5]);
            ((Switch)map[3, 5]).PossibleTo.Add(map[4, 5]);
            ((Switch)map[3, 5]).From.Add(map[3, 4]);

            map[3, 4].To = map[3, 5];

            ((Switch)map[3, 3]).PossibleTo.Add(map[3, 4]);
            ((Switch)map[3, 3]).From.Add(map[2, 3]);
            ((Switch)map[3, 3]).From.Add(map[4, 3]);

            map[2, 3].To = map[3, 3];
            map[2, 2].To = map[2, 3];
            map[2, 1].To = map[2, 2];

            map[4, 3].To = map[3, 3];
            map[4, 2].To = map[4, 3];
            map[4, 1].To = map[4, 2];

            map[4, 5].To = map[4, 6];
            map[4, 6].To = map[5, 6];

            map[4, 8].To = map[4, 9];
            map[4, 9].To = map[3, 9];

            ((Switch)map[5, 6]).PossibleTo.Add(map[5, 7]);
            ((Switch)map[5, 6]).From.Add(map[4, 6]);
            ((Switch)map[5, 6]).From.Add(map[6, 6]);

            map[5, 7].To = map[5, 8];

            ((Switch)map[5, 8]).PossibleTo.Add(map[4, 8]);
            ((Switch)map[5, 8]).PossibleTo.Add(map[6, 8]);
            ((Switch)map[5, 8]).From.Add(map[5, 7]);

            for (int i = 6; i > 1; i--)
            {
                map[6, i - 1].To = map[6, i];
            }

            map[6, 6].To = map[5, 6];

            map[6, 8].To = map[6, 9];
            map[6, 9].To = map[6, 10];
            map[6, 10].To = map[6, 11];
            map[6, 11].To = map[7, 11];

            for (int i = 11; i >= 2; i--)
            {
                map[7, i].To = map[7, i - 1];
            }

            //Warehouses
            map[2, 0].To = map[2, 1];
            map[4, 0].To = map[4, 1];
            map[6, 0].To = map[6, 1];

            return map;
        }
    }
}
