using Game.Commands;
using Game.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Game.Actors
{
    public class ShortAttack
    {
        private IActor actor;
        private IActor attacer;
        public ShortAttack(IActor actor, IActor attacer)
        {
            this.actor = actor;
            this.attacer = attacer;
        }

        public bool GetAttack()
        {
            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if ((attacer.GetX() + i == actor.GetX() | attacer.GetX() - i == actor.GetX())
                      & (attacer.GetY() + j == actor.GetY() | attacer.GetY() - j == actor.GetY()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
