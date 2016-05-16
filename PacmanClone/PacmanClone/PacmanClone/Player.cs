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
    class Player
    {
        public Sprite character;
        private Rectangle playerAreaLimit;
        private int playerRadius = 15;
        public ShotManager playerShotManager;

       
        private float shotTimer = 0.0f;
        private float minShotTimer = 0.2f;


        public Player(Texture2D texture, Rectangle initialFrame, Rectangle screenBounds)
        {
            character = new Sprite(new Vector2(360, 380), texture, initialFrame, Vector2.Zero);

            playerAreaLimit = new Rectangle(0,screenBounds.Height / 2, screenBounds.Width, screenBounds.Height / 2);

            character.CollisionRadius = playerRadius;

            playerShotManager = new ShotManager(
                texture,
                new Rectangle(23, 67, 9, 33),
                1,
                2,
                240f,
                screenBounds);

            
            
        }


        private void FireShot()
        {
            if (shotTimer >= minShotTimer)
            {
                playerShotManager.FireShot(
                    new Vector2(character.Location.X+15, character.Location.Y+5),
                    new Vector2(0, -1),
                    true);
                shotTimer = 0.0f;
            }
        }



        private void HandleKeyboardInput(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Right))
                character.Velocity += new Vector2(1, 0);
            if (keyState.IsKeyDown(Keys.Left))
                character.Velocity += new Vector2(-1, 0);
            if (keyState.IsKeyDown(Keys.Space))
                FireShot();
        }

        public void Update(GameTime gameTime)
        {
            playerShotManager.Update(gameTime);

            character.Velocity = Vector2.Zero;
            HandleKeyboardInput(Keyboard.GetState());
            character.Velocity.Normalize();
            shotTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (character.Location.X <= 0)
                character.Location = new Vector2(0, character.Location.Y);
            if (character.Location.X >= 759)
                character.Location = new Vector2(759, character.Location.Y);
            character.Velocity *= 160.06f;
            character.Update(gameTime);
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            playerShotManager.Draw(spriteBatch);
            character.Draw(spriteBatch);
        }



    }
}
