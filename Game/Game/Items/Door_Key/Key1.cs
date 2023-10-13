using Game.Actors;
using Game.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game.Item
{
    internal class KeyItem1: AbstractActor, IUsable, IItem
    {
        private Animation animation;
        private bool Tru = true;

        public KeyItem1()
        {
            animation = new Animation("resources/sprites/Door_Key/key_01.png", 16, 16);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
            this.Tru = true;
        }

        public override void Update()
        {
            GetWorld().ShowInventory((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()));
            if ((this.GetX() - this.GetWorld().GetActors()[0].GetX()) < 100)
            {
                if (Input.GetInstance().IsKeyDown(Input.Key.R))
                {
                    if (this.Tru)
                    {
                        (((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).AddItem(this);
                        Tru = false;
                        GetWorld().ShowInventory((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()));
                        this.GetWorld().RemoveActor(this);
                    }
                }
            }
        }

        public void Use(IActor user)
        {
        }

    }
}
