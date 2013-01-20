using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.ComponentModel;
using Bizis.Site.Common.Model;

namespace Bizis.Site.Common.Binder
{
    public class AttribBaseBinder: DefaultModelBinder
    {
        protected override void BindProperty(ControllerContext cc, ModelBindingContext bc, PropertyDescriptor propertyDescriptor)  
        {        
            var propertyBinderAttribute = _TryFindPropertyBinderAttribute(propertyDescriptor);    
            if (propertyBinderAttribute != null)    
            {   
                if(propertyBinderAttribute.Behavior == PropertyBinderBehavior.Lazy)
                {
                    var binder = _CreateLazyBinder(propertyBinderAttribute);
                    var value = propertyDescriptor.GetValue(bc.Model);
                    binder.BindModel(cc, bc, value);
                }
                else if (propertyBinderAttribute.Behavior == PropertyBinderBehavior.Manual)
                {
                    //ignore
                }
                else
                {
                    var binder = _CreateBinder(propertyBinderAttribute);
                    var value = binder.BindModel(cc, bc);
                    propertyDescriptor.SetValue(bc.Model, value);
                }
            }    
            else // revert to the default behavior.    
            {       
                base.BindProperty(cc, bc, propertyDescriptor);    
            }  
        }

        private ModelLazyBinder _CreateLazyBinder(PropertyBinderAttribute propertyBinderAttribute)  
        {
            return (ModelLazyBinder)DependencyResolver.Current.GetService(propertyBinderAttribute.BinderType);  
        }   

        private IModelBinder _CreateBinder(PropertyBinderAttribute propertyBinderAttribute)  
        {    
            return (IModelBinder)DependencyResolver.Current.GetService(propertyBinderAttribute.BinderType);  
        }
   
        private PropertyBinderAttribute _TryFindPropertyBinderAttribute(PropertyDescriptor propertyDescriptor)  
        {    
            return propertyDescriptor.Attributes
                .OfType<PropertyBinderAttribute>()      
                .FirstOrDefault();  
        }

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
        public void Fill<T>(ModelBindingContext bc, VmValue<T> v)
        {
            v.Val = GetValue<T>(bc, v.Name);
        }


        protected void FillFromQueryString<V>(ModelBindingContext bc, VmSelections<V> m, Func<string, System.Nullable<V>> convert) where V : struct
        {
            ValueProviderResult vpr = bc.ValueProvider.GetValue(m.HtmlNamePrefix);
            if (vpr == null)
                m.IsAll.Val = true;
            else if (!string.IsNullOrEmpty(vpr.AttemptedValue))
            {
                foreach (var s in vpr.AttemptedValue.Split(','))
                {
                    System.Nullable<V> id = convert(s);
                    if(id.HasValue)
                        m.Selection.Add(id.Value);
                }
            }
        }
        protected byte? ConvertToByte(string s)
        {
            byte id;
            if (byte.TryParse(s, out id))
                return id;
            else
                return null;
        }
        protected short? ConvertToShort(string s)
        {
            short id;
            if (short.TryParse(s, out id))
                return id;
            else
                return null;
        }
        protected int? ConvertToInt(string s)
        {
            int id;
            if (int.TryParse(s, out id))
                return id;
            else
                return null;
        }
        protected long? ConvertToLong(string s)
        {
            long id;
            if (long.TryParse(s, out id))
                return id;
            else
                return null;
        }
    }
}
