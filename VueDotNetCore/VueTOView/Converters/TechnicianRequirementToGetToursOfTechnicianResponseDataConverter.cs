namespace VueTOView.Converters
{
    using ServiceReference2;
    using System;
    using VueTOView.ResponseData;

    public static class TechnicianRequirementToGetToursOfTechnicianResponseDataConverter
    {
        public static GetToursOfTechnicianResponseData Convert(TechnicianRequirement source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            GetToursOfTechnicianResponseData target = new GetToursOfTechnicianResponseData()
            {
                OrderId = source.Appointment.OrderID.SourceId,
                RealStart = source.RealStart.ToShortTimeString(),
                RealEnd = source.RealEnd.ToShortTimeString(),
                GeoLatitude = source.Appointment.GeoLocation.GeoLatitude.ToString().Replace(',', '.'),
                GeoLongitude = source.Appointment.GeoLocation.GeoLongitude.ToString().Replace(',', '.'),
                Address = source.Appointment.GeoLocation.GetAddressString().Replace(System.Environment.NewLine, " ", System.StringComparison.InvariantCulture),
            };
            return target;
        }
    }
}
