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


        public Player(Texture2D texture, Rectangle initialFrame, Rectangle screenBounds)
        {
            character = new Sprite(new Vector2(360, 380), texture, initialFrame, Vector2.Zero);

            playerAreaLimit = new Rectangle(0,screenBounds.Height / 2, screenBounds.Width, screenBounds.Height / 2);

            character.CollisionRadius = playerRadius;
        }

        private void HandleKeyboardInput(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Keys.Right))
                character.Velocity += new Vector2(1, 0);
            if (keyState.IsKeyDown(Keys.Left))
                character.Velocity += new Vector2(-1, 0);
        }

        public void Update(GameTime gameTime)
        {
            character.Velocity = Vector2.Zero;
            HandleKeyboardInput(Keyboard.GetState());
            character.Velocity.Normalize();
            if (character.Location.X <= 0)
                character.Location = new Vector2(0, character.Location.Y);
            if (character.Location.X >= 720)
                character.Location = new Vector2(720, character.Location.Y);
            character.Velocity *= 160.06f;
            character.Update(gameTime);
        }

        
        public void Draw(SpriteBatch spriteBatch)
        {
            character.Draw(spriteBatch);
        }



    }
}
