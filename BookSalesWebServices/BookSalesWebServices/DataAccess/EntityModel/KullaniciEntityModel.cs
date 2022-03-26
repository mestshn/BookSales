using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebServices.DataAccess.EntityModel
{

    [Table(name: "Kullanici")]
    public class KullaniciEntityModel : EntityModelBase
    {
        [Key]
        public int KullaniciID { get; set; }

        public string KullaniciAdi { get; set; }

        public string Sifre { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Adres { get; set; }

        public string CepTelefonu { get; set; }

        public string EPosta { get; set; }
    }

}
