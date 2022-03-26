namespace BookSalesWebServices.APIModel
{
    public class APIModelBase
    {
        public APIModelBase()
        {
            genericResult = new GenericResult();
        }
        public bool UpdateModel { get; set; }
        public string IdentityName { get; set; }
        public GenericResult genericResult { get; set; }
    }
}
