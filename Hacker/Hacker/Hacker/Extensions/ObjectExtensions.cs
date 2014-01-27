using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hacker.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsInstanceOf(this object o, Type type)
        {
            Type oType = typeof(object);
            Type t = o.GetType();
            while (t != oType)
            {
                if (t == type)
                    return true;

                t = t.BaseType;
            }
            return false;
        }
    }
}
