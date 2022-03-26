using BookSalesWebServices.APIModel;
using BookSalesWebServices.Business;
using BookSalesWebServices.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSalesWebServices.Controllers
{
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly BookSalesDbContext _context;

        public KullaniciController(BookSalesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        [Route("Login")]
        public KullaniciAPIModel Login()
        {
            string kullaniciAdi = HttpContext.User.Identity.Name;
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            KullaniciAPIModel ret = kullaniciBusiness.GetKullanici(kullaniciAdi);
            return ret;
        }

        [HttpGet]
        [Route("CheckUserName")]
        public GenericResult CheckUserName(string kullaniciAdi)
        {
            KullaniciBusiness kullaniciBusiness = new KullaniciBusiness(_context);
            KullaniciAPIModel ret = kullaniciBusiness.GetKullanici(kullaniciAdi);

            return ret.genericResult;
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
            kullaniciAPIModel.IdentityName= HttpContext.User.Identity.Name;
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



    }
}
