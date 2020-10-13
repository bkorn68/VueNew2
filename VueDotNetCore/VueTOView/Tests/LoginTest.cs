using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTOView.Common;

namespace VueTOView.Tests
{
    public static class LoginTest
    {
        public static Ident TestLogin(string loginname, string password)
        {
            Ident ident = null;
            AuthorizerInternalClient client = ClientProvider.ProvideAuthClient(VueTOView.Common.Environment.Live);
            Task<ServiceReference1.ResultOfIdentvcrQC78O> task = client.LoginAsync(loginname, password);
            ResultOfIdentvcrQC78O result = task.Result;
            if ((string.IsNullOrEmpty(result.Error)) && (result.Data != null))
            {
                ident = result.Data as Ident;
            }
            return ident;

        }

    }
}
