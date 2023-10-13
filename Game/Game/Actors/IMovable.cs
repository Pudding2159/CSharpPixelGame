namespace Game.Actors
{
    public interface IMovable
    {
        void SetSpeedStrategy(ISpeedStrategy strategy);
        double GetSpeed(int speed);
        //double GetSpeed();
    }
}
