using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Hacker.Components;
using Hacker.GameObjects;
using Hacker.Levels;
using Hacker.Managers;
using Hacker.Screens;

namespace Hacker.Managers
{
    static class TextInputManager
    {
        #region alphanumeric key mappings

        static readonly Dictionary<Keys, char> keys = new Dictionary<Keys, char>
        {
            { Keys.A, 'a' },
            { Keys.B, 'b' },
            { Keys.C, 'c' },
            { Keys.D, 'd' },
            { Keys.E, 'e' },
            { Keys.F, 'f' },
            { Keys.G, 'g' },
            { Keys.H, 'h' },
            { Keys.I, 'i' },
            { Keys.J, 'j' },
            { Keys.K, 'k' },
            { Keys.L, 'l' },
            { Keys.M, 'm' },
            { Keys.N, 'n' },
            { Keys.O, 'o' },
            { Keys.P, 'p' },
            { Keys.Q, 'q' },
            { Keys.R, 'r' },
            { Keys.S, 's' },
            { Keys.T, 't' },
            { Keys.U, 'u' },
            { Keys.V, 'v' },
            { Keys.W, 'w' },
            { Keys.X, 'x' },
            { Keys.Y, 'y' },
            { Keys.Z, 'z' },
            { Keys.D1, '1' },
            { Keys.D2, '2' },
            { Keys.D3, '3' },
            { Keys.D4, '4' },
            { Keys.D5, '5' },
            { Keys.D6, '6' },
            { Keys.D7, '7' },
            { Keys.D8, '8' },
            { Keys.D9, '9' },
            { Keys.D0, '0' },
            { Keys.Space, ' '},
            { Keys.OemPeriod, '.'}
        };

        #endregion

        #region shift character mappings

        static readonly Dictionary<Keys, char> shiftKeys = new Dictionary<Keys, char>
        {
            { Keys.A, 'a' },
            { Keys.B, 'b' },
            { Keys.C, 'c' },
            { Keys.D, 'd' },
            { Keys.E, 'e' },
            { Keys.F, 'f' },
            { Keys.G, 'g' },
            { Keys.H, 'h' },
            { Keys.I, 'i' },
            { Keys.J, 'j' },
            { Keys.K, 'k' },
            { Keys.L, 'l' },
            { Keys.M, 'm' },
            { Keys.N, 'n' },
            { Keys.O, 'o' },
            { Keys.P, 'p' },
            { Keys.Q, 'q' },
            { Keys.R, 'r' },
            { Keys.S, 's' },
            { Keys.T, 't' },
            { Keys.U, 'u' },
            { Keys.V, 'v' },
            { Keys.W, 'w' },
            { Keys.X, 'x' },
            { Keys.Y, 'y' },
            { Keys.Z, 'z' },
            { Keys.D1, '!' },
            { Keys.D2, '@' },
            { Keys.D3, '#' },
            { Keys.D4, '$' },
            { Keys.D5, '%' },
            { Keys.D6, '^' },
            { Keys.D7, '&' },
            { Keys.D8, '*' },
            { Keys.D9, '(' },
            { Keys.D0, ')' },
            { Keys.Space, ' '},
            { Keys.OemPeriod, '.'}
        };

        #endregion

        static StringBuilder builder = new StringBuilder();

        public static string GetTextInput(KeyboardState prevKeyState, KeyboardState keyState)
        {
            builder.Clear();

            // handle alphanumeric keys
            foreach (Keys key in keys.Keys)
            {
                if (IsKeyPressed(key, prevKeyState, keyState))
                {
                    var c = keyState.IsKeyDown(Keys.LeftShift) || keyState.IsKeyDown(Keys.RightShift) ? shiftKeys[key] : keys[key];
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }

        static bool IsKeyPressed(Keys key, KeyboardState prevKeyState, KeyboardState keyState)
        {
            return prevKeyState.IsKeyUp(key)
                && keyState.IsKeyDown(key);
        }
    }
}
