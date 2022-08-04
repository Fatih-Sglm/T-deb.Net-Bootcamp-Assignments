using System;
using TödebBootcampAssignment4.EntityLayer.Entities.Common;

namespace TödebBootcampAssignment4.EntityLayer.Entities
{
    public class Rezervation : BaseEntity
    {
        //Rezervasyon başlangıç tarihi
        public DateTime StartingDate { get; set; }

        //Rezervasyon bitiş tarihi
        public DateTime EndingDate { get; set; }

        //Rezervastonu yapan kullanıcı 
        public Customer Customer { get; set; }

        public Guid CustomerId { get; set; }


        //Rezervasyon yapılan oda
        public Room Room { get; set; }
        public Guid RoomId { get; set; }

        //Toplam Kiralanan Gün sayısı


        private float Totaldays;
        public float TotalDays
        {
            get { return Totaldays; }
            set { Totaldays = (float)(EndingDate - StartingDate).TotalDays; }
        }


        //Odanın toplam rezervasyon ücreti
        private float Totalprice;
        public float TotalPrice
        {
            get { return Totalprice; }
            set { Totalprice = (float)((EndingDate - StartingDate).TotalDays * Room.DayPrice); }
        }
    }
}
