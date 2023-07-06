using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace SecurityStepForREST.Security
{
    public class BasicAuthHandler : AuthenticationHandler<BasicAuthOption>
    {
        public BasicAuthHandler(IOptionsMonitor<BasicAuthOption> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. Gelen header'da Authorization var mı?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //2. header value, formata uyuyor mu?
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }
            //3. Şema Basic mi?
            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            var headerEncodedValueBytes = Convert.FromBase64String(headerValue.Parameter);
            var decodedValue = Encoding.UTF8.GetString(headerEncodedValueBytes);
            var username = decodedValue.Split(':')[0];
            var pass = decodedValue.Split(':')[1];

            if (username == "turkay" && pass == "123")
            {
                Claim[] claims =
                {
                    new Claim(ClaimTypes.Name,"turkay")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                AuthenticationTicket authenticationTicket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(authenticationTicket));


            }

            return Task.FromResult(AuthenticateResult.Fail("Kullanıcı ya da şifre hebele"));

        }
    }
}
