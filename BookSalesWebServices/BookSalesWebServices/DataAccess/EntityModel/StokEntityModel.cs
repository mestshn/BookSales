using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebServices.DataAccess.EntityModel
{

    [Table(name: "Stok")]
    public class StokEntityModel : EntityModelBase
    {
        [Key]
        public int StokID { get; set; }

        public int Miktar { get; set; }

        public int UrunID { get; set; }

        public virtual UrunEntityModel Urun { get; set; }

    }
}
