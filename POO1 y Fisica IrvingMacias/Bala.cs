using System;
using POO1_y_Fisica_IrvingMacias;
using GameObj;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace POO1_y_Fisica_IrvingMacias
{
    class Bala : GameObject
    {
        double div;
        float x1;
        float y1;
        Vector2 VF;
        Vector2 Posi;
        public float VeliX;
        public float VeliY;

        public override void Initialize(Texture2D textureB, Vector2 posB, int PlayerType, bool estado)
        {
            base.Initialize(textureB, posB, PlayerType, estado);
            if (PlayerT == 2)
            {
                Position.X += 10;
                Position.Y += 10;

            }
            else
            {
                Position.X -= 30;
                Position.Y += 10;
            }
            Posi = Position;

            //Distancia
            MouseState mouse = Mouse.GetState();
            var click = Mouse.GetState();
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
            

            //Velocidad
            x1 = distance.X * distance.X;
            y1 = distance.Y * distance.Y;
            div = Math.Sqrt(x1 + y1);
            float divf = (float)div;
            VF = new Vector2(distance.X / divf, distance.Y / divf);



            if (PlayerT == 1)
            {
                VeliX = -VF.Y * 15;
                VeliY = -VF.X * 15;
            }
            else
            {
                VeliX = VF.Y * 15;
                VeliY = VF.X * 15;
            }
        }
    }
}
