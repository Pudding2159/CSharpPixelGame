using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class PastDeath : AbstractCharacter
    {
        private Animation animation;
        public PastDeath(int x, int y)
        {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/Skull.png", 27, 30);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
            //animation.SetRotation(90);
            animation.SetDuration(8);

        }

        public override void Update()
        {

        }
    }
}