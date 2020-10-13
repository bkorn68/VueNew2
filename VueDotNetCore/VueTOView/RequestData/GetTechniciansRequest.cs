using ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.RequestData
{
    public class GetTechniciansRequest
    {
        public Ident ident { get; set; }
        public int mandatorId { get; set; }


        public VueTOView.Common.Environment environment { get; set; }

    }
}
