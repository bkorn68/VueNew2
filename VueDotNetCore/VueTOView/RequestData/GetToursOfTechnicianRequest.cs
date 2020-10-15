namespace VueTOView.RequestData
{
    using ServiceReference2;
    using System;

    public class GetToursOfTechnicianRequest
    {
        public Ident Ident { get; set; }

        public int MandatorId { get; set; }

        public ID TechnicianID { get; set; }

        public DateTime Date { get; set; }

        public VueTOView.Common.Environment Environment { get; set; }
    }
}
