using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class Inter_Game : AbstractCharacter
    {
        private Player player;
        private Animation[] Health = new Animation[6];
        private int OldY;
        private int NewY;
        private int HealthPoint = 0;

        public Inter_Game(int x, int y)
        {
            for (int i = 0; i < 6; i++)
            {
                Health[i] = new Animation($"resources/sprites/Game_Interface/{i}.png", 148, 67);
            }
            this.SetPosition(x, y);
        }

        public override void Update()
        {
            if (player == null)
            {
                player = (Player)GetWorld().GetActors()[0];
                OldY = player.GetY();
                NewY = player.GetY();
            }
            NewY = player.GetY();

            //"Game window", 1920, 1080
            this.SetPosition(player.GetX() - 200, player.GetY() - 90);
            if (NewY != OldY)
            {
                this.SetPosition(player.GetX() - 200, player.GetY() - 86);
            }

            OldY = NewY;
            HealthPoint = ((AbstractCharacter)this.GetWorld().GetActors()[0]).GetHealth() / 20;
            this.SetAnimation(Health[HealthPoint]);
            this.GetAnimation().Start();
        }
    }
}