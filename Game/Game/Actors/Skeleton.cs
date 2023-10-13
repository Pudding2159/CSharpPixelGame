using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Game.Actors
{
    public class Skeleton : AbstractCharacter
    {
        private Animation animation;

        private ICommand moveLeft;
        private ICommand moveRight;
        private ICommand lastMove;

        private int speed;
        private int x;
        private int Old_iter = 0;
        private int Iter = 0;
        public int temp = 0;
        private int time = 0;
        private bool AttackPermissions = false;
        private Player player;


        private bool Live = true;



        private List<IActor> List_Game = new List<IActor>();
        private Random random = new Random();
        private ShortAttack attack = null;


        public Skeleton(int x, int y, int speed)
        {
            this.SetPosition(x, y);
            this.animation = new Animation("resources/sprites/Bandit.png", 48, 40);
            this.SetAnimation(this.animation);
            animation.FlipAnimation();

            this.speed = speed;
            this.x = x;
            this.moveLeft = new Move(this, speed, -1, 0);
            this.moveRight = new Move(this, speed, 1, 0);
            this.SetPhysics(true);
            this.lastMove = moveRight;
        }



        private void MoveRight()
        {
            moveRight.Execute();
            if (this.lastMove == moveLeft)
                animation.FlipAnimation();
            this.lastMove = moveRight;
            Iter++;
            if (Iter == 300)
                Iter = 0;
        }



        private void MoveLeft()
        {
            moveLeft.Execute();
            if (this.lastMove == moveRight)
                animation.FlipAnimation();
            this.lastMove = moveLeft;
            Iter++;
            if (Iter == 300)
                Iter = 0;

        }


        private void MerlinAttack()
        {
            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 100; j++)
                {

                    if ((player.GetX() + i == this.GetX() | player.GetX() - i == this.GetX())
                      & (player.GetY() + j == this.GetY() | player.GetY() - j == this.GetY()))
                    {
                        if (player.GetStatusAttack() == true)
                            this.ChangeHealth(-1);
                    }

                }
            }

        }


        private void Angry()
        {
            this.animation = new Animation("resources/sprites/Bandit_A.png", 48, 40);
            animation.FlipAnimation();
            if (this.lastMove != moveLeft)
                animation.FlipAnimation();

            if ((this.GetX() < this.GetWorld().GetActors()[0].GetX()))
                MoveLeft();


            animation.SetDuration(11);
            this.SetAnimation(this.animation);
            this.SetPosition(this.GetX(), this.GetY() - 25);
            time = 111;
            GetWorld().AddMessage(new Message("-20", this.GetX() + 40, this.GetY() - 60, 50, Color.Red, MessageDuration.Short));
            AttackPermissions = true;
        }

        public override void Update()
        {
            if (Live)
            {
                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Merlin");

                MerlinAttack();
                //this.ChangeHealth();
                //Console.WriteLine("Sketelon heal -- > " + this.GetHealth());

                if (attack == null)
                    attack = new ShortAttack(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"), this);
                
                if (time != 0)
                    time--;


                if (animation.GetResource() == "resources/sprites/Bandit_A.png")
                {
                    if (this.GetAnimation().GetCurrentFrame() == 4 & AttackPermissions)
                    {
                        if (attack.GetAttack())
                        {
                            ((AbstractCharacter)(this.GetWorld().GetActors().Find(x => x.GetName() == "Merlin"))).ChangeHealth(-20);
                            AttackPermissions = false;
                        }
                    }
                }


                if (time == 0)
                {
                    AttackPermissions = false;
                    if (animation.GetResource() != "resources/sprites/Bandit.png")
                    {
                        this.animation = new Animation("resources/sprites/Bandit.png", 48, 40);
                        animation.FlipAnimation();

                        if (this.lastMove == moveLeft)
                            animation.FlipAnimation();

                        this.SetAnimation(this.animation);
                        animation.SetDuration(8);
                    }

                    if (this.GetX() + 36 > (this.GetWorld().GetActors()[0].GetX() + 36))
                        if (this.GetX() + 36 - (this.GetWorld().GetActors()[0].GetX() + 36) < 50)
                            if ((this.GetY() - 30) < this.GetWorld().GetActors()[0].GetY())
                                if (this.GetWorld().GetActors()[0].GetY() < (this.GetY() + 30))
                                    Angry();

                    if ((this.GetX() + 36 < this.GetWorld().GetActors()[0].GetX() + 36))
                        if ((this.GetWorld().GetActors()[0].GetX() + 36) - this.GetX() + 36 < 50)
                            if ((this.GetY() - 30) < this.GetWorld().GetActors()[0].GetY())
                                if (this.GetWorld().GetActors()[0].GetY() < (this.GetY() + 30))
                                    Angry();


                    animation.Start();

                    if (Iter == 0)
                        this.x = random.Next(0, 2);

                    if (Old_iter == this.GetX() | this.GetX() > 655)
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


                    if (this.GetHealth() == 0)
                    {
                        this.EnemyDeath(new Animation("resources/sprites/Skull.png", 27, 30));
                        this.GetAnimation().Start();
                        Live = false;
                    }

                }
            }
        }
    }
}
