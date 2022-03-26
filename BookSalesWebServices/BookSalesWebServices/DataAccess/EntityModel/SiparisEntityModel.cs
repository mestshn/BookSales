using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebServices.DataAccess.EntityModel
{
    [Table(name: "Siparis")]
    public class SiparisEntityModel : EntityModelBase
    {

        public SiparisEntityModel()
        {
            SiparisDetayList = new HashSet<SiparisDetayEntityModel>();
        }

        [Key]
        public int SiparisID { get; set; }

        public string SiparisNo { get; set; }

        public DateTime? SiparisTarihi { get; set; }

        public int SiparisDurumu { get; set; }

        public DateTime OdemeTarihi { get; set; }

        public double KDVOrani { get; set; }

        public double KDVFiyat { get; set; }

        public double ToplamTutar { get; set; }

        public int KullaniciID { get; set; }

        public virtual KullaniciEntityModel Kullanici { get; set; }

        public virtual ICollection<SiparisDetayEntityModel> SiparisDetayList { get; set; }
    }
}
