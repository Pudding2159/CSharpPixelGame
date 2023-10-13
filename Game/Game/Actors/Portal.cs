using Game.Actors;
using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Game.Factories
{
    public class Portal : AbstractCharacter
    {
        private Player player;
        private Animation animation;

        private int X = 1500;
        private int Y = 160;

        public Portal(int x,int y)
        {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/Portal.png", 58, 126);
            SetAnimation(animation);
            animation.Start();
        }

        private bool CheckClosePlayer()
        {
            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 126; j++)
                {
                    if ((player.GetX() + i == this.GetX() | player.GetX() - i == this.GetX())
                      & (player.GetY() + j == this.GetY() | player.GetY() - j == this.GetY()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Merlin");
            }

            if (Input.GetInstance().IsKeyPressed(Input.Key.E) & CheckClosePlayer())
            {
                player.SetPosition(X, Y);
            }
        }
    }
}
