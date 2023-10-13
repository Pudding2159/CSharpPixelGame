using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class Door2 : AbstractCharacter
    {
        private Animation animation;
        private bool Tru = true;
        public Door2(int x, int y)
        {
            this.SetPosition(x, y);
            //animation = new Animation("resources/sprites/player/run_nikita.png", 30, 39);
            animation = new Animation("resources/sprites/Door_Key/door_key1.png", 41, 59);
            this.SetAnimation(animation);


        }

        public override void Update()
        {
            // if (((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "KeyItem"))).GetStatusInInventory() == true)
            if (Tru)
            {
                for (int i = 0; i < 60; i++)
                {
                    GetWorld().SetWall(this.GetX() / 16, ((this.GetY() - i)) / 16, true);
                    GetWorld().SetWall(this.GetX() / 16, ((this.GetY() + i)) / 16, true);

                }
                Tru = false;
            }

            if (this.GetStatusInInventoryKey("KeyItem1"))
            {
                for (int i = 0; i < 60; i++)
                {
                    GetWorld().SetWall(this.GetX() / 16, ((this.GetY() - i)) / 16, false);
                    GetWorld().SetWall(this.GetX() / 16, ((this.GetY() + i)) / 16, false);
                }
            }
        }
    }
}