using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebServices.DataAccess.EntityModel
{

    [Table(name: "SiparisDetay")]
    public class SiparisDetayEntityModel : EntityModelBase
    {
        [Key]
        public int SiparisDetayID { get; set; }

        public int? Miktar { get; set; }

        public double? BirimFiyat { get; set; }

        public double? ToplamFiyat { get; set; }

        public int UrunID { get; set; }

        public virtual UrunEntityModel Urun { get; set; }

    }
}
