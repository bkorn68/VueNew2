namespace ServiceReference2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// GeoLocation added for Appointment.
    /// </summary>
    public partial class Appointment
    {
        public GeoLocation GeoLocation { get; set; }
    }
}
