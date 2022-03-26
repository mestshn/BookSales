namespace BookSalesWebServices.APIModel
{
    public class SiparisDetayAPIModel : APIModelBase
    {
        public SiparisDetayAPIModel()
            : base()
        {

        }
        public int SiparisDetayID { get; set; }

        public int? Miktar { get; set; }

        public double? BirimFiyat { get; set; }

        public double? ToplamFiyat { get; set; }

        public UrunAPIModel Urun { get; set; }
    }
}
