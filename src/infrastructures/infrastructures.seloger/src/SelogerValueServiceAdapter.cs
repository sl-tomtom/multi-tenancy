using System;
using application.tenancy;

namespace infrastructures.seloger
{
    public class SelogerValueServiceAdapter : IValueService
    {
        public int GetValue()
        {
            return 2;
        }
    }

    public class SelogerSourceServiceAdapter : ISourceService
    {
        public string GetSource()
        {
            return "seloger";
        }
    }

}
