using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class Cat : AbstractCharacter
    {
        private Animation animation;
        public Cat(int x, int y)
        {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/Cats.png", 32, 18);

            this.SetAnimation(animation);

            this.GetAnimation().Start();
            this.animation.FlipAnimation();
            animation.SetDuration(8);
            
        }

        public override void Update()
        {

        }
    }
}