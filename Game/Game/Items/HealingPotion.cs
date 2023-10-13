using Game.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Items;

namespace Game.Items
{
    public class HealingPotion : AbstractActor, IItem, IUsable
    {
        private bool used;
        private int dose;
        private Animation fullAnimation;
        private Animation emptyAnimation;

        public HealingPotion(int x, int y, int dose) : base("healing potion")
        {
            this.dose = dose;
            used = false;

            fullAnimation = new Animation("resources/sprites/healingpotion.png", 16, 16);
            emptyAnimation = new Animation("resources/sprites/healingpotion_empty.png", 16, 16);
            SetPosition(x, y);
            SetAnimation(fullAnimation);
            GetAnimation().Start();
        }

        public override void Update()
        {
            
        }

        public void Use(IActor actor)
        {
            if (used)
                return;

            if (actor is ICharacter)
            {
                ICharacter character = (ICharacter)actor;
                character.ChangeHealth(dose);
                used = true;
                SetAnimation(emptyAnimation);
                GetAnimation().Start();
            }
        }
    }
}
