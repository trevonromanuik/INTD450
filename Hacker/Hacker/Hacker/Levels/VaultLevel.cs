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
    class VaultLevel : Level
    {
        public VaultLevel()
            : base()
        {
            PushLayer(new MapLayer("vault"));
            PushLayer(new CollisionLayer("vault_collision"));

            ObjectLayer objectLayer = new ObjectLayer();
            objectLayer.GameObjectManager.AddGameObject(new VaultTerminal(320,288));
            objectLayer.GameObjectManager.AddGameObject(Player.Instance);
            PushLayer(objectLayer);
        }
    }
}
