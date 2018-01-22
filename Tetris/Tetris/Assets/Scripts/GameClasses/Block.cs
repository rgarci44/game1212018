using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GameClasses
{

    public enum BlockColor
    {
        White,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple
    }

    public class Block
    {

        public int x;
        public int y;

        public BlockColor color = BlockColor.White;


        public Block(int xPosition, int yPosititon)
        {
            this.x = xPosition;
            this.y = yPosititon;
        }

        public Block(int xPosition, int yPosititon, BlockColor blockColor)
        {
            this.x = xPosition;
            this.y = yPosititon;
            this.color = blockColor;

        }
    }
}
