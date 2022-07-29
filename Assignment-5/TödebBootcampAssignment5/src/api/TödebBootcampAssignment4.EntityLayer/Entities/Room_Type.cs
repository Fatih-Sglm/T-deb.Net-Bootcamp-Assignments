using System.Collections.Generic;
using TödebBootcampAssignment4.EntityLayer.Entities.Common;

namespace TödebBootcampAssignment4.EntityLayer.Entities
{
    public class Room_Type : BaseEntity
    {
        //Oda tipi
        public string Typename { get; set; }

        //Oda tipinin oda ile 1-n ilişkisi..
        public ICollection<Room> Rooms { get; set; }
    }
}
