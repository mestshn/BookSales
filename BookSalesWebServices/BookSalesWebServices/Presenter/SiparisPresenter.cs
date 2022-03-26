using BookSalesWebServices.APIModel;
using BookSalesWebServices.DataAccess.EntityModel;

namespace BookSalesWebServices.Presenter
{
    public static class SiparisPresenter
    {
        public static SiparisAPIModel EntityModelToAPIModel(SiparisEntityModel entityModel)
        {
            SiparisAPIModel apiModel = new SiparisAPIModel();
            apiModel.SiparisID = entityModel.SiparisID;
            apiModel.SiparisNo = entityModel.SiparisNo;
            apiModel.SiparisTarihi = entityModel.SiparisTarihi;
            apiModel.SiparisDurumu = entityModel.SiparisDurumu;
            apiModel.OdemeTarihi = entityModel.OdemeTarihi;
            apiModel.KDVOrani = entityModel.KDVOrani;
            apiModel.KDVFiyat = entityModel.KDVFiyat;
            apiModel.ToplamTutar = entityModel.ToplamTutar;

            apiModel.Kullanici = KullaniciPresenter.EntityModelToAPIModel(entityModel.Kullanici);

            foreach (var detayEntityModel in entityModel.SiparisDetayList)
            {
                apiModel.SiparisDetayList.Add(SiparisDetayPresenter.EntityModelToAPIModel(detayEntityModel));
            }

            return apiModel;
        }
        public static SiparisEntityModel APIModelToEntityModel(SiparisAPIModel apiModel)
        {
            SiparisEntityModel entityModel = new SiparisEntityModel();
            entityModel.SiparisID = apiModel.SiparisID;
            entityModel.SiparisNo = apiModel.SiparisNo;
            entityModel.SiparisTarihi = apiModel.SiparisTarihi;
            entityModel.SiparisDurumu = apiModel.SiparisDurumu;
            entityModel.OdemeTarihi = apiModel.OdemeTarihi;
            entityModel.KDVOrani = apiModel.KDVOrani;
            entityModel.KDVFiyat = apiModel.KDVFiyat;
            entityModel.ToplamTutar = apiModel.ToplamTutar;

            entityModel.Kullanici = KullaniciPresenter.APIModelToEntityModel(apiModel.Kullanici);

            foreach (var detayAPIModel in apiModel.SiparisDetayList)
            {
                entityModel.SiparisDetayList.Add(SiparisDetayPresenter.APIModelToEntityModel(detayAPIModel));
            }

            return entityModel;
        }


    }
}
