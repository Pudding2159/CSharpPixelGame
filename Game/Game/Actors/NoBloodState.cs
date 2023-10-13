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
    public class NoBloodState : IState
    {
      
        public void ChangeSpeed(IActor player)
        {
            
            player.SetAnimation(new Animation("resources/sprites/Heart.png", 6, 6));

        }
    }

}