using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class Seller : AbstractCharacter
    {
        private Animation animation;
        private IActor actor = null;
        private string dutation = "Left";
        public Seller(int x, int y)
        {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/Seller.png", 64, 43);
            //animation = new Animation("resources/sprites/FX01.png", 64, 49);
            this.actor = actor;
            this.SetAnimation(animation);
            animation.FlipAnimation();
            this.GetAnimation().Start();
            animation.SetDuration(9);

        }

        public override void Update()
        {
            if (this.GetX() < this.GetWorld().GetActors()[0].GetX()) 
            {
                if (dutation == "Left")
                {
                    animation.FlipAnimation();
                    dutation = "Right";
                }
            }
            if (this.GetX() > this.GetWorld().GetActors()[0].GetX())
            {
                if (dutation == "Right")
                {
                    animation.FlipAnimation();
                    dutation = "Left";
                }
            }


        }
    }
}