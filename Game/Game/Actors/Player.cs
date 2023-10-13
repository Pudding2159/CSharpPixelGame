using Game.Commands;
using Game.Items;
using Merlin2d.Game.Enums;
using Merlin2d.Game.Items;
using Merlin2d.Game;

using Game.Commands;
using Game.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using Merlin2d.Game.Items;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Resources;

namespace Game.Actors
{
    public class Player : AbstractCharacter
    {

        // TODO: make the player into a wizard
        protected Animation animation;

        private int speed; // initial speed, for current speed use SpeedStrategy
        private ICommand lastMove;
        private ICommand moveUp;
        private ICommand moveDown;
        private ICommand moveRight;
        private ICommand moveLeft;
        private ICommand Jump;
        private ICommand LastMove2;
        private ICommand LastMove3;
        private ICommand LastMove4;

        private ICharacterState state;
        private int GET_Y = 0;
        private int GET_X = 0;

        private bool Live = true;
        //TIMERS
        private int Delay = 0;
        private int FallTime = 0;
        private int time_Jump = 0;
        private int UP = 0;
        private int test = 0;
        private int time_set = 0;
        private int time_ = 0;

        private IInventory backpack;
        public IState State { get; set; }

        private static Player instance = null;
        public static Player Instance(int x, int y, int speed)
        {
            if (instance == null)
                instance = new Player(x, y, speed);
            
            return instance;
        }

        public Player(int x, int y, int speed)
        {

            Animation_Run = new Animation("resources/sprites/player/Run.png", 80, 43);
            Animation_Roll = new Animation("resources/sprites/player/Roll.png", 80, 43);
            Animation_Fall = new Animation("resources/sprites/player/Fall.png", 80, 43);
            Animation_Idle = new Animation("resources/sprites/player/Idle.png", 80, 43);
            Animation_Attack = new Animation("resources/sprites/player/Attack.png", 80, 43);
            Animation_Attack_2 = new Animation("resources/sprites/player/AttCombo.png", 80, 43);

            this.SetPosition(x, y);
            animation = Animation_Run;
            animation.SetAnimationLayer(AnimationLayer.Medium);
            this.SetAnimation(animation);
            this.GetAnimation().Start();

            SetSpeedStrategy(new NormalSpeedStrategy());

            //Console.WriteLine(this.get)


            this.speed = speed;
            this.moveUp = new Move(this, speed, 0, -1);
            this.moveDown = new Move(this, speed, 0, 1);
            this.moveRight = new Move(this, GetSpeed(speed), 1, 0);
            this.moveLeft = new Move(this, GetSpeed(speed), -1, 0);
            this.Jump = new Jump(this, time_, "moveRight", GET_X, GET_Y);
            this.lastMove = moveRight;
            this.GET_Y = this.GetY();
            this.state = new LivingState(this);
            this.backpack = new Backpack(10);
            this.LastMove2 = moveRight;
            this.LastMove3 = moveRight;
            this.LastMove4 = moveRight;

            this.time_Jump = 0;

        }

        public void ChangeToNoBlood()
        {
            State = new NoBloodState();
        }
        public void ChangeToWithBlood()
        {
            State = new WithBloodState();
        }

        private void Roll()
        {
            if (time_set == 0)
            {
                if (Input.GetInstance().IsKeyDown(Input.Key.UP))
                {
                    if (UP == 0)
                    {
                        UP = 20;
                        //animation = new Animation("resources/sprites/player/Roll.png", 80, 43);
                        animation = Animation_Roll;
                        animation.SetDuration(1);
                        this.SetAnimation(animation);
                        this.GetAnimation().Start();
                        if (lastMove == moveLeft)
                            animation.FlipAnimation();


                        test = 1;

                    }
                    time_set = 140;
                }
            }

            if (test == 1)
            {
                if (LastMove2 == moveLeft)
                    for (int i = 0; i < 3; i++)
                        this.moveLeft.Execute();
                else
                    for (int i = 0; i < 3; i++)
                        this.moveRight.Execute();
            }
        }

        private void MoveLeft()
        {
            if (!(Input.GetInstance().IsKeyDown(Input.Key.RIGHT)))
            {
                if (UP == 0)
                {
                    if (this.GET_Y == this.GetY())
                    {
                        if (animation.GetResource() != "resources/sprites/player/Run.png")//"resources/sprites/123.png")
                        {
                            animation = Animation_Run;
                            animation.SetDuration(5);
                            this.SetAnimation(animation);
                        }
                    }
                    if (this.GET_Y != this.GetY())
                    {
                        if (animation != Animation_Fall)//"resources/sprites/Jump_Down.png")
                        {
                            animation = Animation_Fall;
                            this.SetAnimation(animation);
                            this.GetAnimation().Start();

                        }
                    }


                    if (LastMove2 == moveRight)
                    {
                        Animation_Idle.FlipAnimation();
                        Animation_Fall.FlipAnimation();
                        Animation_Roll.FlipAnimation();
                        Animation_Run.FlipAnimation();
                        Animation_Attack.FlipAnimation();
                        Animation_Attack_2.FlipAnimation();
                        if (this.GET_Y != this.GetY())
                        {
                            if (animation.GetResource() == "resources/sprites/player/Fall.png")//"resources/sprites/Jump_Down.png")
                            {
                                animation = Animation_Fall;
                                this.SetAnimation(animation);
                                this.GetAnimation().Start();

                            }
                        }
                        LastMove2 = moveLeft;
                    }
                    animation.Start();
                    this.moveLeft.Execute();
                }
            }
        }

