using System;
using System.Collections.Generic;
using TödebBootcampAssignment4.EntityLayer.Entities.Common;

namespace TödebBootcampAssignment4.EntityLayer.Entities
{
    public class Hotel : BaseEntity
    {
        //Otel Adı.
        public string HotelsName { get; set; }

        //Otel Açıklaması.
        public string Description { get; set; }

        //Otelin Category objesi için Foreign Key.
        public Category Category { get; set; }

        //Entity Framwork ün oluşturduğu Foreign keyi kullanmak için gereken property.
        public Guid CategoryId { get; set; }

        //Bir otelin bir çok odası olmasını sağlayan collection.
        public ICollection<Room> Rooms { get; set; }

    }
}
