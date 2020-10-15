using ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTOView.ResponseData;

namespace VueTOView.Converters
{
    public static class TechnicianToResponseDataConverter
    {
        public static GetTechniciansResponseData Convert(Technician source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            GetTechniciansResponseData target = new GetTechniciansResponseData()
            {
                Name = source.Name,
                SourceId = source.ID.SourceId
            };
            return target;
        }

    }
}
