using BookSalesWebServices.APIModel;
using BookSalesWebServices.DataAccess.EntityModel;

namespace BookSalesWebServices.Presenter
{
    public static class SiparisDetayPresenter
    {
        public static SiparisDetayAPIModel EntityModelToAPIModel(SiparisDetayEntityModel entityModel)
        {
            SiparisDetayAPIModel apiModel = new SiparisDetayAPIModel();
            apiModel.SiparisDetayID = entityModel.SiparisDetayID;
            apiModel.Miktar = entityModel.Miktar;
            apiModel.BirimFiyat = entityModel.BirimFiyat;
            apiModel.ToplamFiyat = entityModel.ToplamFiyat;
            apiModel.Urun = UrunPresenter.EntityModelToAPIModel(entityModel.Urun);
            return apiModel;
        }
        public static SiparisDetayEntityModel APIModelToEntityModel(SiparisDetayAPIModel apiModel)
        {
            SiparisDetayEntityModel entityModel = new SiparisDetayEntityModel();
            entityModel.SiparisDetayID = apiModel.SiparisDetayID;
            entityModel.Miktar = apiModel.Miktar;
            entityModel.BirimFiyat = apiModel.BirimFiyat;
            entityModel.ToplamFiyat = apiModel.ToplamFiyat;
            entityModel.Urun = UrunPresenter.APIModelToEntityModel(apiModel.Urun);
            return entityModel;
        }
    }
}
