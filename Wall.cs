using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections;
using System.Collections.Generic;

namespace GameHW2
{
    class Wall
    {
        public int H, W;
        Texture2D Texture;
        public List<Texture2D> Textures;
        public List<Vector2> Positions;
        public List<int> Widths;
        int Level;
        public Wall(int H, int W,int Level)
        {
            this.H = H;
            this.W = W;
            this.Level = Level;
        }
        public void LoadContent(ContentManager Content,string name)
        {
            Textures = new List<Texture2D>();
            Positions = new List<Vector2>();
            Widths = new List<int>();
            Texture = Content.Load<Texture2D>(name);
            if (Level == 1)
            {
                Positions.Add(new Vector2(0, 100)); Positions.Add(new Vector2(200, 100)); Positions.Add(new Vector2(W - 100, 100));
                Positions.Add(new Vector2(0, 200)); Positions.Add(new Vector2(200, 200)); Positions.Add(new Vector2(W - 100, 200));
                Positions.Add(new Vector2(0, 300)); Positions.Add(new Vector2(200, 300)); Positions.Add(new Vector2(W - 100, 300));
                Positions.Add(new Vector2(0, 400)); Positions.Add(new Vector2(W - 100, 400));

                Widths.Add(100); Widths.Add(W - 400); Widths.Add(100);
                Widths.Add(100); Widths.Add(W - 400); Widths.Add(100);
                Widths.Add(100); Widths.Add(W - 400); Widths.Add(100);
                Widths.Add(100); Widths.Add(100);
            }
            if (Level == 2)
            {
                Positions.Add(new Vector2(0, 100));
                Positions.Add(new Vector2(300, 200));
                Positions.Add(new Vector2(200, 300));
                Positions.Add(new Vector2(0, 400)); Positions.Add(new Vector2(W - 100, 400));

                Widths.Add(400);
                Widths.Add(W - 300);
                Widths.Add(400);
                Widths.Add(100); Widths.Add(100);
            }
            if(Level == 3)
            {
                Positions.Add(new Vector2(0,100));
                Positions.Add(new Vector2(200, 200));
                Positions.Add(new Vector2(0, 300)); Positions.Add(new Vector2(W - 200, 300));
                Positions.Add(new Vector2(200, 400));

                Widths.Add(400);
                Widths.Add(W - 400);
                Widths.Add(200); Widths.Add(200);
                Widths.Add(400);

            }
        }
        public void Clear()
        {
            for(int i = Positions.Count - 1; i >= 0; i--)
            {
                Positions.RemoveAt(i);
            }
            for (int i = Widths.Count - 1; i >= 0; i--)
            {
                Widths.RemoveAt(i);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw()
            for(int i = 0; i <Positions.Count; i++)
            {
                spriteBatch.Draw(Texture, new Rectangle((int)Positions[i].X-10, (int)Positions[i].Y, Widths[i] + 20, 15), Color.White);
            }
        }
    }
}
