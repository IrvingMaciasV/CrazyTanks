using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POO1_y_Fisica_IrvingMacias;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameObj
{
    class GameObject
    {
        public Vector2 Position;
        public Texture2D Texture;
        public int PlayerT;

        public int Health;
        public bool Active;
        public bool Estado;
        public float Rotation;
        public Vector2 distance;

        virtual public void Initialize(Texture2D textureB, Vector2 posB, int PlayerType, bool estado)
        {
            PlayerT = PlayerType;

            Texture = textureB;

            Position = posB;

            Active = true;
            Health = 100;

            Estado = estado;
        }

        virtual public void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            var click = Mouse.GetState();

            if (Estado == true)
            {
                if (PlayerT == 1)
                {
                    distance.Y = (Position.X) - mouse.X;
                    distance.X = (Position.Y) - mouse.Y;
                }
                if (PlayerT == 2)
                {
                    distance.Y = -(Position.X) + mouse.X;
                    distance.X = -(Position.Y) + mouse.Y;
                }
                if (PlayerT != 3)
                {
                    Rotation = (float)Math.Atan2(distance.X, distance.Y);
                }
            }
            else
                Rotation = 0;

        }

        virtual public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, Rotation, new Vector2(Texture.Width / 2, Texture.Height / 2), .13f, SpriteEffects.None, 0f);
        }
    }
}
