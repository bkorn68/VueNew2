namespace VueTOView.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceReference2;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;
    using VueTOView.Common;
    using VueTOView.Converters;
    using VueTOView.RequestData;
    using VueTOView.ResponseData;

    [Route("api/[controller]")]
    [ApiController]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1204:StaticElementsMustAppearBeforeInstanceElements", Justification = "Reviewed.")]
    /// <summary>
    /// The controller to get Tours
    /// </summary>
    public class ToursController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<GetToursOfTechnicianResponseData> GetToursOfTechnician([FromBody]GetToursOfTechnicianRequest getToursOfTechnicianRequest)
        {
            List<GetToursOfTechnicianResponseData> result = null;
            List<TechnicianRequirement> list = null;
            list = GetToursOfTechnicianFromService(getToursOfTechnicianRequest);
            result = list.Select(e => TechnicianRequirementToGetToursOfTechnicianResponseDataConverter.Convert(e)).ToList();

            return result;
        }

        public static List<TechnicianRequirement> GetToursOfTechnicianFromService(GetToursOfTechnicianRequest getToursOfTechnicianRequest)
        {
            if (getToursOfTechnicianRequest == null)
            {
                throw new ArgumentNullException(nameof(getToursOfTechnicianRequest));
            }

            List<TechnicianRequirement> list = new List<TechnicianRequirement>();
            List<TechnicianRequirement> tours = new List<TechnicianRequirement>();
            WebToolExtendedServiceClient client = ClientProvider.ProvideTOClient(getToursOfTechnicianRequest.Environment);
            Task<ServiceReference2.ResultListOfAppointmentuukIAVwv> task = client.GetTourOfTechnicianAsync(getToursOfTechnicianRequest.Ident, getToursOfTechnicianRequest.MandatorId, getToursOfTechnicianRequest.TechnicianID, getToursOfTechnicianRequest.Date, null);
            ResultListOfAppointmentuukIAVwv result = task.Result;
            if ((result != null) && string.IsNullOrEmpty(result.Error) && (result.DataList != null) && (result.DataList.Length > 0))
            {
                List<Appointment> appointments = result.DataList.Where(x => x.State != ActivationState.Deleted).ToList();
                foreach (Appointment appointment in appointments)
                {
                    List<TechnicianRequirement> appointmenttours = appointment.TechnicianRequirements.Where(y => y.TechnicianID.SourceId == getToursOfTechnicianRequest.TechnicianID.SourceId && y.State != ActivationState.Deleted).ToList();
                    foreach (TechnicianRequirement tour in appointmenttours)
                    {
                        tour.Appointment = appointment;
                        tour.Appointment.GeoLocation = GetGeoLocation(client, getToursOfTechnicianRequest.Ident, getToursOfTechnicianRequest.MandatorId, tour.Appointment.GeoLocationID);
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

        public static GeoLocation GetGeoLocation(WebToolExtendedServiceClient client, Ident ident, int mandatorId, ID geoLocationID)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            GeoLocation geoLocation = null;
            Task<ServiceReference2.ResultOfGeoLocationuukIAVwv> task = client.GetGeoLocationAsync(ident, mandatorId, geoLocationID, null);
            ResultOfGeoLocationuukIAVwv result = task.Result;
            if ((result != null) && string.IsNullOrEmpty(result.Error) && (result.Data != null))
            {
                geoLocation = result.Data;
            }

            return geoLocation;
        }
    }
}