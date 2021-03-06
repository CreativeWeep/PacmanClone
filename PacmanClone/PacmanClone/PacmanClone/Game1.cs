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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Rectangle screenBounds;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D Ship;
        Texture2D enemySheet;
        Player player;
        EnemyManager enemyManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screenBounds = new Rectangle(0, 0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height);
            

            Ship = Content.Load<Texture2D>("SpriteSheet");
            background = Content.Load<Texture2D>("background");
            enemySheet = Content.Load<Texture2D>("enemyships");
            player = new Player(Ship, new Rectangle(0, 0, 38, 56), screenBounds);

            enemyManager = new EnemyManager(enemySheet, new Rectangle(0,0, this.Window.ClientBounds.Width, this.Window.ClientBounds.Height));
            enemyManager.AddEnemies(1, 4); // Add 10 level 1 enemies
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            for (int i = 0; i < player.playerShotManager.Shots.Count; i++)
            {
                for (int j = 0; j < enemyManager.enemies.Count; j++)
                {
                    if (player.playerShotManager.Shots[i].IsCircleColliding(enemyManager.enemies[j].enemySprite.Center, 32))
                    {
                        enemyManager.enemies[j].isDestroyed = true;
                    }
                }
                
            }
            for (int i = 0; i < enemyManager.enemies.Count; i++)
            {
                for (int j = 0; j < enemyManager.enemies[i].enemyShotmanager.Shots.Count; j++)
                {
                    if (enemyManager.enemies[i].enemyShotmanager.Shots[j].IsCircleColliding(player.character.Center, 20))
                    {
                        player.isDestroyed = true;
                    }
                }
            }

            player.Update(gameTime);
            enemyManager.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 1024, Window.ClientBounds.Height), Color.White);
            player.Draw(spriteBatch);
            enemyManager.Draw(spriteBatch);

            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
