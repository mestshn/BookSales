using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebServices.DataAccess.EntityModel
{

    [Table(name: "Urun")]
    public class UrunEntityModel : EntityModelBase
    {
        [Key]
        public int UrunID { get; set; }

        public string UrunAdi { get; set; }

        public string Aciklama { get; set; }

        public string ImageURL { get; set; }

        public double? Fiyat { get; set; }
    }
}
