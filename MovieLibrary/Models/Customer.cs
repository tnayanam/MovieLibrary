using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models
{
    public class Customer
    {
        public Customer()
        {
            Id = 0;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        [Min18yearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}