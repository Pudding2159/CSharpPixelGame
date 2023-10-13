using Game.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Game.Commands
{
    public class Jump : ICommand
    {

        private IActor actor;
        private int timer;
        private Animation animation;
        //private Move lastMove;
        private int GET_Y;
        private string lastMove;
        private int GET_X;
        public Jump(IActor actor, int time, string lastmove, int GET_X, int GET_Y) 
        {
            //  this.lastMove = lastmove;
            this.lastMove = lastmove;
            this.actor = actor;
            this.timer = time;
            this.GET_X = GET_X;
            this.GET_Y = GET_Y;

        }



        public void Execute()
        {
            if (!actor.GetWorld().IntersectWithWall(actor))
            {
                if (timer % 1 == 0 && timer != 0)
                {

                    if (this.lastMove == "moveRight")
                        for (int i = 0; i < 2; i++)
                        {
                            if (!actor.GetWorld().IntersectWithWall(actor))
                                actor.SetPosition((actor.GetX() + 3), (actor.GetY() - 3 - i));
                            if (actor.GetWorld().IntersectWithWall(actor))
                                actor.SetPosition(GET_X, GET_Y - 2 - i);

                        }
                    if (this.lastMove == "moveLeft")
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (!actor.GetWorld().IntersectWithWall(actor))
                                actor.SetPosition((actor.GetX() - 3), (actor.GetY() - 3 - i));
                            if (actor.GetWorld().IntersectWithWall(actor))
                                actor.SetPosition(GET_X, GET_Y - 2 - i);
                        }
                    }
                }
            }
        }
    }
}