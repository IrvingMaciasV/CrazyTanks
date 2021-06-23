using POO1_y_Fisica_IrvingMacias;
using Shooter;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Colision
{
    class Physics
    {
        Cannon cannon;
        Bala bala;
        SoundEffect Critic, Normal, Shoot;
        public static ContentManager manager;

        public void ISound()
        {
            Critic = manager.Load<SoundEffect>("Arte/ImpactCannon");
            Normal = manager.Load<SoundEffect>("Arte/ImpactBase");
            Shoot = manager.Load<SoundEffect>("Arte/ShootCannon");
        }

        public void Initialize(Cannon can, Bala bal)
        {
            bala = new Bala();
            cannon = new Cannon();
            cannon = can;
            bala = bal;
            Shoot.Play();
        }

        public void Collision(GameTime gameTime)
        {
            //NULO
            if ((bala.Position.X > 1220 || bala.Position.X < -10) ||
                (bala.Position.Y > cannon.MaxB.Y+20))
            {
                bala.Estado = false;
                cannon.Estado = true;
                
            }

            //Daño a cañon (CRITICO)
            if (bala.Position.X >= cannon.MinA.X && bala.Position.Y >= cannon.MinA.Y &&
                bala.Position.X <= cannon.MaxA.X && bala.Position.Y <= cannon.MaxA.Y)
            {
                cannon.Health -= 25;
                bala.Estado = false;
                cannon.Estado = true;
                Critic.Play();
            }

            //Daño a Base (Normal)
            if (bala.Position.X >= cannon.MinB.X && bala.Position.Y >= cannon.MinB.Y &&
                bala.Position.X <= cannon.MaxB.X && bala.Position.Y <= cannon.MaxB.Y)
            {
                cannon.Health -= 10;
                bala.Estado = false;
                cannon.Estado = true;
                Normal.Play();
            }


            //Movimiento

            bala.Rotation = 0;


            if (bala.Estado == true)
            {
                var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
                delta = delta / 1000;

                bala.Position.X += bala.VeliX;
                bala.Position.Y += bala.VeliY;
                bala.VeliY += .25f;
            }
        }
    }
}
