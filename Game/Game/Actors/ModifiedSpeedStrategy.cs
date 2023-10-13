namespace Game.Actors
{
    public class ModifiedSpeedStrategy : ISpeedStrategy
    {
        public int GetSpeed(int speed)
        {
            return 2 * speed;
        }
    }
}
