using System;
using application.tenancy;

namespace infrastructures.common
{
    public class CommonValueServiceAdapter : IValueService
    {
        public int GetValue()
        {
            return 0;
        }
    }

    public class CommonSourceServiceAdapter : ISourceService
    {
        public string GetSource()
        {
            return "Common";
        }
    }
}
