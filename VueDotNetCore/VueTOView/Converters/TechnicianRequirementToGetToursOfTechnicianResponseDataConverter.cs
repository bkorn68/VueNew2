using ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTOView.ResponseData;

namespace VueTOView.Converters
{
    public static class TechnicianRequirementToGetToursOfTechnicianResponseDataConverter
    {
        public static GetToursOfTechnicianResponseData Convert(TechnicianRequirement source)
        {
            GetToursOfTechnicianResponseData target = new GetToursOfTechnicianResponseData()
            {
                //OrderId = source.Appointment.OrderID.SourceId,
                RealStart = source.RealStart.ToShortTimeString(),
                RealEnd = source.RealEnd.ToShortTimeString(),
                //GeoLatitude = source.Appointment.GeoLocation.GeoLatitude.ToString().Replace(',', '.'),
                //GeoLongitude = source.Appointment.GeoLocation.GeoLongitude.ToString().Replace(',', '.'),
                //Address = source.Appointment.GeoLocation.GetAddressString().Replace(System.Environment.NewLine, " "),

            };
            return target;
        }

    }
}
