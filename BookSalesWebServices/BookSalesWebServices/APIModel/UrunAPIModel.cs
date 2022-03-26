using static System.Net.Mime.MediaTypeNames;

namespace BookSalesWebServices.APIModel
{
    public class UrunAPIModel : APIModelBase
    {
        public UrunAPIModel() 
            :base()
        {

        }

        public int UrunID { get; set; }

        public string UrunAdi { get; set; }

        public string Aciklama { get; set; }

        public string ImageURL { get; set; }

        public string ImageBaseEncode { get; set; }

        public double? Fiyat { get; set; }
    }
}
