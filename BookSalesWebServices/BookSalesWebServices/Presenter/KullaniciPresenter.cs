using BookSalesWebServices.APIModel;
using BookSalesWebServices.DataAccess.EntityModel;
using BookSalesWebServices.Helper;

namespace BookSalesWebServices.Presenter
{
    public static class KullaniciPresenter
    {

        public static KullaniciAPIModel EntityModelToAPIModel(KullaniciEntityModel entityModel)
        {
            KullaniciAPIModel apiModel = new KullaniciAPIModel();
            apiModel.KullaniciID = entityModel.KullaniciID;
            apiModel.Ad = entityModel.Ad;
            apiModel.Soyad = entityModel.Soyad;
            apiModel.KullaniciAdi = entityModel.KullaniciAdi;
            apiModel.Adres = entityModel.Adres;
            apiModel.CepTelefonu = entityModel.CepTelefonu;
            apiModel.EPosta = entityModel.EPosta;
            return apiModel;
        }
        public static KullaniciEntityModel APIModelToEntityModel(KullaniciAPIModel apiModel)
        {
            KullaniciEntityModel entityModel = new KullaniciEntityModel();
            entityModel.KullaniciID = apiModel.KullaniciID;
            entityModel.Ad = apiModel.Ad;
            entityModel.Soyad = apiModel.Soyad;
            entityModel.KullaniciAdi = apiModel.KullaniciAdi;
            entityModel.Sifre = CryptographyManager.MD5Encryp(apiModel.Sifre);
            entityModel.Adres = apiModel.Adres;
            entityModel.CepTelefonu = apiModel.CepTelefonu;
            entityModel.EPosta = apiModel.EPosta;
            return entityModel;
        }


    }
}
