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
    class EnemyLevel1 : Enemy
    {
        private int dir = 0;
        private float directionChangeTime = 0f;
        private Random rand;
        private ShotManager enemyShotManager;

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
                Vector2 vel = new Vector2(rand.Next(-100, 100)*0, rand.Next(-100, 100));


                /*
                this.enemySprite.Location = new Vector2(MathHelper.Clamp(this.enemySprite.Center.X, screenBounds.Left, screenBounds.Right)/1.13f,
                                                                           MathHelper.Clamp(this.enemySprite.Center.Y, screenBounds.Top, screenBounds.Bottom)/1.11f);
                */
                /*
                if (!this.enemySprite.IsBoxColliding(screenBounds))
                {
                   
                    this.enemySprite.Velocity *= -1;
                }
                */
                this.enemySprite.Velocity = vel;

            }

            if ((this.enemySprite.Center.Y > 300 && this.enemySprite.Velocity.Y > 0) ||
                (this.enemySprite.Center.Y < 50 && this.enemySprite.Velocity.Y < 0)
                )
            {
                this.enemySprite.Velocity = this.enemySprite.Velocity * new Vector2(1, -1);
            }



            

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
