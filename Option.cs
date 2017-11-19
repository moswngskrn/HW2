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
    class Option
    {
        Texture2D Food;
        string[] name;
        public string nameOption;
        public Vector2 Position;
        public bool Active;

        public Option(Vector2 pos)
        {
            Position = pos;
            Active = true;
            name = new string[3];
            name[0] = "armor_food";
            name[1] = "health_food";
            name[2] = "powerUp_food";
            Random rnd = new Random();
            nameOption = name[rnd.Next(0,3)];
        }

        public void LoadContent(ContentManager Content)
        {
            
            Food = Content.Load<Texture2D>(nameOption);
        }

        public void Draw(SpriteBatch spriteBath)
        {
            spriteBath.Draw(Food,new Rectangle((int)Position.X,(int)Position.Y,30,30),Color.White);
        }

    }
}
