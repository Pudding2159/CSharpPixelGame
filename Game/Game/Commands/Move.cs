using Game.Actors;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;

namespace Game.Commands
{
    public class Move : ICommand
    {
        private IActor actor;
        private int step;
        private int dx;
        private int dy;


        private int player_Get_X;
        private int skeleton_Get_X;


        public Move(IActor movable, int step, int dx, int dy)
        {

            
            if (!(movable is IActor))
            {
                throw new ArgumentException("Can only move actors");
            }

            this.step = step;
            this.dx = dx;
            this.dy = dy;
            this.actor = (IActor)movable;


          
        
        }
        public void Execute()
        {
            // TODO: should work with float values - lab 8
            int oldX = this.actor.GetX();
            int oldY = this.actor.GetY();
            int newX = this.actor.GetX() + step * dx;
            int newY = this.actor.GetY() + step * dy;

            this.actor.SetPosition(newX, newY);

            if (this.actor.GetWorld().IntersectWithWall(this.actor))
                this.actor.SetPosition(oldX, oldY);

        }





    }
}
