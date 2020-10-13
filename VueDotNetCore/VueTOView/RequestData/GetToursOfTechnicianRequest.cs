using ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.RequestData
{
    public class GetToursOfTechnicianRequest
    {
        public Ident ident { get; set; }
        public int mandatorId { get; set; }
        public ID technicianID { get; set; }
        public DateTime date { get; set; }


        public VueTOView.Common.Environment environment { get; set; }

    }
}
