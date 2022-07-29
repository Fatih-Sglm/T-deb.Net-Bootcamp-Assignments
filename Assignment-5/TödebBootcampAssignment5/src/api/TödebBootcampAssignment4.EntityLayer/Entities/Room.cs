using System;
using System.Collections.Generic;
using TödebBootcampAssignment4.EntityLayer.Entities.Common;

namespace TödebBootcampAssignment4.EntityLayer.Entities
{
    public class Room : BaseEntity
    {
        //Odanın adı Example : Dağ manzaralı Suit
        public string Room_name { get; set; }

        //Odanın açıklaması.Sahip olduğu özellikler. Example: Klima,24 saat sıcak su, 35 mbps internet vs..
        public string Description { get; set; }

        //Odanın Günlük Ücreti
        public float DayPrice { get; set; }

        // Oda tipi objesinden Foreign key
        public Room_Type RoomType { get; set; }

        //Bağlı olduğu otel için Hotel Objesi
        public Hotel Hotel { get; set; }

        //Bağlı Olduğu otel için oluşan foreign keyi  kontrol etmek için gereken property
        public Guid HotelId { get; set; }

        //Bağlı Olduğu Oda tipi için oluşan foreign keyi  kontrol etmek için gereken property
        public Guid RoomTypeId { get; set; }

        //Oda için  yapılan yorumlar
        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rezervation> Rezervations { get; set; }


    }
}
