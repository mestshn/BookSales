using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookSalesWebServices.DataAccess
{
    public class EntityModelBase
    {
        public DateTime? CreateDate { get; set; }

        public int? CreateKullaniciID { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateKullanıcıID { get; set; }

    }
}
