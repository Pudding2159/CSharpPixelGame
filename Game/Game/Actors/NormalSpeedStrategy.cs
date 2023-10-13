namespace Game.Actors
{
    public class NormalSpeedStrategy : ISpeedStrategy
    {
        public int GetSpeed(int speed)
        {
            return speed;
        }
    }
}
