using System;
using System.Collections.Generic;

namespace BookSalesWebServices.APIModel
{
    public class SiparisAPIModel :APIModelBase
    {
        public SiparisAPIModel()
            : base() 
        {
            SiparisDetayList = new List<SiparisDetayAPIModel>();
        }

        public int SiparisID { get; set; }

        public string SiparisNo { get; set; }

        public DateTime? SiparisTarihi { get; set; }

        public int SiparisDurumu { get; set; }

        public DateTime OdemeTarihi { get; set; }

        public double KDVOrani { get; set; }

        public double KDVFiyat { get; set; }

        public double ToplamTutar { get; set; }


        public KullaniciAPIModel Kullanici { get; set; }

        public List<SiparisDetayAPIModel> SiparisDetayList { get; set; }




    }
}
