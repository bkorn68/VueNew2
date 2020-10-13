using ServiceReference1;
using ServiceReference2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueTOView.Common
{
    public static class ClientProvider
    {
        public static AuthorizerInternalClient ProvideAuthClient(Environment environment)
        {
            string endpointAddress = string.Empty;
            endpointAddress = UrlProvider.ProvideForAuth(environment);
            AuthorizerInternalClient client = new AuthorizerInternalClient(endpointAddress);
            return client;
        }
        public static WebToolExtendedServiceClient ProvideTOClient(Environment environment)
        {
            string endpointAddress = string.Empty;
            endpointAddress = UrlProvider.ProvideForTO(environment);
            WebToolExtendedServiceClient client = new WebToolExtendedServiceClient(endpointAddress);
            return client;
        }
    }
}
