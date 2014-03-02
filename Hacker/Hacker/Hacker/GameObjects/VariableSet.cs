using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.GameObjects
{
    public class VariableSet
    {
        public readonly Dictionary<string, bool> booleanVariables;
        public readonly Dictionary<string, int> integerVariables;
        public readonly Dictionary<string, string> stringVariables;

        public VariableSet()
        {
            booleanVariables = new Dictionary<string, bool>();
            integerVariables = new Dictionary<string, int>();
            stringVariables = new Dictionary<string, string>();
        }
    }
}
