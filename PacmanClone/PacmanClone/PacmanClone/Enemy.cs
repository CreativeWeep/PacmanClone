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
        private Sprite enemySprite;
        public int level = 1;
        public bool isDestroyed = false;
        private int enemyRadius = 15;


        public Enemy(Texture2D texture, Vector2 location, Rectangle initialFrame, Rectangle screenBounds)
        {
            enemySprite = new Sprite(
                location,
                texture,
                initialFrame,
                Vector2.Zero);

            enemySprite.CollisionRadius = enemyRadius;
        }



        public void MoveRight()
        {
            enemySprite.Location += new Vector2(5, 0);
        }
        public void MoveLeft()
        {
            enemySprite.Location -= new Vector2(5, 0);
        }
        public void MoveUp()
        {
            enemySprite.Location -= new Vector2(0, 5);
        }



        public bool IsActive()
        {
            if (isDestroyed)
            {
                return false;
            }
            return true;
        }



        public void Update(GameTime gameTime)
        {
            if (IsActive())
            {
                enemySprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsActive())
            {
                enemySprite.Draw(spriteBatch);
            }
        }
    }
}
