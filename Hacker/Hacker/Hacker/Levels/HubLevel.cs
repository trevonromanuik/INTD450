using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.Levels
{
    class HubLevel : Level
    {
        public HubLevel()
            : base()
        {
            PushLayer(new MapLayer("hub"));
            PushLayer(new CollisionLayer("hub_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(320, 384);
            objectLayer.GameObjectManager.AddGameObject(new Anon());
       
            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.SpoofReset();
            Player.Instance.GetComponent<AnimatedSprite>().PlayAnimation("up");

            // Anon has different facing direction and position at the very end of the game
            if (Player.Instance.GameCompleteState == GameCompleteState.DeepWebComplete)
            {

                GameScreen.Level.GetLayer<ObjectLayer>().GameObjectManager.GetGameObjectById("anon").GetComponent<AnimatedSprite>().PlayAnimation("up");
                GameScreen.Level.GetLayer<ObjectLayer>().GameObjectManager.GetGameObjectById("anon").GetComponent<Position>().Teleport(320, 150);
            }
            else
            {
                // Reset anon to be facing down each time you enter the level
                GameScreen.Level.GetLayer<ObjectLayer>().GameObjectManager.GetGameObjectById("anon").GetComponent<AnimatedSprite>().PlayAnimation("down");
            }

            // Music is different depending on game state
            GameCompleteState state = Player.Instance.GameCompleteState;
            if (state == GameCompleteState.GameStart)
            {
                SoundManager.PlayMusic("intro");
            }
            else if (state == GameCompleteState.ClubComplete | state == GameCompleteState.DataBankComplete)
            {
                SoundManager.PlayMusic("hub");
            }
            else if (state == GameCompleteState.DeepWebComplete)
            {
                SoundManager.StopMusic();
            }
        }
    }
}
