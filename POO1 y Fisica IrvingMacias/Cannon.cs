using POO1_y_Fisica_IrvingMacias;
using GameObj;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Shooter
{
    class Cannon: GameObject
    {
        public Animation PlayerB;
        public Texture2D textureB;
        public Vector2 PositionB;


        public Vector2 MinA, MaxA;
        public Vector2 MinB, MaxB;


        public void Initialize2(Texture2D text)
        {
            PlayerB = new Animation();
            textureB = text;
            if (PlayerT == 1)
            {
                PositionB.X = Position.X + 15;

                //Caja Cañon
                MinA.X = Position.X - 30;
                MinA.Y = Position.Y -19;
                MaxA.X = Position.X + 40;
                MaxA.Y = Position.Y + 20;

                //Caja Base
                MinB.X = Position.X - 50;
                MinB.Y = Position.Y + 7;
                MaxB.X = Position.X + 65;
                MaxB.Y = Position.Y + 35;
            }
            else
            {
                PositionB.X = Position.X + 5;

                //CAJA Cañon
                MinA.X = Position.X - 36;
                MinA.Y = Position.Y - 43;
                MaxA.X = Position.X + 20;
                MaxA.Y = Position.Y + 8;

                //Caja Base
                MinB.X = Position.X - 60;
                MinB.Y = Position.Y + 5;
                MaxB.X = Position.X + 57;
                MaxB.Y = Position.Y + 52;
            }

            PositionB.Y = Position.Y + 37;

            PlayerB.Initialize(textureB, PositionB, 250, 140, 4, 80, Color.White, .25f, true);
        }


        public override void Update(GameTime gameTime)
        {
            PlayerB.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            PlayerB.Draw(spriteBatch);
        }

    }
}
