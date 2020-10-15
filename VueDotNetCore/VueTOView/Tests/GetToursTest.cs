using ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTOView.Common;
using VueTOView.ResponseData;

namespace VueTOView.Tests
{
    public static class GetToursTest
    {
        public static List<TechnicianRequirement> TestGetTourOfTechnician(Ident ident, int mandatorId, ID technicianID, DateTime date,   VueTOView.Common.Environment environment)
        {
            List<TechnicianRequirement> list = new List<TechnicianRequirement>();
            List<TechnicianRequirement> tours = new List<TechnicianRequirement>();
            WebToolExtendedServiceClient client = ClientProvider.ProvideTOClient(environment);
            Task<ServiceReference2.ResultListOfAppointmentuukIAVwv> task = client.GetTourOfTechnicianAsync(ident, mandatorId, technicianID, date, null);
            ResultListOfAppointmentuukIAVwv result = task.Result;
            if ((result != null) && (string.IsNullOrEmpty(result.Error)) && (result.DataList != null) && (result.DataList.Length > 0))
            {
                List<Appointment> appointments = result.DataList.Where(x => x.State != ActivationState.Deleted).ToList();
                foreach(Appointment appointment in appointments)
                {
                    List<TechnicianRequirement> appointmenttours = appointment.TechnicianRequirements.Where(y => y.TechnicianID.SourceId == technicianID.SourceId && y.State != ActivationState.Deleted).ToList();
                    foreach (TechnicianRequirement tour in appointmenttours)
                    {
                        tour.Appointment = appointment;
                        tour.Appointment.GeoLocation = TestGetGeoLocation(client, ident, mandatorId, tour.Appointment.GeoLocationID);
                        if(tour.Appointment.GeoLocation != null)
                        {
                            tours.Add(tour);
                        }
                    }
                    
                }
                list = tours.OrderBy(x => x.RealStart).ToList();

                
            }

            return list;

        }
        public static GeoLocation TestGetGeoLocation(WebToolExtendedServiceClient client, Ident ident, int mandatorId, ID GeoLocationID)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            GeoLocation geoLocation = null;
            Task<ServiceReference2.ResultOfGeoLocationuukIAVwv> task = client.GetGeoLocationAsync(ident, mandatorId, GeoLocationID, null);
            ResultOfGeoLocationuukIAVwv result = task.Result;
            if((result != null) && (string.IsNullOrEmpty(result.Error)) && (result.Data != null))
            {
                geoLocation = result.Data;
            }

            return geoLocation;
        }
    }
}
