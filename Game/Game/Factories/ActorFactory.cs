using Game.Actors;
using Game.Item;
using Game.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;

namespace Game.Factories
{
    public class ActorFactory : IFactory
    {

       
        public IActor Create(string actorType, string actorName, int x, int y)
        {
            IActor actor = null;


            if (actorType == "Player")
            {
                actor = Player.Instance(x, y, 4);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Demon")
            {
                actor = new Demon(x, y, 3);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Light")
            {
                actor = new Light(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);

            }
            else if (actorType == "Cat")
            {
                actor = new Cat(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Inter_Game")
            {
                actor = new Inter_Game(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Door")
            {
                actor = new Door(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Door2")
            {
                actor = new Door2(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Door3")
            {
                actor = new Door3(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Door4")
            {
                actor = new Door4(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Seller")
            {
                actor = new Seller(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "DialogWindow")
            {
                actor = new DialogWindow(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Inventory")
            {
                actor = new Inventory(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "KeyItem1")
            {
                actor = (IItem)new KeyItem1();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "KeyItem2")
            {
                actor = (IItem)new KeyItem2();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "KeyItem3")
            {
                actor = (IItem)new KeyItem3();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "KeyItem4")
            {
                actor = (IItem)new KeyItem4();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Book")
            {
                actor = (IItem)new Book();
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "PastDeath")
            {
                actor = new PastDeath(x,y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Fire")
            {
                actor = new Fire(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Skeleton")
            {
                actor = new Skeleton(x, y, 3);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Sniper")
            {
                actor = new Sniper(x, y, 3);
                actor.SetName(actorName);
                actor.SetPhysics(true);
                actor.SetPosition(x, y);
            }
            else if (actorType == "Portal")
            {
                actor = new Portal(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "FakePortal")
            {
                actor = new FakePortal(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else if (actorType == "SpellHeal")
            {
                actor = new SpellHeal(x, y);
                actor.SetName(actorName);
                actor.SetPhysics(false);
                actor.SetPosition(x, y);
            }
            else
            {
                Console.WriteLine(actorType);
                throw new ArgumentException("Unknown type");
            }

            return actor;
        }
    }
}
