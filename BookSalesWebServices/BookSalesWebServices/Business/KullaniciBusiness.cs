using BookSalesWebServices.APIModel;
using BookSalesWebServices.DataAccess;
using BookSalesWebServices.DataAccess.EntityModel;
using BookSalesWebServices.Presenter;
using System;
using System.Linq;

namespace BookSalesWebServices.Business
{
    public class KullaniciBusiness
    {
        private readonly BookSalesDbContext _context;
        public KullaniciBusiness(BookSalesDbContext context)
        {
            _context = context;
        }

        public KullaniciAPIModel GetKullanici(string kullaniciAdi)
        {
            KullaniciEntityModel entity = _context.KullaniciDbSet.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi);
            KullaniciAPIModel ret = new KullaniciAPIModel();
            if (entity != null)
            {
                ret = KullaniciPresenter.EntityModelToAPIModel(entity);
                ret.genericResult.IsOK = true;
            }
            else
            {
                ret.genericResult.IsOK = false;
                ret.genericResult.Message = "Kullanıcı Bulunamadı.";
            }
            return ret;
        }


        public GenericResult Save(KullaniciAPIModel apiModel)
        {
            KullaniciEntityModel entityModel = KullaniciPresenter.APIModelToEntityModel(apiModel);
            int? LoginUserID = GetLoginUserID(apiModel.IdentityName);

            if (apiModel.UpdateModel)
            {
                entityModel.UpdateKullanıcıID = LoginUserID;
                entityModel.UpdateDate = DateTime.Now;
                _context.Update(entityModel);
            }
            else
            {
                KullaniciEntityModel kullanici = _context.KullaniciDbSet.FirstOrDefault(x => x.KullaniciAdi == entityModel.KullaniciAdi);
                if (kullanici != null) 
                {
                    return new GenericResult { IsOK = false, Message = "Kullanıcı Adı kullanımda" };
                }

                entityModel.KullaniciID = 0;
                entityModel.CreateKullaniciID = LoginUserID;
                entityModel.CreateDate = DateTime.Now;
                _context.Add(entityModel);
            }
            _context.SaveChanges();

            return new GenericResult { IsOK = true };
        }


        public int? GetLoginUserID(string IdentityName)
        {
            int? LoginUserID = null;

            KullaniciEntityModel entity = _context.KullaniciDbSet.FirstOrDefault(x => x.KullaniciAdi == IdentityName);
            if (entity != null)
            {
                LoginUserID = entity.KullaniciID;
            }
            return LoginUserID;
        }


    }
}
