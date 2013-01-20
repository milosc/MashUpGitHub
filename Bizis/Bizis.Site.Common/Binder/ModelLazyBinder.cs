using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Common.Binder
{
    public abstract class ModelLazyBinder
    {
        public T GetValue<T>(ModelBindingContext bc, string key)
        {
            ValueProviderResult valueResult = null;
            if (bc.ValueProvider.ContainsPrefix(key))
                valueResult = bc.ValueProvider.GetValue(key);
            bc.ModelState.SetModelValue(key, valueResult);
            if (valueResult == null)
                return default(T);
            return (T)valueResult.ConvertTo(typeof(T));
        }

         public abstract void BindModel(ControllerContext cc, ModelBindingContext bc, object value);

         public void Fill<T>(ModelBindingContext bc, VmValue<T> v)
         {
             v.Val = GetValue<T>(bc, v.Name);
         }
    }
}
