using Merlin2d.Game;
using Merlin2d.Game.Actions;
using System;

namespace Game.Actors
{
    public abstract class AbstractCharacter : AbstractActor, ICharacter
    {
        private List<ICommand> activeEffects;
        private int health = 100;
        private float speed;
        private ISpeedStrategy speedStrategy;
        private bool AvailabilityTheInventory = false;
        private bool statusAttack = false;
        protected ActorOrientation orientation;

        // TODO: you can solve considering effects here in the Update method
        // you will further specify the Update method in subclasses

        public void AddEffect(ICommand effect)
        {
            // TODO: add effect to list of active effects
            throw new NotImplementedException();
        }

        public void ChangeHealth(int delta)
        {
            // TODO: update health based on delta change - keep in mind limits
        
            this.health += delta;

            if (this.health < 0)
                this.health = 0;
            ///throw new NotImplementedException();
        }


        // Animations
        protected Animation Animation_Run;
        protected Animation Animation_Jump;
        protected Animation Animation_Roll;
        protected Animation Animation_Fall;
        protected Animation Animation_Idle;
        protected Animation Animation_Attack;
        protected Animation Animation_Attack_2;

        public void Die()
        {
            if (this.GetHealth() == 0)
            {
                this.ChangeHealth(-1000);
                this.ChangeHealth(100);
                ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "PastDeath"))).SetPosition(this.GetX(), this.GetY());
                this.SetPosition(560, 200);
            }
        }

        public int GetHealth()
        {
            return health;
        }

        public int GetSpeed(int speed)
        {
            // TODO: get current speed based on the character's initial speed and current strategy
            return speedStrategy.GetSpeed(speed);
        }

   

        public void RemoveEffect(ICommand effect)
        {
            // TODO: remove effect from active effects
            // consider what happens if it is not among them
            throw new NotImplementedException();
        }

        public void SetSpeedStrategy(ISpeedStrategy strategy)
        {
            this.speedStrategy = strategy;
        }


        public void AddToInventory() 
        {
            this.AvailabilityTheInventory = true;      
        }


        public void StatusAttack(bool stat) 
        {
            this.statusAttack = stat;
        }

        public bool GetStatusAttack() 
        {
            return this.statusAttack;
        }

        public void EnemyDeath(Animation animation_death)
        {
            this.ChangeHealth(-1000);
            this.SetAnimation(animation_death);
        }

        public bool GetStatusInInventoryKey(string key) 
        {
            if (key == "KeyItem1")
            {
                if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem() != null)
                {
                    if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem().GetName() == "KeyItem1")
                    {
                        return true;
                    }
                }
            }
            else if (key == "KeyItem2")
            {
                if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem() != null)
                {
                    if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem().GetName() == "KeyItem2")
                        return true;
                }
            }
            else if (key == "KeyItem3")
            {
                if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem() != null)
                {
                    if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem().GetName() == "KeyItem3")
                        return true;
                }
            }
            else if (key == "KeyItem4")
            {
                if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem() != null)
                {
                    if ((((Player)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetBackpack()).GetItem().GetName() == "KeyItem4")
                        return true;
                }
            }
            return false;
        }


        double IMovable.GetSpeed(int speed)
        {
            throw new NotImplementedException();
        }
    }
}
