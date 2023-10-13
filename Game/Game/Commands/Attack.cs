using Game.Actors;

namespace Game.Commands
{
    internal class Attack : Demon
    {
        private int x;
        private int y;
        private int speed;
        public Attack(int x, int y, int speed) : base(x, y, speed)
        {
            this.x = x;
            this.y = y;
            this.speed = speed;
        }




    }
}
