using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;


namespace VietnamFrogger2._0
{
    enum GameStates { Welcome,Instructions1,Game1,WakeUp,Loose1,Game2,Winner}
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Rumba, Blooshot, HarrisPoints, heuy, hero, hUp, hDown, hLeft, hRight, lane, blank, Hind1, Hind2, Hind3, T341, T342, T343, L1, L2, L3, L4, L5, L6, L7, L8, L9, backgroundTexture, startButtonTexture, instructionsButtonTexture, BackTexture, instructionsTexture, RIP, Winner;
        GamePadState prevPad;
        GameStates curGameState = GameStates.Welcome; 

        Rectangle RumbaRec, BloodshotRec, HarrisPointsRec, heuyRec, heroRec, laneRec, laneRec2, StartRec, midRec, endRec, l1rect, Hind1Rec, Hind2Rec, Hind3Rec, T341Rec, T342Rec, T343Rec, L1Rec, L2Rec, L3Rec, L4Rec, L5Rec, L6Rec, L7Rec, L8Rec, L9Rec, backgroundRect, startButtonRect, instructionsButtonRect, BackRec, instructionsRec, RIPRec, WinnerRec;

        int LANE_SIZE;
        int HERO_SIZE;
        int Screen;
        int HP;

        int Lane1Speed, lane2Speed, lane3Speed, lane4Speed, lane5Speed, lane6Speed;
        bool Lane1Right, lane2Right, lane3Right, lane4Right, lane5Right, lane6Right;

        Color BackColor = Color.White;
        Color startColor = Color.White;
        Color instructionsColor = Color.White;
        MouseState mouseState;
        //rhett game 
        Texture2D huey, hueyLeft, hueyState, destroyedHuey, rocket1, rocket2, rocket3, rocket4, background, healthbar, m1, m2, m3, currentLives, currentBack, endZone, endScreen, deathScreen, titleScreen, startButton, howButton, instructScreen;
        Rectangle hueyRect, rocket1Rect, rocket2Rect, rocket3Rect, rocket4Rect, backRect, healthRect, livesRect, endRect, startRect, howRect;
        private static readonly TimeSpan Interval = TimeSpan.FromMilliseconds(3000);
        private TimeSpan time;
        int hueyX = 0;
        int hueyY = 500;
        int rocket1X = 400, rocket2X = 800, rocket3X = 1300, rocket4X = 1600;
        int rocket1Y, rocket2Y, rocket3Y, rocket4Y;
        int hp = 100;
        bool start = true;
        bool instruct = false;
        Color howColor = Color.White;
        byte lives = 3;
        Song heli;
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
            Random rand = new Random();
            // TODO: Add your initialization logic here

            IsMouseVisible = true;

            HP = 150;
            HarrisPointsRec = new Rectangle(30, 30, HP, 30);

            WinnerRec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            RIPRec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            instructionsRec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            backgroundRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            startButtonRect = new Rectangle(GraphicsDevice.Viewport.Width * 3 / 4 - 150, GraphicsDevice.Viewport.Height - 180, 300, 90);
            instructionsButtonRect = new Rectangle(GraphicsDevice.Viewport.Width / 4 - 150, GraphicsDevice.Viewport.Height - 200, 450, 100);
            BackRec = new Rectangle(GraphicsDevice.Viewport.Width / 4 - 250, GraphicsDevice.Viewport.Height - 180, 300, 100);

