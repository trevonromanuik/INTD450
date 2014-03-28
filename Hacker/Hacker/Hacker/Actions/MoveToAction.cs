using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Hacker.Components;
using Hacker.GameObjects;

namespace Hacker.Actions
{
    public class MoveToAction : Action
    {
        private Vector2 initialPosition;
        private Vector2 endPosition;
        
        private double time;
        private double elapsedTime;

        public MoveToAction(Vector2 position, double time)
        {
            this.endPosition = position;
            this.time = time;
            this.elapsedTime = 0.0;
        }

        public MoveToAction(Vector2 initialPosition, Vector2 endPosition, double time)
        {
            this.initialPosition = initialPosition;
            this.endPosition = endPosition;
            this.time = time;
            this.elapsedTime = 0.0;
        }

        public override void Initialize(GameObject owner)
        {
            base.Initialize(owner);

            if (this.initialPosition.X == 0 && this.initialPosition.Y == 0)
            {
                var position = owner.GetComponent<Position>();
                this.initialPosition = new Vector2(position.X, position.Y);
            }
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            var position = Vector2.Lerp(initialPosition, endPosition, (float)(elapsedTime / time));
            Owner.GetComponent<Position>().Teleport(position.X, position.Y);
            if (elapsedTime / time > 1.0)
            {
                Done = true;
            }
        }
    }
}
