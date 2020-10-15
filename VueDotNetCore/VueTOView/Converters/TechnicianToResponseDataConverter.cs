namespace VueTOView.Converters
{
    using ServiceReference2;
    using System;
    using VueTOView.ResponseData;

    public static class TechnicianToResponseDataConverter
    {
        public static GetTechniciansResponseData Convert(Technician source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            GetTechniciansResponseData target = new GetTechniciansResponseData()
            {
                Name = source.Name,
                SourceId = source.ID.SourceId,
            };
            return target;
        }
    }
}
