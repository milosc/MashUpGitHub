using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bizis.Common.Diagnostics;
using Bizis.Site.Common.Services;

namespace Bizis.Site.Common.Diagnostics
{
    public class ErrorReportingService
    {
        private const double _HoursBetweenResend = 1.5;
        private Dictionary<string, ErrorReport> _Md52Rep = new Dictionary<string, ErrorReport>();
        private object _Lock = new object();
        internal void ReportError(string msg, Exception ex)
        {
            ErrorReport rep = new ErrorReport(msg, ex);
            ErrorReport repOld;
            lock (_Lock)
            {
                if (_Md52Rep.TryGetValue(rep.Md5Hash, out repOld))
                {
                    if (repOld.Created.AddHours(_HoursBetweenResend) < DateTime.Now)
                    {
                        _Md52Rep[rep.Md5Hash] = rep;
                        _SendReport(repOld);
                    }
                    else
                        repOld.Count++;
                }
                else
                {
                    _Md52Rep[rep.Md5Hash] = rep;
                }
            }
        }

        private void _SendReport(ErrorReport rep)
        {
            Log.Error(rep.Msg, rep.Error, false);
            EmailService.TrySend_ErrorReport(rep.Text + "\n ErrorsCount:" + rep.Count);
        }
    }
}
