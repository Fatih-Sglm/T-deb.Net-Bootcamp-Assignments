using System;
using TödebBootcampAssignment4.EntityLayer.Entities.Common;

namespace TödebBootcampAssignment4.EntityLayer.Entities
{
    public class Comment : BaseEntity
    {
        //yorumun içeriği
        public string Content { get; set; }

        //Otele verilen Puan
        public float Rate { get; set; }

        //Yorumu yapan müşteri için obje
        public Customer Customer { get; set; }

        // Oluşan foreign keyi kontrol etmek için gerekn property
        public Guid CustomerId { get; set; }

        //Yorumun yapıldığı otel için obje
        public Room Room { get; set; }

        // Oluşan foreign keyi kontrol etmek için gerekn property
        public Guid RoomId { get; set; }


    }
}
