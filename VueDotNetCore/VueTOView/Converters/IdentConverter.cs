using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.Converters
{
    public static class IdentConverter
    {
        public static ServiceReference2.Ident ConvertFromReference1To2(ServiceReference1.Ident ident1)
        {
            if (ident1 == null) throw new ArgumentNullException(nameof(ident1));
            ServiceReference2.Ident ident2 = new ServiceReference2.Ident()
            {
                MandatorIds = ident1.MandatorIds,
                SystemuserId = ident1.SystemuserId,
                Timestamp = ident1.Timestamp,
                Token = ident1.Token

            };
            return ident2;
        }
    }
}
