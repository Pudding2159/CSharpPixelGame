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
    internal class Book : AbstractActor, IUsable, IItem
    {
        //private IItem Key_item;
        private Animation animation;
        private bool Tru = true;

        public Book()
        {
            animation = new Animation("resources/sprites/book.png", 32, 32);
            //animation = new Animation("resources/sprites/Skull.png", 27, 30);
            this.SetAnimation(animation);
            this.GetAnimation().Start();
            this.Tru = true;
        }

        public override void Update()
        {
            GetWorld().ShowInventory((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()));
            if ((this.GetWorld().GetActors()[0].GetX() - this.GetX()) < 100)
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
            //throw new NotImplementedException();
        }


    }
}
