﻿using System;
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
    class EnemyLevel1 : Enemy
    {
        private int dir = 0;
        private float directionChangeTime = 0f;
        private Random rand;

        public EnemyLevel1(Texture2D texture, Vector2 location, Rectangle initialFrame, Rectangle screenBounds, Random rand) : base(texture, location, initialFrame, screenBounds)
        {
            this.level = 1;
            this.enemySprite.Velocity = new Vector2(0, 10);
            this.rand = rand;
            directionChangeTime = rand.Next(0, 1200);
        }

        public override void Update(GameTime gameTime)
        {
            directionChangeTime += (float)gameTime.ElapsedGameTime.Milliseconds;

            // Make this enemy move in a special way
            if (directionChangeTime > 1200f)
            {
                directionChangeTime = 0;
                this.enemySprite.Velocity = new Vector2(rand.Next(-100, 100), rand.Next(-100, 100));

                base.Update(gameTime);

                this.enemySprite.Location = new Vector2(MathHelper.Clamp(this.enemySprite.Center.X, screenBounds.Left, screenBounds.Right),
                                                                           MathHelper.Clamp(this.enemySprite.Center.Y, screenBounds.Top, screenBounds.Bottom));

                if (!this.enemySprite.IsBoxColliding(screenBounds))
                {
                   
                    this.enemySprite.Velocity *= -1;
                }

                base.Update(gameTime);
            }


            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}