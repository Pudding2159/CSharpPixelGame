using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class LongDistanceAttack : AbstractCharacter
    {

        private Animation animation;
        private IActor actor;
        private string directions;
        private int speed;
        private int x = 0;
        private int y = 0;
        public LongDistanceAttack(int speed, IActor actor, Animation animation, int x, int y, string directions)
        {
            this.speed = speed; 
            this.animation = animation;
            this.actor = actor;
            this.SetPosition(x, y);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
            animation.SetDuration(8);
            this.directions = directions;
            //this.GetWorld().AddActor(this);
            this.x = x;
            this.y = y;
        }

        public override void Update()
        {
            if (this.directions == "Right")
            {
                this.SetPosition(this.x + this.speed, this.actor.GetY() + 25);
                this.x = this.x + this.speed;
            }
            else
            {
                this.SetPosition(this.x - this.speed, this.actor.GetY() + 25);
                this.x = this.x - this.speed;
                animation.FlipAnimation();
            }



            if (((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetX() < this.GetX() + 20 &&
                ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetX() > this.GetX() - 40)
            {
                if (((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetY() < this.GetY() + 40 &&
                ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetY() > this.GetY() - 40)
                {
                    ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).ChangeHealth(-20);
                    this.GetWorld().RemoveActor(this);
                }
            }

            //Console.WriteLine("Attack ----- > " + this.GetX());
            //if (((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetY() > this.GetY() + 20 ||
            //((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetY() < this.GetY() - 20)
           // ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).ChangeHealth(-20);
                

            if (this.GetX()<0)
                this.GetWorld().RemoveActor(this);

        }
    }
}