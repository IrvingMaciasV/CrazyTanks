using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Shooter;
using Colision;


namespace POO1_y_Fisica_IrvingMacias
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Cannon PlayerA;
        Texture2D PlayAText;
        Vector2 PlayerAPos2;


        Cannon PlayerB;
        Texture2D PlayBText;
        Vector2 PlayerBPos2;

        Bala bala;
        Texture2D balaText;

        SpriteFont text;
        MouseState Click;
        MouseState Last;
        Physics fisicas;

        //Ambiente
        private Texture2D Fondo, Piso, Mountain;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferWidth = 1200;
            this.graphics.PreferredBackBufferHeight = 700;
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
            PlayerA = new Cannon();
            PlayerB = new Cannon();
            bala = new Bala();
            fisicas = new Physics();
            Physics.manager = Content;
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
            
            // TODO: use this.Content to load your game content here

            PlayAText = Content.Load<Texture2D>("Arte/Tank 1Irv");
            PlayerAPos2 = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 900, GraphicsDevice.Viewport.TitleSafeArea.Y + 455);
            Texture2D PlayAText2 = Content.Load<Texture2D>("Arte/Tank Irv1A");

            PlayerA.Initialize(PlayAText2, PlayerAPos2,1, false);
            PlayerA.Initialize2(PlayAText);

            
            PlayBText = Content.Load<Texture2D>("Arte/Tank2Irv");            
            PlayerBPos2 = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + 210, GraphicsDevice.Viewport.TitleSafeArea.Y + 449);
            Texture2D PlayBText2 = Content.Load<Texture2D>("Arte/Tank 2A");
            
            PlayerB.Initialize(PlayBText2, PlayerBPos2,2, true);
            PlayerB.Initialize2(PlayBText);


            balaText = Content.Load <Texture2D>("Arte/Bala Tank");

            fisicas.ISound();

            text = Content.Load<SpriteFont>("Fonts/Texto");
            Mountain = Content.Load<Texture2D>("Arte/Monte");
            Piso = Content.Load<Texture2D>("Arte/Texture");
            Fondo = Content.Load<Texture2D>("Arte/cielo Irv");

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
            IsMouseVisible = true;
            PlayerA.Update(gameTime);

            PlayerB.Update(gameTime);

            Last = Click;
            Click = Mouse.GetState();

            if (Click.LeftButton == ButtonState.Pressed && (Last.LeftButton == ButtonState.Released))
            {
                if (PlayerA.Estado == true)
                {
                    bala.Initialize(balaText, PlayerAPos2, 1, true);
                    PlayerA.Estado = false;
                    fisicas.Initialize(PlayerB, bala);
                }
                else if (PlayerB.Estado == true)
                {
                    bala.Initialize(balaText, PlayerBPos2, 2, true);
                    PlayerB.Estado = false;
                    fisicas.Initialize(PlayerA, bala);
                }
            }
               
            if(bala.Estado==true)
            fisicas.Collision(gameTime);         

                base.Update(gameTime);
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

            spriteBatch.Draw(Fondo, new Vector2(0, 0), null, Color.White, 0f, Vector2.Zero, .67f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Mountain, new Vector2(350, 300), null, Color.White, 0f, Vector2.Zero, .98f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Piso, new Vector2(0, 490), null, Color.White, 0f, Vector2.Zero, new Vector2(5,2) /*3f*/, SpriteEffects.None, 0f);

            PlayerA.Draw(spriteBatch);
            PlayerB.Draw(spriteBatch);

       
            if (bala.Estado == true)
            {
                bala.Draw(spriteBatch);
            }

            if (PlayerA.Estado == true)
            {
                spriteBatch.DrawString(text, "Angle: " + PlayerA.Rotation, new Vector2(5, 5), Color.White);
                spriteBatch.DrawString(text, "VelX: " + bala.VeliX + "   VelY: " + bala.VeliY, new Vector2(5, 35), Color.White);
                spriteBatch.DrawString(text, "VIDA Player 1: " + PlayerA.Health, new Vector2(5, 55), Color.White);
            }
            if (PlayerB.Estado == true)
            {
                spriteBatch.DrawString(text, "Angle: " + PlayerB.Rotation, new Vector2(5, 5), Color.White);
                spriteBatch.DrawString(text, "VelX: " + bala.VeliX + "   VelY: " + bala.VeliY, new Vector2(5, 35), Color.White);
                spriteBatch.DrawString(text, "VIDA Player 2: " + PlayerB.Health, new Vector2(5, 55), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
