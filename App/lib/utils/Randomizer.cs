using OpenTK.Graphics;
using System;

namespace App.lib.utils
{
    public class Randomizer
    {
        private Random r;

        public Randomizer()
        {
            r = new Random();
        }

        public Color4 RandomColor()
        {
            float genR = (float)r.NextDouble();
            float genG = (float)r.NextDouble();
            float genB = (float)r.NextDouble();

            Color4 col = new Color4(genR, genG, genB, 1.0f);

            return col;
        }

    }
}
