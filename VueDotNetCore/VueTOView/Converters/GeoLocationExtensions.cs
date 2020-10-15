namespace VueTOView.Converters
{
    using ServiceReference2;
    using System;

    public static class GeoLocationExtensions
    {
        public static string GetAddressString(this GeoLocation geoLocation)
        {
            if (geoLocation == null)
            {
                throw new ArgumentNullException(nameof(geoLocation));
            }

            return geoLocation.Street + " " + geoLocation.Housenumber + " " + geoLocation.ZIP + " " + geoLocation.City + " " + geoLocation.Country;
        }
    }
}
