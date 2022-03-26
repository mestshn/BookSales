namespace BookSalesWebServices.APIModel
{
    public class StokAPIModel : APIModelBase
    {
        public StokAPIModel()
            : base()
        {
            Urun = new UrunAPIModel();
        }

        public int StokID { get; set; }

        public int Miktar { get; set; }

        public UrunAPIModel Urun { get; set; }

    }
}
