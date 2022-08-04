using System.Collections.Generic;
using TödebBootcampAssignment4.EntityLayer.Entities.Common;

namespace TödebBootcampAssignment4.EntityLayer.Entities
{
    public class Category : BaseEntity
    {
        //Otel Kategorisi pansiyon,Motel, Lüks vs...
        public string CategoryName { get; set; }
        //Bir Category birçok otel için geçerli olabilir.
        public ICollection<Hotel> Hotels { get; set; }
    }
}
