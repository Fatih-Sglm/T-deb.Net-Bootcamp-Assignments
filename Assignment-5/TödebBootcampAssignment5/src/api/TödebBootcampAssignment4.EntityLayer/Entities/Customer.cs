using System.Collections.Generic;
using TödebBootcampAssignment4.EntityLayer.Entities.Common;

namespace TödebBootcampAssignment4.EntityLayer.Entities
{
    public class Customer : BaseEntity
    {
        //Müşteri Adı
        public string FirstName { get; set; }

        //Müşteri Soyadı
        public string LastName { get; set; }

        //Müşteri Maili
        public string Mail { get; set; }

        //Müşteri Şifresi
        public string Password { get; set; }

        //Müşteri Telefon Numarası
        public string PhoneNumber { get; set; }

        //Müşterinin Email onaylama bilgisini tutan property
        public bool EmailConfirmed { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
