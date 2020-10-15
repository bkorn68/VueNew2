namespace VueTOView.Tests
{
    using System.Threading.Tasks;
    using ServiceReference1;
    using VueTOView.Common;

    public static class LoginTest
    {
        public static Ident TestLogin(string loginname, string password, VueTOView.Common.Environment environment)
        {
            Ident ident = null;
            AuthorizerInternalClient client = ClientProvider.ProvideAuthClient(environment);
            Task<ServiceReference1.ResultOfIdentvcrQC78O> task = client.LoginAsync(loginname, password);
            ResultOfIdentvcrQC78O result = task.Result;
            if ((result != null) && string.IsNullOrEmpty(result.Error) && (result.Data != null))
            {
                ident = result.Data as Ident;
            }

            return ident;
        }
    }
}
