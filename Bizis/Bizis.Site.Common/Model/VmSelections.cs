using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Common.Model
{
    public class VmSelections<T>
    {
        public string HtmlNamePrefix { get; private set; }

        public VmValue<bool> IsAll { get; private set; }

        private HashSet<T> _Selection;
        public HashSet<T> Selection
        {
            get
            {
                if (_Selection == null)
                    _Selection = new HashSet<T>();
                return _Selection;
            }
        }

        
        private T[] _Options;
        public T[] Options
        {
            get
            {
                if (_Options == null)
                    _Options = GetOptions();
                return _Options;
            }
        }

        public VmSelections(string htmlNamePrefix)
        {
            HtmlNamePrefix = htmlNamePrefix;
            IsAll = new VmValue<bool>(htmlNamePrefix + "__all");
        }
        protected virtual T[] GetOptions()
        {
            throw new NotImplementedException();
        }
        public string GetHtmlName(T id)
        {
            return HtmlNamePrefix + "_" + id.ToString();
        }
        public HashSet<T> GetFilter()
        {
            if (IsAll.Val)
                return null;
            if (Options.Length == Selection.Count)
                return null;
            return Selection;

        }

    }
}
