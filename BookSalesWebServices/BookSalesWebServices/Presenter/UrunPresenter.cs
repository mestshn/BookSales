using BookSalesWebServices.APIModel;
using BookSalesWebServices.DataAccess.EntityModel;

namespace BookSalesWebServices.Presenter
{
    public static class UrunPresenter
    {
        public static UrunAPIModel EntityModelToAPIModel(UrunEntityModel entityModel)
        {
            UrunAPIModel apiModel = new UrunAPIModel();
            apiModel.UrunID = entityModel.UrunID;
            apiModel.UrunAdi = entityModel.UrunAdi;
            apiModel.Aciklama = entityModel.Aciklama;
            apiModel.ImageURL = entityModel.ImageURL;
            apiModel.Fiyat = entityModel.Fiyat;
            return apiModel;
        }
        public static UrunEntityModel APIModelToEntityModel(UrunAPIModel apiModel)
        {
            UrunEntityModel entityModel = new UrunEntityModel();
            entityModel.UrunID = apiModel.UrunID;
            entityModel.UrunAdi = apiModel.UrunAdi;
            entityModel.Aciklama = apiModel.Aciklama;
            entityModel.ImageURL = apiModel.ImageURL;
            entityModel.Fiyat = apiModel.Fiyat;
            return entityModel;
        }



    }
}
