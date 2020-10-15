using ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.Converters
{
    public static class GeoLocationExtensions
    {
        public static string GetAddressString(this GeoLocation geoLocation)
        {
            if (geoLocation == null) throw new ArgumentNullException(nameof(geoLocation));
            return geoLocation.Street + " " + geoLocation.Housenumber + " " + geoLocation.ZIP + " " + geoLocation.City + " " + geoLocation.Country;
        }

    }
}
