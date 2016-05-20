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
    class EnemyManager
    {
        private Texture2D texture;
        public List<Enemy> enemies;
        private Rectangle screenBounds;
        private Rectangle enemyBounds;
        private Random rand = new Random(System.Environment.TickCount);

        public EnemyManager(Texture2D texture, Rectangle screenBounds)
        {
            this.texture = texture;
            this.screenBounds = screenBounds;
            this.enemyBounds = new Rectangle(64, 64, this.screenBounds.Width-64, this.screenBounds.Height / 2);

            enemies = new List<Enemy>();
        }

        public void AddEnemies(int level, int count)
        {
            if (level <= 1)
            {
                for (int i = 0; i < count; i++)
                {
                    enemies.Add(new EnemyLevel1(texture, new Vector2(100 + i*97, 100), new Rectangle(415, 0, 97, 97), enemyBounds, rand));
                }
            }

        }

        public void Update(GameTime gameTime)
        {
            foreach (Enemy e in enemies)
            {
                e.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy e in enemies)
            {
                e.Draw(spriteBatch);
            }
        }
    }
}
