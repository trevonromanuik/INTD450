using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Hacker.Actions;
using Hacker.Components;
using Hacker.Managers;

using Action = Hacker.Actions.Action;

namespace Hacker.GameObjects
{
    public class GameObject
    {
        public string Id { get; set; }
        public GameObjectManager Manager { get; private set; }
        private readonly List<Component> components;
        private readonly VariableSet variableSet;
        private readonly Queue<Action> actionQueue;

        public GameObject()
        {
            components = new List<Component>();
            variableSet = new VariableSet();
            actionQueue = new Queue<Action>();
        }

        public void Initialize(GameObjectManager gameObjectManager)
        {
            Manager = gameObjectManager;
        }

        public T GetComponent<T>() where T : Component
        {
            return (T)components.Find(x => IsOfType<T>(x));
        }

        private bool IsOfType<T>(Component component) where T : Component
        {
            Type cType = typeof(Component);
            Type tType = typeof(T);

            Type type = component.GetType();
            while (type != cType)
            {
                if (type == tType)
                    return true;

                type = type.BaseType;
            }
            return false;
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
            component.Initialize(this);
        }

        public void AddComponents(List<Component> components)
        {
            components.AddRange(components);
            foreach (var component in components)
            {
                component.Initialize(this);
            }
        }

        public void RemoveComponent<T>() where T : Component
        {
            RemoveComponent(GetComponent<T>());
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }

            if (actionQueue.Count > 0)
            {
                actionQueue.Peek().Update(gameTime);
                if (actionQueue.Peek().Done)
                {
                    actionQueue.Dequeue();
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var component in components)
            {
                component.Draw(spriteBatch);
            }
        }

        public bool GetBooleanVariable(string name)
        {
            return variableSet.booleanVariables.ContainsKey(name) ?
                variableSet.booleanVariables[name] : false;
        }

        public void SetBooleanVariable(string name, bool value)
        {
            variableSet.booleanVariables[name] = value;
        }

        public int GetIntegerVariable(string name)
        {
            return variableSet.integerVariables.ContainsKey(name) ?
                variableSet.integerVariables[name] : 0;
        }

        public int IncrementIntegerVariable(string name)
        {
            if (variableSet.integerVariables.ContainsKey(name))
                variableSet.integerVariables[name]++;
            else
                variableSet.integerVariables[name] = 1;
            return variableSet.integerVariables[name];
        }

        public int DecrementIntegerVariable(string name)
        {
            if (variableSet.integerVariables.ContainsKey(name))
                variableSet.integerVariables[name]--;
            else
                variableSet.integerVariables[name] = -1;
            return variableSet.integerVariables[name];
        }

        public void SetIntegerVariable(string name, int value)
        {
            variableSet.integerVariables[name] = value;
        }

        public string GetStringVariable(string name)
        {
            return variableSet.stringVariables.ContainsKey(name) ?
                variableSet.stringVariables[name] : string.Empty;
        }

        public void SetStringVariable(string name, string value)
        {
            variableSet.stringVariables[name] = value;
        }

        public void AddAction(Action action)
        {
            actionQueue.Enqueue(action);
            action.Initialize(this);
        }
    }
}
