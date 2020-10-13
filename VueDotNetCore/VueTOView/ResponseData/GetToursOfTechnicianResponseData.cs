using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.ResponseData
{
    public class GetToursOfTechnicianResponseData
    {
        public int OrderId { get; set; }
        public string RealStart { get; set; }
        public string RealEnd { get; set; }
        public string GeoLatitude { get; set; }
        public string GeoLongitude { get; set; }
        public string Address { get; set; }
    }
}
