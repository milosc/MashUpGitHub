using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Site.Common.Utility;

namespace Bizis.Site.Common.Diagnostics
{
    public class ErrorReport
    {
        public string Md5Hash { get; private set; }
        public string Text { get; private set; }
        public int Count;
        public DateTime Created { get; private set; }
        public string Msg { get; set; }
        public Exception Error { get; set; }

        public ErrorReport(string msg, Exception ex)
        {
            Msg = msg ?? string.Empty;
            Error = ex;

            Text = Msg + "\n" + ex.Message;
            Md5Hash = TextUtility.GetMD5Hash(Text);
            Created = DateTime.Now;
            Count = 1;
        }


    }
}
