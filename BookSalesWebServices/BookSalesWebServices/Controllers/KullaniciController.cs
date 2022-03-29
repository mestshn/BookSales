using BookSalesWebServices.APIModel;
using BookSalesWebServices.Business;
using BookSalesWebServices.DataAccess;
using BookSalesWebServices.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookSalesWebServices.Controllers
{
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly BookSalesDbContext _context;
        private readonly ApplicationSettings _appSettings;

        public KullaniciController(BookSalesDbContext context, IOptions<ApplicationSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginApiModel model)
        {
            string kullaniciAdi = HttpContext.User.Identity.Name;
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            KullaniciAPIModel ret = kullaniciBusiness.GetKullanici(model.KullaniciAdi, model.Sifre);

            if (ret.genericResult.IsOK)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",ret.KullaniciID.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });

        }

        [HttpGet]
        [Route("CheckUserName")]
        public GenericResult CheckUserName(string kullaniciAdi)
        {
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            GenericResult ret = kullaniciBusiness.CheckKullanici(kullaniciAdi);
            return ret;
        }

        [HttpPost]
        [Route("Register")]
        public GenericResult Register(KullaniciAPIModel kullaniciAPIModel)
        {
            GenericResult ret = new GenericResult();

            if (
                kullaniciAPIModel == null ||
                kullaniciAPIModel.KullaniciAdi == null ||
               kullaniciAPIModel.Sifre == null ||
                kullaniciAPIModel.Ad == null ||
                kullaniciAPIModel.Soyad == null ||
                kullaniciAPIModel.CepTelefonu == null
                )
            {
                return new GenericResult { IsOK = false, Message = "Zorunlu alanlar boş olamaz" };
            }

            kullaniciAPIModel.UpdateModel = false;
            kullaniciAPIModel.IdentityName = HttpContext.User.Identity.Name;
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            ret = kullaniciBusiness.Save(kullaniciAPIModel);

            return ret;
        }

        [HttpPost]
        [Authorize]
        [Route("SetKullanici")]
        public GenericResult SetKullanici(KullaniciAPIModel kullaniciAPIModel)
        {
            GenericResult ret = new GenericResult();

            if (
                kullaniciAPIModel == null ||
                kullaniciAPIModel.KullaniciAdi == null ||
               kullaniciAPIModel.Sifre == null ||
                kullaniciAPIModel.Ad == null ||
                kullaniciAPIModel.Soyad == null ||
                kullaniciAPIModel.CepTelefonu == null
                )
            {
                return new GenericResult { IsOK = false, Message = "Zorunlu alanlar boş olamaz" };
            }

            kullaniciAPIModel.UpdateModel = true;
            kullaniciAPIModel.IdentityName = HttpContext.User.Identity.Name;
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            ret = kullaniciBusiness.Save(kullaniciAPIModel);

            return ret;
        }

        [HttpPost]
        [Authorize]
        [Route("UpadateKullanici")]
        public GenericResult UpadateKullanici(KullaniciAPIModel kullaniciAPIModel)
        {
            GenericResult ret = new GenericResult();

            if (
                kullaniciAPIModel == null ||
                kullaniciAPIModel.KullaniciAdi == null ||
               kullaniciAPIModel.Sifre == null ||
                kullaniciAPIModel.Ad == null ||
                kullaniciAPIModel.Soyad == null ||
                kullaniciAPIModel.CepTelefonu == null
                )
            {
                return new GenericResult { IsOK = false, Message = "Zorunlu alanlar boş olamaz" };
            }

            kullaniciAPIModel.UpdateModel = true;
            kullaniciAPIModel.IdentityName = HttpContext.User.Identity.Name;
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            ret = kullaniciBusiness.Save(kullaniciAPIModel);

            return ret;
        }

        [HttpGet]
        [Authorize]
        [Route("GetProfil")]
        public KullaniciAPIModel GetProfil()
        {
            string kullaniciID = User.Claims.First(c => c.Type == "UserID").Value;
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            KullaniciAPIModel ret = kullaniciBusiness.GetKullanici(Convert.ToInt32(kullaniciID));
            return ret;
        }

    }
}
