using Game.Actors;
using Game.Commands;
using Game.Factories;
using Game.Items;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("Game window", 1920, 1080);
            //GameContainer container = new GameContainer("Game window", 1600, 900);
            //GameContainer container = new GameContainer("Game window", 1366, 768);


            // container.GetWorld().CenterOn(new ActorFactory().Create("Player", "Merlin", 400, 100));

            container.SetMap("resources/maps/map01.tmx");


            container.GetWorld().SetPhysics(new Gravity());
            container.GetWorld().SetFactory(new ActorFactory());

            container.GetWorld().EnableLayeredRendering();


            container.GetWorld().AddInitAction((world) =>
            {
                IActor player = world.GetActors().ToList().Find(actor => actor is Player)!;
                world.CenterOn(player);
            }
           );

            container.SetCameraFollowStyle(CameraFollowStyle.CenteredInsideMapPreferTop);
            //container.SetCameraZoom(2);

            //1920, 1080
            container.SetCameraZoom(4.0f);

            //container.SetCameraZoom(0.7f);



            container.Run();
        }
    }
}