        private void MoveRight()
        {
            if (UP == 0)
            {

                if (!(Input.GetInstance().IsKeyDown(Input.Key.LEFT)))
                {

                    if (this.GET_Y == this.GetY())
                    {
                        if (animation.GetResource() != "resources/sprites/player/Run.png")//"resources/sprites/123.png")
                        {
                            //animation = new Animation("resources/sprites/player/Run.png", 80, 43);
                            animation = Animation_Run;
                            animation.SetDuration(5);
                            this.SetAnimation(animation);
                        }
                    }

                    if (this.GET_Y != this.GetY())
                    {
                        if (animation != Animation_Fall)//"resources/sprites/Jump_Down.png")
                        {
                            //animation = new Animation("resources/sprites/player/Fall.png", 80, 43);
                            animation = Animation_Fall;
                            this.SetAnimation(animation);
                            this.GetAnimation().Start();

                        }
                    }



                    animation.Start();
                    this.moveRight.Execute();
                    if (LastMove2 == moveLeft)
                    {
                        Animation_Idle.FlipAnimation();
                        Animation_Fall.FlipAnimation();
                        Animation_Roll.FlipAnimation();
                        Animation_Run.FlipAnimation();
                        Animation_Attack.FlipAnimation();
                        Animation_Attack_2.FlipAnimation();
                        if (this.GET_Y != this.GetY())
                        {
                            if (animation.GetResource() == "resources/sprites/player/Fall.png")//"resources/sprites/Jump_Down.png")
                            {
                                animation = Animation_Fall;
                                //Animation_Fall.FlipAnimation();
                                this.SetAnimation(animation);
                                this.GetAnimation().Start();

                            }
                        }
                    }
                    LastMove2 = moveRight;
                }
            }
        }


        private void Stay()
        {
            if (this.GET_Y == this.GetY())
            {
                if (animation.GetResource() != "resources/sprites/player/Idle.png")
                {
                    //animation = new Animation("resources/sprites/player/Idle.png", 80, 43);
                    animation = Animation_Idle;
                    this.SetAnimation(animation);
                    this.GetAnimation().Start();
                    animation.SetDuration(5);

                }
            }

            animation.Start();
        }

        private void Jump_UP()
        {

            if (time_Jump == 0)
            {
                if (!this.GetWorld().IntersectWithWall(this))
                    if (Input.GetInstance().IsKeyDown(Input.Key.SPACE))
                    {

                        time_ = 15;
                        time_Jump = 40;
                        UP = 30;
                        if (animation != Animation_Fall)
                        {
                            animation = Animation_Fall;
                            this.SetAnimation(animation);
                            this.GetAnimation().Start();
                        }
                    }
            }

            if (this.LastMove2 == moveRight)
                this.Jump = new Jump(this, time_, "moveRight", GET_X, GET_Y);
            if (this.LastMove2 == moveLeft)
                this.Jump = new Jump(this, time_, "moveLeft", GET_X, GET_Y);
            this.Jump.Execute();

        }



        public IState GetState()
        {
            return State;
        }

        public override void Update()
        {


            //Console.WriteLine((this.GetBackpack().GetItem().GetName()));

            if (this.GetHealth() < 40)
            {
                ChangeToWithBlood();
                State.ChangeSpeed(this);
            }


            if (time_Jump != 0)
                time_Jump--;


            if (this.GetHealth() > 0)
            {
                if (Delay == 0)
                {
                    if (time_set != 0)
                        time_set--;

                    if (UP != 0)
                    {
                        animation.Start();
                        UP--;
                        if (UP == 0)
                            test = 0;
                    }

                    Roll();



                    if (animation == Animation_Attack | animation == Animation_Attack_2)
                        this.StatusAttack(true);
                    else
                        this.StatusAttack(false);




                    if (Input.GetInstance().IsKeyDown(Input.Key.Q))
                    {
                        if (UP == 0)
                        {
                            UP = 30;
                            animation = Animation_Attack;
                            animation.SetDuration(6);
                            this.SetAnimation(animation);
                            this.GetAnimation().Start();
                            //this.moveUp.Execute();
                        }

                    }

                    if (Input.GetInstance().IsKeyDown(Input.Key.W))
                    {
                        if (UP == 0)
                        {
                            UP = 80;
                            animation = Animation_Attack_2;
                            animation.SetDuration(3);
                            this.SetAnimation(animation);
                            this.GetAnimation().Start();
                        }

                    }

                    Jump_UP();

                    if (UP == 0)
                    {
                        if (Input.GetInstance().IsKeyDown(Input.Key.DOWN))
                        {
                            animation.Start();
                            this.moveDown.Execute();
                        }

                        if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT) && !(Input.GetInstance().IsKeyDown(Input.Key.LEFT)))
                            MoveRight();

                        else if (Input.GetInstance().IsKeyDown(Input.Key.LEFT) && !(Input.GetInstance().IsKeyDown(Input.Key.RIGHT)))
                            MoveLeft();

                        else
                            Stay();
                    }

                    if (this.GET_Y != this.GetY())
                        FallTime++;

                    if (this.GET_Y == this.GetY())
                    {
                        if (FallTime > 80)
                        {
                            this.ChangeHealth(-100);
                        }
                        FallTime = 0;
                    }

                    GET_X = 0;
                }
            }
            else
            {
                if (Live)
                {
                    Delay = 120;
                    this.SetAnimation(new Animation("resources/sprites/player/Death.png", 80, 43));
                    this.GetAnimation().Start();
                    this.GetAnimation().SetPingPong(true);
                }

                Live = false;

                if (Delay == 0)
                {
                    this.Die();
                    Live = true;
                }
            }
            GET_Y = this.GetY();
            GET_X = this.GetX();

            if (time_ > 0)
                time_--;

            if (Delay > 0)
                Delay--;

            if (this.GetY() > 855)
                this.ChangeHealth(-100);

        }


        public IInventory GetBackpack()
        {
            return this.backpack;
        }



    }
}
