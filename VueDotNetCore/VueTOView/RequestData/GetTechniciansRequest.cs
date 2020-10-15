namespace VueTOView.RequestData
{
    using ServiceReference2;

    public class GetTechniciansRequest
    {
        public Ident Ident { get; set; }

        public int MandatorId { get; set; }

        public VueTOView.Common.Environment Environment { get; set; }
    }
}
