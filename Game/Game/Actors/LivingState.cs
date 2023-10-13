using Merlin2d.Game;
using Merlin2d.Game.Actors;

namespace Game.Actors
{
    public class LivingState : ICharacterState
    {
        // TODO: transfer here functionality from Player.Update

        private IActor actor;

        public LivingState(IActor actor)
        {
            this.actor = actor;
        }

        public void Update()
        {
            if (Input.GetInstance().IsKeyDown(Input.Key.UP))
            {
                // zavolat metodu pre posun hore
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.DOWN))
            {
                // zavolat metodu pre posun dole
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT))
            {
                // zavolat metodu pre posun doprava
                // vyriesit smerovanie animacie
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.LEFT))
            {
                // zavolat metodu pre posun dolava
                // vyriesit smerovanie animacie
            }
            else
            {
                this.actor.GetAnimation().Stop();
            }
        }
    }
}
