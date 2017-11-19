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
    class Animation
    {
        Texture2D Texture;
        //ขนาดframeจริง
        int Width;
        int Height;

        //ขนาดframeที่กำหนด
        int frameWidth;
        int frameHeight;

        int frameCountCol;
        int frameCountRow;
        int frameCol;
        int frameRow;
        public bool Looping;

        int delay;
        float elapse;
        Rectangle destinationRect;
        Rectangle sourceRect;

        bool Active;

        public Vector2 Position;

        Vector2 origin;
        public Animation(int frameWidth, int frameHeight, int frameCountCol, int frameCountRow, int delay, bool looping)
        {
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCountCol = frameCountCol;
            this.frameCountRow = frameCountRow;
            this.delay = delay;
            Looping = looping;
            frameCol = 0;
            frameRow = 0;

        }
        public void LoadContent(ContentManager Content, string name)
        {
            Texture = Content.Load<Texture2D>(name);
            Width = Texture.Width / frameCountCol;
            Height = Texture.Height / frameCountRow;
            Active = true;
            //origin = new Vector2(Texture.Width, Texture.Height);
            origin = new Vector2(Width, Height) / 2;
            Position = new Vector2(0, 0);
        }

        public void Update(GameTime gameTime)
        {
            if (!Active)
            {
                return;
            }
            elapse += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapse >= delay)
            {
                if (frameCol >= frameCountCol - 1)
                {
                    frameCol = 0;
                    if (frameRow >= frameCountRow - 1)
                    {
                        frameRow = 0;
                        if (!Looping)
                        {
                            Active = false;
                        }
                    }
                    else
                    {
                        frameRow++;
                    }

                }
                else
                {
                    frameCol++;
                }

                elapse = 0;

            }

            destinationRect = new Rectangle((int)Position.X, (int)Position.Y, frameWidth, frameHeight);
            sourceRect = new Rectangle(Width * frameCol, Height * frameRow, Width, Height);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, destinationRect, sourceRect, Color.White, 0.0f, origin, SpriteEffects.None, 0);
        }
    }
}
