using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bizis.Site.Common.Model
{
    public class RmValueBase
    {
        public string Name { get; private set; }
        private string _SqlName;
        public string SqlName
        {
            get
            {
                if (_SqlName == null)
                    _SqlName = "[" + Name + "]";
                return _SqlName;
            }

        }
        private string _SqlParam;
        public string SqlParam
        {
            get
            {

                if (_SqlParam == null)
                    _SqlParam = "@" + ((_Parent == null || !_Parent.No.HasValue) ? Name : (Name + "_" + _Parent.No.Value));
                return _SqlParam;
            }

        }
        private RmBase _Parent;
        public RmValueBase(string name, RmBase parent)
            : this(name)
        {
            _Parent = parent;
        }

        public RmValueBase(string name)
        {
            Name = name;
        }
    }
}
