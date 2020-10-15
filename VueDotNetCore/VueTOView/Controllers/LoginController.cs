namespace VueTOView.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceReference1;
    using System;
    using System.Threading.Tasks;
    using VueTOView.Common;
    using VueTOView.RequestData;

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]

        public IActionResult Login([FromBody]LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                throw new ArgumentNullException(nameof(loginRequest));
            }

            IActionResult response = this.Unauthorized();
            Ident ident = LoginFromService(loginRequest);
            if (ident != null)
            {
                // response = Ok(new { token = ident.Token });
                response = this.Ok(ident);
            }

            return response;
        }

        private static Ident LoginFromService(LoginRequest loginRequest)
        {
            Ident ident = null;
            AuthorizerInternalClient client = ClientProvider.ProvideAuthClient(loginRequest.Environment);
            Task<ServiceReference1.ResultOfIdentvcrQC78O> task = client.LoginAsync(loginRequest.Loginname, loginRequest.Password);
            ResultOfIdentvcrQC78O result = task.Result;
            if ((result != null) && string.IsNullOrEmpty(result.Error) && (result.Data != null))
            {
                ident = result.Data as Ident;
            }

            return ident;
        }
    }
}