using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameHW2
{
    class Armor
    {
        Animation armor;
        public int forPayer;//เพื่อให้ทราบว่าใช่สำหรับplayerตัวไหน
        Vector2 Position;
        public bool Active;
        float elapse;

        public Armor(int frameWidth, int frameHeight, int frameCountCol, int frameCountRow)
        {
            int delay=100;
            bool looping = true;
            armor = new Animation(frameWidth, frameHeight, 5,4, delay, looping);
            Active = true;
            elapse = 0;
        }
        public void LoadContent(ContentManager Content)
        {
            armor.LoadContent(Content,"armor");
        }

        public void Update(GameTime gameTime,Vector2 pos)
        {
            Position = pos;
            armor.Position = pos;
            elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapse <= 10000)
            {
                armor.Update(gameTime);
            }
            else{
                Active = false;
                elapse = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            armor.Draw(spriteBatch);
        }
    }
}
