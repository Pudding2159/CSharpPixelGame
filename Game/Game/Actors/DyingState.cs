using Merlin2d.Game.Actors;

namespace Game.Actors
{
    public class DyingState : ICharacterState
    {
        private IActor actor;
        private int timer = 0;

        public DyingState(IActor actor)
        {
            this.actor = actor;
        }

        public void Update()
        {
            timer++;
            if (timer == 300)
            {
                this.actor.RemoveFromWorld();
            }
        }
    }
}
