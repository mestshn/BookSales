using BookSalesWebServices.DataAccess;
using BookSalesWebServices.DataAccess.EntityModel;
using BookSalesWebServices.Helper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace BookSalesWebServices.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly BookSalesDbContext _context;


        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, BookSalesDbContext context)
            : base(options, logger, encoder, clock)
        {
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header was not found");
            }


            try
            {
                AuthenticationHeaderValue value = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                byte[] bytes = Convert.FromBase64String(value.Parameter);

                string[] valueString = Encoding.UTF8.GetString(bytes).Split(':');
                string kullaniciAdi = valueString[0];

                string sifre = CryptographyManager.MD5Encryp(valueString[1]);

                KullaniciEntityModel kullanici = _context.KullaniciDbSet.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre);

                if (kullanici == null)
                {
                    return AuthenticateResult.Fail("Kullanıcı Adı veya Şifre Hatalı");
                }

                Claim[] claims = new[] { new Claim(ClaimTypes.Name, kullaniciAdi) };
                ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Error an occurred");
            }

        }






    }
}
