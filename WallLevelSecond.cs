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
    class WallLevelSecond
    {
        public int H, W;
        Texture2D Texture;
        public List<Texture2D> Textures;
        public List<Vector2> Positions;
        public List<int> Widths;
        public WallLevelSecond(int H, int W)
        {
            this.H = H;
            this.W = W;
        }
        public void LoadContent(ContentManager Content, string name)
        {
            Textures = new List<Texture2D>();
            Positions = new List<Vector2>();
            Widths = new List<int>();
            Texture = Content.Load<Texture2D>("wallL");
            Positions.Add(new Vector2(0, 100));
            Positions.Add(new Vector2(300, 200));
            Positions.Add(new Vector2(200, 300));
            Positions.Add(new Vector2(0, 400)); Positions.Add(new Vector2(W - 100, 400));

            Widths.Add(400);
            Widths.Add(W-200);
            Widths.Add(400);
            Widths.Add(100); Widths.Add(100);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw()
            for (int i = 0; i < 11; i++)
            {
                spriteBatch.Draw(Texture, new Rectangle((int)Positions[i].X, (int)Positions[i].Y, Widths[i], 15), Color.White);
            }
        }
    }
}
