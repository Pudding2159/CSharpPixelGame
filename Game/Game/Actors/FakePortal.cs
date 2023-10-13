using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class FakePortal : AbstractCharacter
    {
        private Animation animation;
        public FakePortal(int x, int y)
        {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/Portal.png", 58, 126);
            animation.FlipAnimation();
            SetAnimation(animation);
            animation.Start();

        }

        public override void Update()
        {

        }
    }
}