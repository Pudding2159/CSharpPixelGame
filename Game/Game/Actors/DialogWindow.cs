using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System.Reflection.Metadata.Ecma335;

namespace Game.Actors
{
    public class DialogWindow : AbstractCharacter
    {
        private int PressNum = 0;
        private Animation animation;
        public DialogWindow(int x, int y)
        {
            this.SetPosition(x, y);
            animation = new Animation("resources/sprites/990.png", 30, 20);
            this.SetAnimation(animation);

        }

        public override void Update()
        {

            if (((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).GetX()
                < ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Seller"))).GetX() + 10)
            {
                if (Input.GetInstance().IsKeyDown(Input.Key.R))
                {

                    if (Input.GetInstance().IsKeyPressed(Input.Key.R))
                        PressNum += 1;
                    


                    if (PressNum == 1)
                    {
                        animation = new Animation("resources/sprites/UI.png", 64, 17);
                        this.SetAnimation(animation);
                    }

                    if (PressNum == 2)
                    {
                        animation = new Animation("resources/sprites/Key_11.png", 16, 11);
                        this.SetAnimation(animation);
                        this.GetAnimation().Start();
                    }

                    if (PressNum == 3)
                    {
                        animation = new Animation("resources/sprites/990.png", 30, 20);
                        this.SetAnimation(animation);
                    }
                }
                
            }
        }
    }
}