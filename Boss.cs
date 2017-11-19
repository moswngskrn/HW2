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
    class Boss
    {
        Animation boss;
        bool Active;
        public int frameWidth;
        public int frameHieght;
        public Vector2 Position;
        int W, H;
        float Vx;
        float Vy;
        int Health;
        public int Damage;
        public int currentHealth;

        //พลังชีวิต
        Texture2D tapPower;
        Rectangle destinationRect;
        Rectangle sourceRect;


        public Boss(int W,int H)
        {
            Damage = 5;
            Health = 100;
            currentHealth = Health;
            Active = true;
            this.W = W;
            this.H = H;
            Vx = 1f;
            Vy = 2f;
            boss = new Animation(W / 3, W / 3, 4, 4, 100, true);
            frameWidth = W / 3;
            frameHieght = W / 3;
            Position = new Vector2(W-frameWidth/2,H-frameHieght/2);
        }

        public void LoadContent(ContentManager Content)
        {
            boss.LoadContent(Content, "boss");

            //พลังชีวิต
            tapPower = Content.Load<Texture2D>("red");
        }

        public void Update(GameTime gameTime)
        {
            if (Position.X <= frameWidth/2)
            {
                Vx *= (-1);
            }
            if (Position.X >= W-frameWidth/2)
            {
                Vx *= (-1);
            }

            if (Position.Y <= 240)
            {
                Vy *= (-1);
            }
            if (Position.Y >= H - frameHieght / 2)
            {
                Vy *= (-1);
            }
            Position.X += Vx;
            Position.Y += Vy;
            boss.Position = Position;
            boss.Update(gameTime);

            //พลังชีวิต
            int x = (tapPower.Width / 2) - ((tapPower.Width / 2) * currentHealth / Health);
            destinationRect = new Rectangle((int)Position.X - frameWidth / 2, (int)Position.Y - 15 - frameHieght / 2, frameWidth, 5);
            sourceRect = new Rectangle(x, 0, tapPower.Width / 2, 5);
            if (currentHealth <= 0)
            {
                Active = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tapPower, destinationRect, sourceRect, Color.White);
            boss.Draw(spriteBatch);
        }
    }
}
