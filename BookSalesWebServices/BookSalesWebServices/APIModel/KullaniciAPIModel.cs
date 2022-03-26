namespace BookSalesWebServices.APIModel
{
    public class KullaniciAPIModel : APIModelBase
    {
        public KullaniciAPIModel()
            : base()
        {
        }

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
