using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PacmanClone
{
    class Enemy
    {
        private Sprite enemy;
        private Rectangle screenBounds;
        private float shotTimer= 0.0f;
        private float shotTimeMax = 1f;
    }
}
