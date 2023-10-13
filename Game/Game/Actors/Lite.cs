

using Merlin2d.Game;

namespace Game.Actors
{
    public class Light : AbstractCharacter
    {
        private Animation animation;

        public Light(int x, int y) // úvodné nastavenia Caldron 
        {
              this.SetPosition(x, y);
            animation = new Animation("resources/sprites/light3.png", 64, 64);
            //animation = new Animation("resources/sprites/Walk.png", 73, 87);
            //animation = new Animation("resources/sprites/scp.png", 40, 40);

            this.SetAnimation(animation);
            this.GetAnimation().Start();
        }

        public override void Update()
        {
        }
    }
}
