using System;
using application.tenancy;

namespace infrastructures.logicimmo
{
    public class LogicimmoValueServiceAdapter : IValueService
    {
        public int GetValue()
        {
            return 1;
        }
    }

    public class LogicimmoSourceServiceAdapter : ISourceService
    {
        public string GetSource()
        {
            return "LogicImmo";
        }
    }
}
