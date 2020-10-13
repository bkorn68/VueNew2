using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using VueTOView.Common;
using VueTOView.RequestData;

namespace VueTOView.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]

        public IActionResult Login([FromBody]LoginRequest loginRequest)
        {
            IActionResult response = Unauthorized();
            Ident ident = LoginFromService(loginRequest);
            if (ident != null)
            {
                //response = Ok(new { token = ident.Token });
                response = Ok(ident);
            }



            return response;
        }
        private Ident LoginFromService(LoginRequest loginRequest)
        {
            Ident ident = null;
            AuthorizerInternalClient client = ClientProvider.ProvideAuthClient(loginRequest.environment);
            Task<ServiceReference1.ResultOfIdentvcrQC78O> task = client.LoginAsync(loginRequest.loginname, loginRequest.password);
            ResultOfIdentvcrQC78O result = task.Result;
            if ((result != null) && (string.IsNullOrEmpty(result.Error)) && (result.Data != null))
            {
                ident = result.Data as Ident;
            }
            return ident;
        }

    }
}