using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;

namespace Game.Actors
{
    public class Demon : AbstractCharacter
    {
        private Animation animation;
        private int speed;
        private int x;
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand moveLeft;
        private ICommand moveRight;
        private int Old_iter = 0;
        private ICommand Player_;
        private ICommand Sketetin_X;
        private int Iter = 0;
        public int temp = 0;
        private ICommand lastMove;
        private Player position;
        private int time = 0;
        private List<IActor> List_Game = new List<IActor>();
        Random random = new Random();

     

        public Demon(int x, int y, int speed)
        {
            this.SetPosition(x, y);
            this.animation = new Animation("resources/sprites/demon.png", 220, 175);
            animation.FlipAnimation();
            this.SetAnimation(this.animation);

            this.speed = speed;
            this.x = x;
            this.moveUp = new Move(this, speed, 0, -1);
            this.moveDown = new Move(this, speed, 0, 1);
            this.moveLeft = new Move(this, speed, -1, 0);
            this.moveRight = new Move(this, speed, 1, 0);
            this.SetPhysics(true);
            this.lastMove = moveRight;
        }
        private void MoveRight()
        {
            //moveRight.Execute();
            this.SetPosition(GetX() + 4, GetY());
            if(this.GetX() > 380)
                this.SetPosition(GetX()-4, GetY());
   
            if (this.lastMove == moveLeft)
                animation.FlipAnimation();
            this.lastMove = moveRight;
            Iter++;
            if (Iter == 300)
                Iter = 0;
        }



        private void MoveLeft()
        {
            //moveLeft.Execute();
            this.SetPosition(GetX() - 4, GetY());

            if (this.GetX() < 16)
                this.SetPosition(GetX() + 4, GetY());

            if (this.lastMove == moveRight)
                animation.FlipAnimation();
            this.lastMove = moveLeft;
            Iter++;
            if (Iter == 300)
                Iter = 0;

        }

        private void Angry()
        {
            this.animation = new Animation("resources/sprites/demon-attack.png", 220, 175);

            if (this.lastMove != moveLeft)
                animation.FlipAnimation();
            
            if ((this.GetX() < this.GetWorld().GetActors()[0].GetX()))
                if(lastMove != this.moveRight)
                    MoveRight();


            animation.SetDuration(11);
            this.SetAnimation(this.animation);
            time = 111;
            ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).ChangeHealth(-20);

        }

        public override void Update()
        {
            if (time != 0)
                time--;
            

            if (time == 0)
            {
                if (animation.GetResource() != "resources/sprites/demon.png")
                {
                    this.animation = new Animation("resources/sprites/demon.png", 220, 175);
                    animation.FlipAnimation();
                    if (this.lastMove == moveLeft)
                        animation.FlipAnimation();

                    this.SetAnimation(this.animation);
                    animation.SetDuration(8);
                    //if (this.lastMove == moveLeft)
                    //    animation.FlipAnimation();
                }

                if (this.GetX()> (this.GetWorld().GetActors()[0].GetX() ))
                    if (this.GetX() - (this.GetWorld().GetActors()[0].GetX()) < 60)
                        if ((this.GetY() - 40) < this.GetWorld().GetActors()[0].GetY() || this.GetWorld().GetActors()[0].GetY() < (this.GetY() + 40))
                            Angry();

                if ((this.GetX() < this.GetWorld().GetActors()[0].GetX() ))
                    if ((this.GetWorld().GetActors()[0].GetX() ) - this.GetX() < 150)
                        if ((this.GetY() - 40) < this.GetWorld().GetActors()[0].GetY() || this.GetWorld().GetActors()[0].GetY() < (this.GetY() + 40))
                            Angry();


              

                //this.GetWorld().GetActors()[0];

                


                animation.Start();
                if (Iter == 0)
                    this.x = random.Next(0, 2);

                if (Old_iter == this.GetX())
                {
                    this.x = random.Next(0, 2);
                    Iter = 0;
                }
                Old_iter = this.GetX();



                if (this.x == 0)
                {
                    MoveRight();
                }
                else
                {
                    MoveLeft();

                }


              
            }


            //Console.WriteLine("Player-->" + this.GetWorld().GetActors()[0].GetX());
            //Console.WriteLine("Demon-->" + this.GetX());

        }
    }
 }