            Screen = 1;
            LANE_SIZE = GraphicsDevice.Viewport.Height / 9;
            HERO_SIZE = (int)(LANE_SIZE * .8);
            heroRec = new Rectangle(GraphicsDevice.Viewport.Width / 2 - HERO_SIZE / 2, GraphicsDevice.Viewport.Height - (int)(HERO_SIZE * 1.1), HERO_SIZE, HERO_SIZE);
            StartRec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 3, GraphicsDevice.Viewport.Width, LANE_SIZE * 3);
            midRec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 6, GraphicsDevice.Viewport.Width, LANE_SIZE * 3);
            L9Rec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, LANE_SIZE + 7);
            heuyRec = new Rectangle(GraphicsDevice.Viewport.Width / 2 - HERO_SIZE / 2, 0, HERO_SIZE * 3, HERO_SIZE);
            L1Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 1, GraphicsDevice.Viewport.Width, LANE_SIZE);
            L2Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 2, GraphicsDevice.Viewport.Width, LANE_SIZE);
            T341Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 2, HERO_SIZE * 2, HERO_SIZE);
            L3Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 3, GraphicsDevice.Viewport.Width, LANE_SIZE);
            Hind2Rec = new Rectangle(1000, GraphicsDevice.Viewport.Height - LANE_SIZE * 3, HERO_SIZE * 3, HERO_SIZE);
            L4Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 4, GraphicsDevice.Viewport.Width, LANE_SIZE);
            T342Rec = new Rectangle(2000, GraphicsDevice.Viewport.Height - LANE_SIZE * 4, HERO_SIZE * 2, HERO_SIZE);
            L5Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 5, GraphicsDevice.Viewport.Width, LANE_SIZE);
            RumbaRec = new Rectangle(1250, (GraphicsDevice.Viewport.Height - LANE_SIZE * 5) + 75, HERO_SIZE, HERO_SIZE / 2);
            L6Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 6, GraphicsDevice.Viewport.Width, LANE_SIZE);
            Hind3Rec = new Rectangle(1250, GraphicsDevice.Viewport.Height - LANE_SIZE * 6, HERO_SIZE * 3, HERO_SIZE);
            L7Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 7, GraphicsDevice.Viewport.Width, LANE_SIZE);
            T343Rec = new Rectangle(1000, GraphicsDevice.Viewport.Height - LANE_SIZE * 7, HERO_SIZE * 2, HERO_SIZE);
            L8Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 8, GraphicsDevice.Viewport.Width, LANE_SIZE);
            Hind1Rec = new Rectangle(0, GraphicsDevice.Viewport.Height - LANE_SIZE * 8, HERO_SIZE * 3, HERO_SIZE);
            //rhett
            Screen = 1;
            hueyRect = new Rectangle(hueyX, hueyY, 908 / 3, 262 / 3);
            endRect = new Rectangle(GraphicsDevice.Viewport.Width - 150, 0, 186, GraphicsDevice.Viewport.Height);
            livesRect = new Rectangle(GraphicsDevice.Viewport.Width - 400, 40, 836 / 5, 298 / 5);
            rocket1Rect = new Rectangle(rocket1X, rocket1Y, 178 / 8, 578 / 8);
            rocket2Rect = new Rectangle(rocket2X, rocket2Y, 178 / 8, 578 / 8);
            rocket3Rect = new Rectangle(rocket3X, rocket3Y, 178 / 8, 578 / 8);
            rocket4Rect = new Rectangle(rocket4X, rocket4Y, 178 / 8, 578 / 8);
            healthRect = new Rectangle(GraphicsDevice.Viewport.Width - 300, 40, hp, 20);
            backRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            startRect = new Rectangle(438, 700, 200, 76);
            howRect = new Rectangle(438 + 600, 700, 200, 76);

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

            Winner = Content.Load<Texture2D>("Images/SweetVictory");
            RIP = Content.Load<Texture2D>("Images/RIPHARRIS");
            backgroundTexture = Content.Load<Texture2D>("Images/titleScreen");
            BackTexture = Content.Load<Texture2D>("Images/Backbutton");
            instructionsTexture = Content.Load<Texture2D>("Images/Instructions");
            HarrisPoints = Content.Load<Texture2D>("Images/HARRIS");

            startButtonTexture = Content.Load<Texture2D>("Images/StartButton");
            instructionsButtonTexture = Content.Load<Texture2D>("Images/InstructionsButton");

            Rumba = Content.Load<Texture2D>("Images/Rumba");
            heuy = Content.Load<Texture2D>("Images/Huey");
            hero = Content.Load<Texture2D>("Images/HarrisUR");
            Blooshot = Content.Load<Texture2D>("Images/Bloodshot");
            hUp = Content.Load<Texture2D>("Images/HarrisUR");
            hDown = Content.Load<Texture2D>("Images/HarrisBack");
            hRight = Content.Load<Texture2D>("Images/HarrisUR");
            hLeft = Content.Load<Texture2D>("Images/HarrisUL");
            Hind1 = Content.Load<Texture2D>("Images/HindRight");
            Hind3 = Content.Load<Texture2D>("Images/HindRight");
            Hind2 = Content.Load<Texture2D>("Images/HindLeft");
            T341 = Content.Load<Texture2D>("Images/T34Right");
            T343 = Content.Load<Texture2D>("Images/T34Right");
            T342 = Content.Load<Texture2D>("Images/T34Left");

            L1 = Content.Load<Texture2D>("Images/REALNAMWATER");
            L2 = Content.Load<Texture2D>("Images/NamGrassss");
            L3 = Content.Load<Texture2D>("Images/REALNAMWATER");
            L4 = Content.Load<Texture2D>("Images/NAmGrasss");
            L5 = Content.Load<Texture2D>("Images/NamGrassss");
            L6 = Content.Load<Texture2D>("Images/REALNAMWATER");
            L7 = Content.Load<Texture2D>("Images/NamGrassss");
            L8 = Content.Load<Texture2D>("Images/REALNAMWATER");
            L9 = Content.Load<Texture2D>("Images/NAmGrasss");
            //rhett
            m1 = Content.Load<Texture2D>("1life");
            m2 = Content.Load<Texture2D>("2lives");
            m3 = Content.Load<Texture2D>("3lives");
            currentLives = m3;
            endZone = Content.Load<Texture2D>("safeZone");
            deathScreen = Content.Load<Texture2D>("Images/RIPHARRIS");
            huey = Content.Load<Texture2D>("huey");
            hueyLeft = Content.Load<Texture2D>("hueyLeft");
            destroyedHuey = Content.Load<Texture2D>("hueyFire");
            hueyState = huey;
            rocket1 = Content.Load<Texture2D>("rocket");
            rocket2 = Content.Load<Texture2D>("rocket");
            rocket3 = Content.Load<Texture2D>("rocket");
            rocket4 = Content.Load<Texture2D>("rocket");
            heli = Content.Load<Song>("helicopter");
            MediaPlayer.Play(heli);
            background = Content.Load<Texture2D>("vietnam");
            healthbar = Content.Load<Texture2D>("healthPoint");
            endScreen = Content.Load<Texture2D>("endScreen");
            titleScreen = Content.Load<Texture2D>("titleScreen");
            instructScreen = Content.Load<Texture2D>("howScreen");
            startButton = Content.Load<Texture2D>("start");
            howButton = Content.Load<Texture2D>("howTo");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            currentBack = background;
            // TODO: use this.Content to load your game content here
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
            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();
            mouseState = Mouse.GetState();

            Gamecode(gameTime, ref pad1, ref keyboard);

            if (BackRec.Contains(new Point(mouseState.X, mouseState.Y)) || pad1.ThumbSticks.Left.X > 0 || pad1.ThumbSticks.Right.X > 0 || keyboard.IsKeyDown(Keys.Right) || pad1.DPad.Right == ButtonState.Pressed)
            {
                BackColor = Color.Yellow;
                if (mouseState.LeftButton == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Enter) || pad1.Buttons.A == ButtonState.Pressed)
                {
                    BackColor = Color.Red;
                    curGameState = GameStates.Welcome;
                    IsMouseVisible = true;
                    HP = 150;
                    heroRec.X = GraphicsDevice.Viewport.Width / 2 - HERO_SIZE / 2;
                    heroRec.Y = GraphicsDevice.Viewport.Height - (int)(HERO_SIZE * 1.1);
                }
            }
            else
            {
                BackColor = Color.White;
            }


            base.Update(gameTime);
        }

        private void Gamecode(GameTime gameTime, ref GamePadState pad1, ref KeyboardState keyboard)
        {
            switch (curGameState)
            {
                case GameStates.Welcome:
                    if (instructionsButtonRect.Contains(new Point(mouseState.X, mouseState.Y)) || pad1.ThumbSticks.Left.X < 0 || pad1.ThumbSticks.Right.X < 0 || keyboard.IsKeyDown(Keys.Left) || pad1.DPad.Left == ButtonState.Pressed)
                    {
                        instructionsColor = Color.Yellow;
                        if (mouseState.LeftButton == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Enter) || pad1.Buttons.A == ButtonState.Pressed)
                        {
                            instructionsColor = Color.Red;
                            curGameState = GameStates.Instructions1;
                            IsMouseVisible = true;
                        }
                    }
                    else
                    {
                        instructionsColor = Color.White;
                    }

                    if (startButtonRect.Contains(new Point(mouseState.X, mouseState.Y)) || pad1.ThumbSticks.Left.X > 0 || pad1.ThumbSticks.Right.X > 0 || keyboard.IsKeyDown(Keys.Right) || pad1.DPad.Right == ButtonState.Pressed)
                    {
                        startColor = Color.Yellow;
                        if (mouseState.LeftButton == ButtonState.Pressed || keyboard.IsKeyDown(Keys.Enter) || pad1.Buttons.A == ButtonState.Pressed)
                        {
                            startColor = Color.Red;
                            curGameState = GameStates.Game1;
                            IsMouseVisible = false;
                            HP = 150;

                        }
                    }
                    else
                    {
                        startColor = Color.White;
                    }
                    break;
                case GameStates.Game1:
                    if (heroRec.Intersects(heuyRec))
                    {
                        curGameState = GameStates.Game2;
                        IsMouseVisible = true;

                    }
                    if (HP == 0)
                    {
                        curGameState = GameStates.Loose1;
                        IsMouseVisible = true;
                    }
                    if (pad1.Buttons.Y == ButtonState.Pressed && prevPad.Buttons.Y == ButtonState.Released)
                    {
                        heroRec.Y -= LANE_SIZE;
                        hero = hUp;
                    }
                    else if (pad1.Buttons.A == ButtonState.Pressed && prevPad.Buttons.A == ButtonState.Released)
                    {
                        heroRec.Y += LANE_SIZE;
                        hero = hDown;
                    }
                    else if (pad1.Buttons.X == ButtonState.Pressed && prevPad.Buttons.X == ButtonState.Released)
                    {
                        heroRec.X -= LANE_SIZE;
                        hero = hLeft;
                    }
                    else if (pad1.Buttons.B == ButtonState.Pressed && prevPad.Buttons.B == ButtonState.Released)
                    {
                        heroRec.X += LANE_SIZE;
                        hero = hRight;
                    }

                    moveAndWrapRect(ref RumbaRec, GraphicsDevice.Viewport.Width, false, 32);
                    moveAndWrapRect(ref T341Rec, GraphicsDevice.Viewport.Width, true, 10);
                    moveAndWrapRect(ref T343Rec, GraphicsDevice.Viewport.Width, true, 10);
                    moveAndWrapRect(ref T342Rec, GraphicsDevice.Viewport.Width, false, 13);
                    moveAndWrapRect(ref Hind1Rec, GraphicsDevice.Viewport.Width, true, 16);
                    moveAndWrapRect(ref Hind3Rec, GraphicsDevice.Viewport.Width, true, 14);
                    moveAndWrapRect(ref Hind2Rec, GraphicsDevice.Viewport.Width, false, 14);


                    if (HeroCollision())
                    {
                        hero = Blooshot;
                        HP -= 50;
                        HarrisPointsRec = new Rectangle(30, 30, HP, 30);
                        heroRec.X = GraphicsDevice.Viewport.Width / 2 - HERO_SIZE / 2;
                        heroRec.Y = GraphicsDevice.Viewport.Height - (int)(HERO_SIZE * 1.1);
                    }
                    prevPad = pad1;
                    break;
                case GameStates.Game2:

                    rocket1Y -= 6;
                    rocket2Y -= 5;
                    rocket3Y -= 6;
                    rocket4Y -= 7;
                    int helispeed = 1;
                    if (start)
                    {
                        if (hueyRect.Intersects(endRect))
                        {
                            hueyRect = new Rectangle(2, 2, 1, 1);
                            endRect = new Rectangle(2, 2, 1, 1);
                            rocket1Rect = new Rectangle(rocket1X, rocket1Y, 0, 0);
                            rocket2Rect = new Rectangle(rocket2X, rocket2Y, 0, 0);
                            rocket3Rect = new Rectangle(rocket3X, rocket3Y, 0, 0);
                            rocket4Rect = new Rectangle(rocket4X, rocket4Y, 0, 0);
                            livesRect = new Rectangle(0, 0, 0, 0);
                            healthRect = new Rectangle(GraphicsDevice.Viewport.Width - 100, 40, 0, 0);
                            currentBack = endScreen;
                            MediaPlayer.Stop();
                            Screen = 4;
                        }

                        else
                        {
                            if (lives == 3)
                            {
                                currentLives = m3;
                                livesRect = new Rectangle(GraphicsDevice.Viewport.Width - 400, 40, 836 / 5, 298 / 5);

                            }
                            endRect = new Rectangle(GraphicsDevice.Viewport.Width - 150, 0, 186, GraphicsDevice.Viewport.Height);

                            MediaPlayer.Play(heli);
                            currentBack = background;
                            backRect = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);


                            if (lives == 0)
                            {
                                hueyRect = new Rectangle(20, 2, 1, 1);
                                endRect = new Rectangle(2, 2, 1, 1);
                                rocket1Rect = new Rectangle(rocket1X, rocket1Y, 0, 0);
                                rocket2Rect = new Rectangle(rocket2X, rocket2Y, 0, 0);
                                rocket3Rect = new Rectangle(rocket3X, rocket3Y, 0, 0);
                                rocket4Rect = new Rectangle(rocket4X, rocket4Y, 0, 0);
                                livesRect = new Rectangle(0, 0, 0, 0);
                                healthRect = new Rectangle(GraphicsDevice.Viewport.Width - 100, 40, 0, 0);
                                currentBack = deathScreen;
                                MediaPlayer.Stop();
                            }
                            else
                            {
                                if (rocket1Y <= 0)
                                {
                                    rocket1Y = GraphicsDevice.Viewport.Height;
                                }
                                if (rocket2Y <= 0)
                                {
                                    rocket2Y = GraphicsDevice.Viewport.Height;
                                }
                                if (rocket3Y <= 0)
                                {
                                    rocket3Y = GraphicsDevice.Viewport.Height;
                                }
                                if (rocket4Y <= 0)
                                {
                                    rocket4Y = GraphicsDevice.Viewport.Height;
                                }
                                if (keyboard.IsKeyDown(Keys.Up))
                                {

                                    hueyY -= helispeed * 1;
                                }
                                if (keyboard.IsKeyDown(Keys.Down))
                                {

                                    hueyY += helispeed * 2;
                                }
                                if (keyboard.IsKeyDown(Keys.Right))
                                {
                                    hueyState = huey;
                                    hueyX += helispeed * 3;
                                }
                                if (keyboard.IsKeyDown(Keys.Left))
                                {

                                    hueyState = hueyLeft;
                                    hueyX -= helispeed * 3;
                                }
                                if (hueyRect.Intersects(rocket1Rect))
                                {
                                    hp -= 3;
                                }
                                if (hueyRect.Intersects(rocket2Rect))
                                {
                                    hp -= 3;
                                }
                                if (hueyRect.Intersects(rocket3Rect))
                                {
                                    hp -= 3;
                                }
                                if (hueyRect.Intersects(rocket4Rect))
                                {
                                    hp -= 3;
                                }

                                if (hp <= 0)
                                {
                                    hueyState = destroyedHuey;
                                    helispeed = 0;
                                    hueyY += 1;
                                    lives -= 1;
                                    if (time + Interval < gameTime.TotalGameTime)
                                    {
                                        hueyState = huey;
                                        hueyX = 0;
                                        hueyY = 500;
                                        time = gameTime.TotalGameTime;
                                        hp = 100;
                                    }

                                    if (lives == 2)
                                    {
                                        currentLives = m2;
                                        livesRect = new Rectangle(GraphicsDevice.Viewport.Width - 400, 40, 689 / 5, 362 / 5);

                                    }
                                    if (lives == 1)
                                    {
                                        currentLives = m1;
                                        livesRect = new Rectangle(GraphicsDevice.Viewport.Width - 400, 40, 500 / 8, 500 / 8);

                                    }
                                    if (lives == 0)
                                    {
                                        livesRect = new Rectangle(GraphicsDevice.Viewport.Width - 400, 40, 0, 0);

                                    }

                                }
                                hueyRect = new Rectangle(hueyX, hueyY, 908 / 3, 262 / 3);
                                rocket1Rect = new Rectangle(rocket1X, rocket1Y, 178 / 8, 578 / 8);
                                rocket2Rect = new Rectangle(rocket2X, rocket2Y, 178 / 8, 578 / 8);
                                rocket3Rect = new Rectangle(rocket3X, rocket3Y, 178 / 8, 578 / 8);
                                rocket4Rect = new Rectangle(rocket4X, rocket4Y, 178 / 8, 578 / 8);

                                healthRect = new Rectangle(GraphicsDevice.Viewport.Width - 100, 40, hp, 20);
                                base.Update(gameTime);
                            }
                        }
                    }
                    else
                    {
                        currentBack = titleScreen;
                        hueyRect = new Rectangle(20, 2, 1, 1);
                        endRect = new Rectangle(2, 2, 1, 1);
                        rocket1Rect = new Rectangle(rocket1X, rocket1Y, 0, 0);
                        rocket2Rect = new Rectangle(rocket2X, rocket2Y, 0, 0);
                        rocket3Rect = new Rectangle(rocket3X, rocket3Y, 0, 0);
                        rocket4Rect = new Rectangle(rocket4X, rocket4Y, 0, 0);
                        livesRect = new Rectangle(0, 0, 0, 0);
                        healthRect = new Rectangle(GraphicsDevice.Viewport.Width - 100, 40, 0, 0);
                        MediaPlayer.Stop();


                    }
                    break;
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            if (curGameState == GameStates.Welcome)
            {
                spriteBatch.Draw(backgroundTexture, backgroundRect, Color.White);
                spriteBatch.Draw(startButtonTexture, startButtonRect, startColor);
                spriteBatch.Draw(instructionsButtonTexture, instructionsButtonRect, instructionsColor);
            }
            else if(curGameState == GameStates.Instructions1)
            {
                spriteBatch.Draw(instructionsTexture, instructionsRec, Color.White);
                spriteBatch.Draw(BackTexture, BackRec, BackColor);
            }

            else if(curGameState == GameStates.Game1)
            {
                spriteBatch.Draw(L1, L1Rec, Color.White);
                spriteBatch.Draw(L2, L2Rec, Color.White);
                spriteBatch.Draw(L3, L3Rec, Color.White);
                spriteBatch.Draw(L4, L4Rec, Color.White);
                spriteBatch.Draw(L5, L5Rec, Color.White);
                spriteBatch.Draw(L6, L6Rec, Color.White);
                spriteBatch.Draw(L7, L7Rec, Color.White);
                spriteBatch.Draw(L8, L8Rec, Color.White);
                spriteBatch.Draw(L9, L9Rec, Color.White);
                spriteBatch.Draw(T341, T341Rec, Color.White);
                spriteBatch.Draw(T342, T342Rec, Color.White);
                spriteBatch.Draw(T343, T343Rec, Color.White);
                spriteBatch.Draw(Hind1, Hind1Rec, Color.White);
                spriteBatch.Draw(Hind2, Hind2Rec, Color.White);
                spriteBatch.Draw(Hind3, Hind3Rec, Color.White);
                spriteBatch.Draw(heuy, heuyRec, Color.White);
                spriteBatch.Draw(Rumba, RumbaRec, Color.White);
                spriteBatch.Draw(hero, heroRec, Color.White);
                spriteBatch.Draw(HarrisPoints, HarrisPointsRec, Color.Red);
            }
            else if (curGameState == GameStates.Winner)
            {
                spriteBatch.Draw(Winner, WinnerRec, Color.White);
                spriteBatch.Draw(BackTexture, BackRec, BackColor);
            }
            else if(curGameState == GameStates.Game2)
            {
                MediaPlayer.Play(heli);
                spriteBatch.Draw(currentBack, backRect, Color.White);
                spriteBatch.Draw(endZone, endRect, Color.White);
                spriteBatch.Draw(hueyState, hueyRect, Color.White);
                spriteBatch.Draw(rocket1, rocket1Rect, Color.White);
                spriteBatch.Draw(rocket2, rocket2Rect, Color.White);
                spriteBatch.Draw(rocket3, rocket3Rect, Color.White);
                spriteBatch.Draw(rocket4, rocket4Rect, Color.White);
                spriteBatch.Draw(healthbar, healthRect, Color.White);
                spriteBatch.Draw(currentLives, livesRect, Color.White);
            }
            else if(curGameState == GameStates.Loose1)
            {
                spriteBatch.Draw(RIP, RIPRec, Color.White);
                spriteBatch.Draw(BackTexture, BackRec, BackColor);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private bool HeroCollision()
        {
            return (heroRec.Intersects(RumbaRec) ||
                heroRec.Intersects(Hind1Rec) ||
                heroRec.Intersects(Hind2Rec) ||
                heroRec.Intersects(Hind3Rec) ||
                heroRec.Intersects(T341Rec) ||
                heroRec.Intersects(T342Rec) ||
                heroRec.Intersects(T343Rec));

        }
        private void moveAndWrapRect(ref Rectangle rect, int width, bool right, int speed)
        {
            //traveling right
            if (right)
            {
                rect.X += speed;

                // and the sprite is completely off the screen to the right
                if (rect.X > width)
                    //set sprite completely off screen to left 
                    rect.X = 0 - rect.Width;
            }
            else
            {

                rect.X -= speed;

                //and the sprite is completely off the screen to the right
                if (rect.X < -1 * HERO_SIZE * 3)
                    //set the sprite to be completely off screen to the left
                    rect.X = width + rect.Width;

            }
        }
        // TODO: Add your drawing code here




    }
}
