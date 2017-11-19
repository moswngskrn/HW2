using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;


namespace GameHW2
{
    class Bearing
    {
        Texture2D Texture;
        public Vector2 Position;
        public Vector2 PosStart;
        public bool Active;
        public string PlayerMoving;
        float Vx;
        public int frameWidth;
        public int frameHieght;
        int W, H;

        public Bearing(float Vx,int frameWidth,int frameHieght,int W,int H)
        {
            this.Vx = Vx;
            this.frameWidth = frameWidth;
            this.frameHieght = frameHieght;
            this.W = W;
            this.H = H;
        }
        public void LoadContent(ContentManager Content,Vector2 Pos)
        {
            Texture = Content.Load<Texture2D>("bearing");
            Position = Pos;
            PosStart = Pos;
            Active = true;
        }

        public void Update()
        {
            if(PlayerMoving == "left")
            {
                Position.X -= Vx;
            }
            if(PlayerMoving == "right")
            {
                Position.X += Vx;
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, frameWidth, frameHieght), Color.White);
        }
    }
}
