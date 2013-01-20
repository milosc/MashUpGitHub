using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Common.Binder
{
    public enum PropertyBinderBehavior
    {
        Manual=0,
        Lazy=1
    }
    public class PropertyBinderAttribute : Attribute
    {
        public Type BinderType { get; private set; }
        public PropertyBinderBehavior Behavior { get; private set; }
        public bool IsManual { get; private set; }
        public PropertyBinderAttribute(Type binderType, PropertyBinderBehavior behavior = PropertyBinderBehavior.Lazy) 
        { 
            BinderType = binderType;
            Behavior = behavior;
        }
        public PropertyBinderAttribute(PropertyBinderBehavior behavior = PropertyBinderBehavior.Manual)
        {
            Behavior = behavior;
            if (behavior != PropertyBinderBehavior.Manual)
                throw new ArgumentException("Invalid PropertyBinderBehavior");
        }   
    }
}
