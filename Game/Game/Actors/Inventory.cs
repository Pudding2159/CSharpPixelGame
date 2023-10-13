using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class Inventory : AbstractCharacter
    {
        private Animation animation;
        private int X;
        private int Y;
        public Inventory(int x, int y)
        {
            this.SetPosition(x, y);

            this.X = x;
            this.Y = y;

            animation = new Animation("resources/sprites/Inventory.png", 203, 137);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
            animation.SetDuration(8);

        }

        public override void Update()
        {
            /*
            if (((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Key"))).GetStatusInInventory() == true)
            {
                this.animation.SetAnimationLayer(AnimationLayer.Background);
                ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Key"))).GetAnimation().SetAnimationLayer(AnimationLayer.Medium);
                ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Key"))).SetPosition(this.GetX(), this.GetY());
            }



            if (Input.GetInstance().IsKeyDown(Input.Key.TAB)) 
            {
                this.SetPosition(this.GetWorld().GetActors()[0].GetX()-50,this.GetWorld().GetActors()[0].GetY());
                if (((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Key"))).GetStatusInInventory() == true) 
                    ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Key"))).SetPosition(this.GetX(), this.GetY());
            }
            else  
                this.SetPosition(this.X, this.Y);
                

          


            //this.SetPosition(this.X, this.Y);
            */
        }
    }
}