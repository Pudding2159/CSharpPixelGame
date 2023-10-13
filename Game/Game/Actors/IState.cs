using Merlin2d.Game.Actors;
using System;
namespace Game.Actors
{
	public interface IState
	{
        public void ChangeSpeed(IActor player);

    }
}

