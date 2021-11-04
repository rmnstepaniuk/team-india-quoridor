using System;
using System.Collections.Generic;

namespace Quoridor
{
    class Player
    {
        // Player parameters
        private int[] coordinates;
        private int wallQuantity;
        private String side;

        // Constructors and Destructors
        public Player(String side)
        {
            this.side = side;
            if (this.side == "white")
            {
                this.coordinates = new int[2] { 8, 4 };
                this.wallQuantity = 10;
            }
            else
            {
                this.coordinates = new int[2] { 0, 4 };
                this.wallQuantity = 10;
            }
        }

        public override String ToString()
        {
            String str = String.Format("Player : {0}\n" +
                                        "Walls left : {1}\n" +
                                        "Coordinates : ({2}, {3})\n",
                                        this.side, this.wallQuantity, this.coordinates[0], this.coordinates[1]);
            return str;
        }
    }
}
