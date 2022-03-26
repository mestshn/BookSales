using BookSalesWebServices.APIModel;
using BookSalesWebServices.DataAccess.EntityModel;

namespace BookSalesWebServices.Presenter
{
    public static class StokPresenter
    {
        public static StokAPIModel EntityModelToAPIModel(StokEntityModel entityModel)
        {
            StokAPIModel apiModel = new StokAPIModel();
            apiModel.StokID = entityModel.StokID;
            apiModel.Miktar = entityModel.Miktar;
            apiModel.Urun = UrunPresenter.EntityModelToAPIModel(entityModel.Urun);
            return apiModel;
        }
        public static StokEntityModel APIModelToEntityModel(StokAPIModel apiModel)
        {
            StokEntityModel entityModel = new StokEntityModel();
            entityModel.StokID = apiModel.StokID;
            entityModel.Miktar = apiModel.Miktar;
            entityModel.Urun = UrunPresenter.APIModelToEntityModel(apiModel.Urun);
            return entityModel;
        }
    }
}
