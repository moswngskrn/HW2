using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System;

namespace GameHW2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background1;
        int CurentLevel;
        int H, W;

        Wall wall1;

        List<Player> players;


        List<Enemy> enemys;

        Boss boss;
        bool bossCome =false;
        Animation lightning;

        List<Bearing> bearing;
        TimeSpan fireTime;
        TimeSpan previousFireTime;
        List<Option> Options;
        List<Armor> Armors;

        int Score;
        SpriteFont TextScore;


        //Wait
        Texture2D TextureWait;
        SpriteFont TextWait;
        TimeSpan startTimeWait;
        bool showWait;
        bool through;


        Texture2D backgroundEndGame;

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
            H = GraphicsDevice.Viewport.Height;
            W = GraphicsDevice.Viewport.Width;
            previousFireTime = TimeSpan.Zero;
            fireTime = TimeSpan.FromSeconds(0.15f);

            CurentLevel = 1;

            players = new List<Player>();
            bearing = new List<Bearing>();
            enemys = new List<Enemy>();

            boss = new Boss(W, H);
            //lightning = new Animation(W,H,2,)
            


            Options = new List<Option>();
            Armors = new List<Armor>();
            Score = 0;

            //wait
            showWait = false;
            base.Initialize();
            through = false;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Level_1();
            TextScore = Content.Load<SpriteFont>("textScore");
            TextureWait = Content.Load<Texture2D>("bg_level");
            TextWait = Content.Load<SpriteFont>("textLevel");

            boss.LoadContent(Content);
            //test
            backgroundEndGame = Content.Load<Texture2D>("end_game");
        }
        void Level_1()
        {
            wall1 = new Wall(H, W, CurentLevel);
            background1 = Content.Load<Texture2D>("background1");
            wall1.LoadContent(Content, "a");

            //Add player
            Player player;
            player = new Player(50,60, 8, 1, 100, W, H, Keys.Left, Keys.Right, Keys.Down, Keys.Up, Keys.P, 1000, 10, "green");
            player.LoadContent(Content, "player1_left", "player1_right", wall1.Positions, wall1.Widths, new Vector2(W - 150, H - 50));
            players.Add(player);

            player = new Player(50, 60, 10, 1, 100, W, H, Keys.A, Keys.D, Keys.S, Keys.W, Keys.R, 1000, 30, "violate");
            player.LoadContent(Content, "player_left_1", "player_right_1", wall1.Positions, wall1.Widths, new Vector2(150, H - 50));
            players.Add(player);

            //Add enemy
            Enemy enemy;
            enemy = new Enemy(50, 50, 10, 1, 200, 100, 5, 1);
            enemy.LoadContent(Content, "enamy1_left", "enamy1_right", wall1.Positions[1], wall1.Widths[1]);
            enemys.Add(enemy);

            enemy = new Enemy(50, 50, 10, 1, 200, 50, 3, 2);
            enemy.LoadContent(Content, "enamy2_left", "enamy2_right", wall1.Positions[4], wall1.Widths[4]);
            enemys.Add(enemy);

            enemy = new Enemy(50, 50, 8, 1, 200, 20, 10, 5);
            enemy.LoadContent(Content, "anamy3_left", "anamy3_right", wall1.Positions[7], wall1.Widths[7]);
            enemys.Add(enemy);
        }
        void Level_2()
        {
            wall1.Clear();
            wall1 = new Wall(H, W, 2);
            background1 = Content.Load<Texture2D>("background2");
            wall1.LoadContent(Content, "wall2");
            players[0].PositionWalls = wall1.Positions;
            players[0].WidthWalls = wall1.Widths;
            if (players.Count == 2)
            {
                players[1].PositionWalls = wall1.Positions;
                players[1].WidthWalls = wall1.Widths;
            }
                
            //Add enemy
            Enemy enemy;
            enemy = new Enemy(50, 50, 10, 1, 200, 100, 5, 1);
            enemy.LoadContent(Content, "enamy1_left", "enamy1_right", wall1.Positions[0], wall1.Widths[0]);
            enemys.Add(enemy);

            enemy = new Enemy(50, 50, 10, 1, 200, 50,5, 2);
            enemy.LoadContent(Content, "enamy2_left", "enamy2_right", wall1.Positions[1], wall1.Widths[1]);
            enemys.Add(enemy);

            enemy = new Enemy(50, 50, 8, 1, 200, 20, 10, 5);
            enemy.LoadContent(Content, "anamy3_left", "anamy3_right", wall1.Positions[2], wall1.Widths[2]);
            enemys.Add(enemy);
        }
        void Level_3()
        {
            wall1.Clear();
            wall1 = new Wall(H, W, 3);
            background1 = Content.Load<Texture2D>("background3");
            wall1.LoadContent(Content, "wallL");
            players[0].PositionWalls = wall1.Positions;
            players[0].WidthWalls = wall1.Widths;
            if(players.Count == 2)
            {
                players[1].PositionWalls = wall1.Positions;
                players[1].WidthWalls = wall1.Widths;
            }
            
            //Add enemy
            Enemy enemy;
            enemy = new Enemy(50, 50, 10, 1, 200, 100, 3, 1);
            enemy.LoadContent(Content, "enamy1_left", "enamy1_right", wall1.Positions[0], wall1.Widths[0]);
            enemys.Add(enemy);

            enemy = new Enemy(50, 50, 10, 1, 200, 50,5, 2);
            enemy.LoadContent(Content, "enamy2_left", "enamy2_right", wall1.Positions[1], wall1.Widths[1]);
            enemys.Add(enemy);

            enemy = new Enemy(50, 50, 10, 1, 200, 20,5, 5);
            enemy.LoadContent(Content, "enamy2_left", "enamy2_right", wall1.Positions[2], wall1.Widths[2]);
            enemys.Add(enemy);

            enemy = new Enemy(50, 50, 8, 1, 200, 20,10, 1);
            enemy.LoadContent(Content, "anamy3_left", "anamy3_right", wall1.Positions[3], wall1.Widths[3]);
            enemys.Add(enemy);
        }
        void NextLevel(int Level)
        {
            CurentLevel = Level;
            if (Level == 1)
            {
                Level_1();
            }
            if (Level == 2)
            {
                Level_2();
            }
            if (Level == 3)
            {
                Level_3();
            }
            players[0].ResetPosition();
            if (players.Count == 2)
            {
                players[1].ResetPosition();
            }
                
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            UpdatePlayer(gameTime);

            UpdateEnemy(gameTime);
            UpdateBearing();
            UpdateArmor(gameTime);
            UpdateCollision(gameTime);

            if (CurentLevel == 4)
            {
                boss.Update(gameTime);
            }
            
            //test


            base.Update(gameTime);
        }

        void UpdateCollision(GameTime gameTime)
        {
            Rectangle ractangle1;
            Rectangle ractangle2;

            for(int i = 0; i < bearing.Count; i++)
            {
                for(int j = 0; j < enemys.Count; j++)
                {
                    ractangle1 = new Rectangle((int)bearing[i].Position.X,
                                           (int)bearing[i].Position.Y,
                                            bearing[i].frameWidth,
                                            bearing[i].frameHieght);
                    ractangle2 = new Rectangle((int)enemys[j].Position.X - enemys[j].frameWidth / 2,
                                           (int)enemys[j].Position.Y - enemys[j].frameHeight / 2,
                                           enemys[j].frameWidth,
                                           enemys[j].frameHeight);
                    if (ractangle1.Intersects(ractangle2))
                    {
                        for(int k = 0; k < players.Count; k++)
                        {
                            if ((Math.Abs(players[k].Position.X - enemys[j].Position.X) < 100) &&
                                players[k].Position.Y+players[k].Hieght/2==enemys[j].Position.Y+enemys[j].frameHeight/2)
                            {
                                enemys[j].currentHealth -= 5;
                                Score += 5000;
                            }
                            else
                            {
                                enemys[j].currentHealth -= 1;
                                Score += 200;
                            }
                        }
                        bearing[i].Active = false;
                    }
                    
                    if (Math.Abs(bearing[i].Position.X - bearing[i].PosStart.X)>=300)
                    {
                        bearing[i].Active = false;
                    }
                    if (enemys[j].currentHealth <= 0)
                    {
                        AddOption(enemys[j].Position);
                    }
                }  
            }

            for(int i = 0; i < players.Count; i++)
            {
                for(int j = 0; j < enemys.Count; j++)
                {
                    ractangle1 = new Rectangle((int)players[i].Position.X-players[i].Width/2,
                                               (int)players[i].Position.Y-players[i].Hieght/2,
                                               players[i].Hieght, players[i].Width);
                    ractangle2 = new Rectangle((int)enemys[j].Position.X - enemys[j].frameWidth / 2,
                                           (int)enemys[j].Position.Y - enemys[j].frameHeight / 2,
                                           enemys[j].frameWidth,
                                           enemys[j].frameHeight);
                    if (ractangle1.Intersects(ractangle2))
                    {
                        bool haveArmor = false;
                        for(int q = 0; q < Armors.Count; q++)
                        {
                            if(Armors[q].forPayer == i)
                            {
                                haveArmor = true;
                            }
                        }
                        if (!haveArmor)
                        {
                            players[i].CurrentHealth -= enemys[j].Damage;
                        }
                        
                    }
                }
            }

            for(int i = 0; i < players.Count; i++)
            {
                for (int j = Options.Count-1; j >=0 ; j--)
                {
                    ractangle1 = new Rectangle((int)players[i].Position.X - players[i].Width / 2,
                                               (int)players[i].Position.Y - players[i].Hieght / 2,
                                               players[i].Hieght, players[i].Width);
                    ractangle2 = new Rectangle((int)Options[j].Position.X, (int)Options[j].Position.Y, 30, 30);
                    if (ractangle1.Intersects(ractangle2))
                    {
                        Options[j].Active = false;
                        if(Options[j].nameOption == "armor_food")
                        {
                            AddArmor(players[i].Position, i);
                        }
                        if(Options[j].nameOption == "health_food")
                        {
                            players[i].CurrentHealth += 200;
                        }
                        if(Options[j].nameOption == "powerUp_food")
                        {
                            Score += 10000;
                        }
                        if(Options[j].nameOption == "key")
                        {
                            through = true;
                        }
                    }
                }
            }

            for(int i = 0; i < players.Count; i++)
            {
                ractangle1 = new Rectangle((int)players[i].Position.X - players[i].Width / 2,
                                               (int)players[i].Position.Y - players[i].Hieght / 2,
                                               players[i].Hieght, players[i].Width);
                ractangle2 = new Rectangle((int)boss.Position.X - boss.frameWidth / 2,
                                           (int)boss.Position.Y - boss.frameHieght / 2,
                                           boss.frameWidth, boss.frameHieght);
                if (ractangle1.Intersects(ractangle2) && bossCome)
                {
                    players[i].CurrentHealth -= boss.Damage;
                }
            }

            for(int i = 0; i < bearing.Count; i++)
            {
                ractangle1 = new Rectangle((int)bearing[i].Position.X,
                                           (int)bearing[i].Position.Y,
                                            bearing[i].frameWidth,
                                            bearing[i].frameHieght);
                ractangle2 = new Rectangle((int)boss.Position.X- boss.frameWidth/2, 
                                           (int)boss.Position.Y- boss.frameHieght/2, 
                                           boss.frameWidth, boss.frameHieght);
                if (ractangle1.Intersects(ractangle2) && bossCome)
                {
                    boss.currentHealth -= 1;
                    bearing[i].Active = false;
                }

            }

            if (enemys.Count == 0 && through)
            {
                
                if (CurentLevel+1 == 4)
                {
                    bossCome = true;
                }
                if (Wait(gameTime, TimeSpan.FromSeconds(3)))
                {
                    CurentLevel += 1;
                    through = false;
                    NextLevel(CurentLevel);
                    for (int i = Options.Count - 1; i >= 0; i--)
                    {
                        Options[i].Active = false;
                    }
                }
                
            }
        }

        void UpdateEnemy(GameTime gameTime)
        {
            for(int i = enemys.Count - 1; i >= 0; i--)
            {
                enemys[i].Update(gameTime);
            }
        }

        void UpdatePlayer(GameTime gameTime)
        {
            for(int i = 0; i < players.Count; i++)
            {
                players[i].Update(gameTime);
            }
            if (gameTime.TotalGameTime - previousFireTime > fireTime)
            {
                previousFireTime = gameTime.TotalGameTime;
                for(int i = 0; i < players.Count; i++)
                {
                    if (players[i].canShootBearing)
                    {
                        AddBearing(players[i].Position, players[i].Moving);
                        players[i].canShootBearing = false;
                    }
                }
                
                
            }
        }


        void AddBearing(Vector2 pos,string playerMoving)
        {
            Bearing b = new Bearing(50,50, 5, W, H);
            b.LoadContent(Content, pos);
            b.PlayerMoving = playerMoving;
            bearing.Add(b);
        }


        void UpdateBearing()
        {
            for (int i = 0; i < bearing.Count; i++)
            {
                bearing[i].Update();
            }
        }

        void AddOption(Vector2 pos)
        {
            Option o = new Option(pos);
            if (enemys.Count == 1)
            {
                o.nameOption = "key";
            }
            
            o.LoadContent(Content);
            
            Options.Add(o);
        }

        void UpdateArmor(GameTime gameTime)
        {
            for(int i = 0; i < Armors.Count; i++)
            {
                Armors[i].Update(gameTime, players[Armors[i].forPayer].Position);
            }
        }

        void AddArmor(Vector2 pos,int forPlayerNum)
        {
            Armor a = new Armor(100, 100, 2, 1);
            a.LoadContent(Content);
            a.forPayer = forPlayerNum;
            Armors.Add(a);
        }


        bool Wait(GameTime gameTime,TimeSpan ms)
        {
            if (!showWait)
            {
                startTimeWait = gameTime.TotalGameTime;
                showWait = true;
            }
            if (gameTime.TotalGameTime - startTimeWait >=ms)
            {
                showWait = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background1, new Rectangle(0, 0, W, H), Color.White);

            wall1.Draw(spriteBatch);

            

            for (int i = players.Count - 1; i >= 0; i--)
            {
                players[i].Draw(spriteBatch);
                if (players[i].Active == false)
                {
                    players.RemoveAt(i);
                }
            }

            for (int i = Armors.Count - 1; i >= 0; i--)
            {
                Armors[i].Draw(spriteBatch);
                if (Armors[i].Active == false)
                {
                    Armors.RemoveAt(i);
                }
            }

            for (int i = enemys.Count-1; i >=0; i--)
            {
                enemys[i].Draw(spriteBatch);
                if (enemys[i].Active == false)
                {
                    enemys.RemoveAt(i);
                }
            }

            for(int i = bearing.Count-1; i >= 0; i--)
            {
                bearing[i].Draw(spriteBatch);
                if (bearing[i].Active == false)
                {
                    bearing.RemoveAt(i);
                }
            }

            for(int i = Options.Count - 1; i >= 0; i--)
            {
                Options[i].Draw(spriteBatch);
                if (Options[i].Active == false)
                {
                    Options.RemoveAt(i);
                }
            }

            spriteBatch.DrawString(TextScore, "score: " + Score, new Vector2(W - 200, 10), Color.White);

            //wait
            if (showWait && !bossCome)
            {
                spriteBatch.Draw(TextureWait, new Rectangle(0,0,W,H), Color.White);
                spriteBatch.DrawString(TextWait, "Levels " + (CurentLevel+1), new Vector2(W/2-150,H/2 - 100), Color.White);
                
            }
            if(showWait && bossCome)
            {
                spriteBatch.DrawString(TextWait, "Boss coming!", new Vector2(W / 2 - 200, H / 2 - 50), Color.White);
            }

            boss.Draw(spriteBatch);

            if(boss.currentHealth <= 0)
            {
                bossCome = false;
                spriteBatch.Draw(backgroundEndGame, new Rectangle(0, 0, W, H), Color.White);
                spriteBatch.DrawString(TextWait, "You is Winer!", new Vector2(W / 2 - 200, H / 2 - 50), Color.White);
                spriteBatch.DrawString(TextWait, "score "+Score, new Vector2(W / 2 - 200, H / 2 - 50+50), Color.White);
            }
            if (players.Count == 0)
            {
                spriteBatch.Draw(backgroundEndGame, new Rectangle(0, 0, W, H), Color.White);
                spriteBatch.DrawString(TextWait, "You Lost!", new Vector2(W / 2 - 200, H / 2 - 50), Color.White);
                spriteBatch.DrawString(TextWait, "score " + Score, new Vector2(W / 2 - 200, H / 2 - 50 + 50), Color.White);
            }

            spriteBatch.End();
           

            base.Draw(gameTime);
        }
    }
}
