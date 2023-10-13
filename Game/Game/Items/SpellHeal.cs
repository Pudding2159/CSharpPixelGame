using Game.Actors;

using Merlin2d.Game;

namespace Game.Items
{
    public class SpellHeal : AbstractCharacter
    {
        private Player player;
        private Animation animation;


        public SpellHeal(int x, int y)
        {
           animation = new Animation("resources/sprites/gem.png", 16, 16);
           SetAnimation(animation);
           GetAnimation().Start();
        }

        private bool Check()
        {
            for (int i = -24; i < 24; i++)
            {
                for (int j = -24; j < 24; j++)
                {
                    if (GetX() + i == player.GetX() & GetY() + j == player.GetY())
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

            if (Input.GetInstance().IsKeyPressed(Input.Key.R) & Check())
            {
                player.ChangeHealth(20);
                this.GetWorld().RemoveActor(this);
            }
        }
    }
}
