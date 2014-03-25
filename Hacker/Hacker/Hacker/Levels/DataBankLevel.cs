using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Layers;
using Hacker.Managers;

namespace Hacker.Levels
{
    class DataBankLevel : Level
    {
        public DataBankLevel()
            : base()
        {
            PushLayer(new MapLayer("data_bank"));
            PushLayer(new CollisionLayer("data_bank_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            Player.Instance.GetComponent<Position>().Teleport(512, 1024);
            objectLayer.GameObjectManager.AddGameObject(new Exit<VaultLevel>(new Rectangle(128, 64, 384, 300), new Vector2(320, 448)));

            objectLayer.GameObjectManager.AddGameObject(new Counter(64, 576, 8));
            objectLayer.GameObjectManager.AddGameObject(new Counter(704, 576, 4));
            objectLayer.GameObjectManager.AddGameObject(new Counter(512, 702, 5));
            objectLayer.GameObjectManager.AddGameObject(new Counter(64, 960, 2));
            objectLayer.GameObjectManager.AddGameObject(new Counter(832, 1028, 2));
            objectLayer.GameObjectManager.AddGameObject(new CounterTop(128, 576, 6));
            objectLayer.GameObjectManager.AddGameObject(new CounterTop(832, 576, 8));

            objectLayer.GameObjectManager.AddGameObject(new GlassScreen(64, 512, 4));
            objectLayer.GameObjectManager.AddGameObject(new GlassScreen(704, 512, 2));

            objectLayer.GameObjectManager.AddGameObject(new Placeable(96, 1072, AssetManager.LoadTexture("couch3")));
            objectLayer.GameObjectManager.AddGameObject(new Placeable(928, 1104, AssetManager.LoadTexture("couch2")));

            var statue = new Placeable(512, 896, AssetManager.LoadTexture("statue"));
            statue.RemoveComponent(statue.GetComponent<MovementCollision>());
            statue.AddComponent(new BoundedMovementCollision(new Rectangle(0, 129, 128, 16)));
            objectLayer.GameObjectManager.AddGameObject(statue);

            objectLayer.GameObjectManager.AddGameObject(new Placeable("door", 640, 608, AssetManager.LoadTexture("door_close")));

            objectLayer.GameObjectManager.AddGameObject(new Teller());
            objectLayer.GameObjectManager.AddGameObject(new Wedge());
            objectLayer.GameObjectManager.AddGameObject(new Hitchcock());
            objectLayer.GameObjectManager.AddGameObject(new Briggs());
            
            objectLayer.GameObjectManager.AddGameObject(new Trigger(new Microsoft.Xna.Framework.Rectangle(480, 627, 64, 64), () => {
                var door = objectLayer.GameObjectManager.GetGameObjectById("door");
                if (door.GetBooleanVariable("open"))
                {
                    door.GetComponent<Sprite>().Texture = AssetManager.LoadTexture("door_close");
                    door.AddComponent(new MovementCollision());
                    door.SetBooleanVariable("open", false);
                }
            }));

            objectLayer.GameObjectManager.AddGameObject(new WallTerminal(545, 352));

            objectLayer.GameObjectManager.AddGameObject(new Placeable("vault_door", 320, 224, AssetManager.LoadTexture("vault_door")));

            PushLayer(objectLayer);
        }

        public override void OnLoad()
        {
            Player.Instance.GameCompleteState = GameCompleteState.ClubComplete;
            SoundManager.PlayMusic("databank");
        }
    }

}
