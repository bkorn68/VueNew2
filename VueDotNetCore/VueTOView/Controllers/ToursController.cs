using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference2;
using VueTOView.Common;
using VueTOView.Converters;
using VueTOView.RequestData;
using VueTOView.ResponseData;

namespace VueTOView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        [HttpPost]
        public static IEnumerable<GetToursOfTechnicianResponseData> GetToursOfTechnician([FromBody]GetToursOfTechnicianRequest getToursOfTechnicianRequest)
        {
            List<GetToursOfTechnicianResponseData> result = null;
            List<TechnicianRequirement> list = null;
            list = GetToursOfTechnicianFromService(getToursOfTechnicianRequest);
            result = list.Select(e => TechnicianRequirementToGetToursOfTechnicianResponseDataConverter.Convert(e)).ToList();


            return result;
        }

        public static List<TechnicianRequirement> GetToursOfTechnicianFromService(GetToursOfTechnicianRequest getToursOfTechnicianRequest)
        {
            if (getToursOfTechnicianRequest == null) throw new ArgumentNullException(nameof(getToursOfTechnicianRequest));

            List<TechnicianRequirement> list = new List<TechnicianRequirement>();
            List<TechnicianRequirement> tours = new List<TechnicianRequirement>();
            WebToolExtendedServiceClient client = ClientProvider.ProvideTOClient(getToursOfTechnicianRequest.environment);
            Task<ServiceReference2.ResultListOfAppointmentuukIAVwv> task = client.GetTourOfTechnicianAsync(getToursOfTechnicianRequest.ident, getToursOfTechnicianRequest.mandatorId, getToursOfTechnicianRequest.technicianID, getToursOfTechnicianRequest.date, null);
            ResultListOfAppointmentuukIAVwv result = task.Result;
            if ((result != null) && (string.IsNullOrEmpty(result.Error)) && (result.DataList != null) && (result.DataList.Length > 0))
            {
                List<Appointment> appointments = result.DataList.Where(x => x.State != ActivationState.Deleted).ToList();
                foreach (Appointment appointment in appointments)
                {
                    List<TechnicianRequirement> appointmenttours = appointment.TechnicianRequirements.Where(y => y.TechnicianID.SourceId == getToursOfTechnicianRequest.technicianID.SourceId && y.State != ActivationState.Deleted).ToList();
                    foreach (TechnicianRequirement tour in appointmenttours)
                    {
                        tour.Appointment = appointment;
                        tour.Appointment.GeoLocation = GetGeoLocation(client, getToursOfTechnicianRequest.ident, getToursOfTechnicianRequest.mandatorId, tour.Appointment.GeoLocationID);
                        if (tour.Appointment.GeoLocation != null)
                        {
                            tours.Add(tour);
                        }
                    }

                }
                list = tours.OrderBy(x => x.RealStart).ToList();


            }

            return list;

        }
        public static GeoLocation GetGeoLocation(WebToolExtendedServiceClient client, Ident ident, int mandatorId, ID GeoLocationID)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            GeoLocation geoLocation = null;
            Task<ServiceReference2.ResultOfGeoLocationuukIAVwv> task = client.GetGeoLocationAsync(ident, mandatorId, GeoLocationID, null);
            ResultOfGeoLocationuukIAVwv result = task.Result;
            if ((result != null) && (string.IsNullOrEmpty(result.Error)) && (result.Data != null))
            {
                geoLocation = result.Data;
            }

            return geoLocation;
        }



    }
}