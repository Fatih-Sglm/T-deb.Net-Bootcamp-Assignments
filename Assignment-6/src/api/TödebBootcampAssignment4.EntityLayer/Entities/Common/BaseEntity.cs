using System;

namespace TödebBootcampAssignment4.EntityLayer.Entities.Common
{
    //Her Tablo için olan ortak property ler
    public abstract class BaseEntity
    {

        //Primery key
        public Guid Id { get; set; }

        // Oluştrulma Tarihi
        public DateTime CreatedDate { get; set; }

        //Eğer Güncelllenmişse son Güncellenme Tarihi
        public DateTime? UpdateAt { get; set; }

        //Sistemdeki  durumu
        public bool Status { get; set; }
    }
}
