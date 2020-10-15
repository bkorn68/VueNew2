namespace VueTOView.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceReference2;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using VueTOView.Common;
    using VueTOView.Converters;
    using VueTOView.RequestData;
    using VueTOView.ResponseData;

    [Route("api/[controller]")]
    [ApiController]
    public class TechniciansController : ControllerBase
    {
        [HttpPost]
        public IEnumerable<GetTechniciansResponseData> GetTechnicians([FromBody]GetTechniciansRequest getTechniciansRequest)
        {
            if (getTechniciansRequest == null)
            {
                throw new ArgumentNullException(nameof(getTechniciansRequest));
            }

            List<GetTechniciansResponseData> result = null;
            List<Technician> technicianlist = GetTechniciansFromService(getTechniciansRequest);
            result = technicianlist.Select(e => TechnicianToResponseDataConverter.Convert(e)).ToList();
            return result;
        }

        private static List<Technician> GetTechniciansFromService(GetTechniciansRequest getTechniciansRequest)
        {
            List<Technician> tourtechnicians = new List<Technician>();
            WebToolExtendedServiceClient client = ClientProvider.ProvideTOClient(getTechniciansRequest.Environment);
            Task<ServiceReference2.ResultListOfTechnicianuukIAVwv> task = client.GetTechniciansAsync(getTechniciansRequest.Ident, getTechniciansRequest.MandatorId, null);
            ResultListOfTechnicianuukIAVwv result = task.Result;
            if ((result != null) && string.IsNullOrEmpty(result.Error) && (result.DataList != null) && (result.DataList.Length > 0))
            {
                List<Technician> technicians = result.DataList.ToList();
                foreach (Technician tec in technicians.Where(x => !x.IsSubcontractor).OrderBy(x => x.Name))
                {
                    tourtechnicians.Add(tec);
                }
            }

            return tourtechnicians;
        }
    }
}