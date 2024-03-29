﻿using Game.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;
using System.Numerics;

namespace Game.Actors
{
    public class Sniper : AbstractCharacter
    {
        private Animation animation;
        private int speed;
        private int x;
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand moveLeft;
        private ICommand moveRight;
        private int Old_iter = 0;
        private int Iter = 0;
        public int temp = 0;
        private ICommand lastMove;
        private int time = 0;
        private List<IActor> List_Game = new List<IActor>();
        private Random random = new Random();
        private LongDistanceAttack distanceAttack;
        private Animation distanceAttack_A;
        private bool Live = true;
        private Player player;


        public Sniper(int x, int y, int speed)
        {
            this.distanceAttack_A  = new Animation("resources/sprites/Arrow.png", 24, 5);

            this.SetPosition(x, y);
            this.animation = new Animation("resources/sprites/Run_Sniper.png", 46, 44);
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
                        {
                            this.ChangeHealth(-10);
                            Live = false;

                        }
                    }

                }
            }

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


        private void Angry()
        {
            this.animation = new Animation("resources/sprites/000.png", 46, 44);
            animation.SetDuration(11);
            this.SetAnimation(this.animation);
            //GetWorld().AddMessage(new Message("-20", this.GetX() + 40, this.GetY() - 60, 50, Color.Red, MessageDuration.Short));


            if (this.GetX()+20 < this.GetWorld().GetActors()[0].GetX()+36)
                if (this.lastMove == moveRight)
                    animation.FlipAnimation();

            if (this.GetX()+20 > this.GetWorld().GetActors()[0].GetX()+36)
                animation.FlipAnimation();



            if ((this.GetX() < this.GetWorld().GetActors()[0].GetX()))
            {
                distanceAttack = new LongDistanceAttack(3, this, distanceAttack_A, this.GetX(), this.GetY(), "Right");
            }


            if ((this.GetX() > this.GetWorld().GetActors()[0].GetX()))
            {
                distanceAttack = new LongDistanceAttack(3, this, distanceAttack_A, this.GetX(), this.GetY(), "Left");
            }
            this.GetWorld().AddActor(distanceAttack);
            time = 60;
        }







        public override void Update()
        {

            Console.WriteLine("Heal --- > " + this.GetHealth());
            if (Live)
            {
                if (time != 0)
                    time--;

                player = (Player)GetWorld().GetActors().Find(actor => actor.GetName() == "Merlin");

                MerlinAttack();
                if (time == 0)
                {

                    if (animation.GetResource() != "resources/sprites/Run_Sniper.png")
                    {
                        this.animation = new Animation("resources/sprites/Run_Sniper.png", 46, 44);
                        if (this.lastMove == moveLeft)
                            animation.FlipAnimation();

                        this.SetAnimation(this.animation);
                        animation.SetDuration(8);
                        //if (this.lastMove == moveLeft)
                        //    animation.FlipAnimation();
                    }



                    if (this.GetX() + 36 > (this.GetWorld().GetActors()[0].GetX() + 36))
                        if (this.GetX() + 36 - (this.GetWorld().GetActors()[0].GetX() + 36) < 400)
                            if ((this.GetY() - 30) < this.GetWorld().GetActors()[0].GetY())
                                if (this.GetWorld().GetActors()[0].GetY() < (this.GetY() + 30))
                                    Angry();

                    if ((this.GetX() + 36 < this.GetWorld().GetActors()[0].GetX() + 36))
                        if ((this.GetWorld().GetActors()[0].GetX() + 36) - this.GetX() + 36 < 400)
                            if ((this.GetY() - 30) < this.GetWorld().GetActors()[0].GetY())
                                if (this.GetWorld().GetActors()[0].GetY() < (this.GetY() + 30))
                                    Angry();


                    //this.GetWorld().GetActors()[0];




                    animation.Start();
                    if (Iter == 0)
                        this.x = random.Next(0, 2);

                    if (Old_iter == this.GetX() | this.GetX() < 1115)
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
                if (!Live) 
                {
                    this.EnemyDeath(new Animation("resources/sprites/Skull.png", 27, 30));
                    this.GetAnimation().Start();
                }

            }
            //Console.WriteLine("Player-->" + this.GetWorld().GetActors()[0].GetX());
            //Console.WriteLine("Demon-->" + this.GetX());

        }
    }
}
