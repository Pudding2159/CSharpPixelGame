using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class Fire : AbstractCharacter
    {
        private Animation animation;
        public Fire(int x, int y)
        {
            this.SetPosition(x, y);
            //animation = new Animation("resources/sprites/player/run_nikita.png", 30, 39);
            animation = new Animation("resources/sprites/Fire.png", 64, 64);


            //animation.UnloadTexture();
            //animation.SetLooping(false);
            //animation.SetAnimationLayer(AnimationLayer.Medium);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
            //animation.SetRotation(90);
            animation.SetDuration(4);

        }

        public override void Update()
        {

        }
    }
}