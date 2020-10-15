namespace VueTOView.Tests
{
    using ServiceReference2;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using VueTOView.Common;

    public static class GetTechniciansTest
    {
        public static List<Technician> TestGetTourTechnicians(Ident ident, int mandatorId, VueTOView.Common.Environment environment)
        {
            List<Technician> tourtechnicians = new List<Technician>();
            WebToolExtendedServiceClient client = ClientProvider.ProvideTOClient(environment);
            Task<ServiceReference2.ResultListOfTechnicianuukIAVwv> task = client.GetTechniciansAsync(ident, mandatorId, null);
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
