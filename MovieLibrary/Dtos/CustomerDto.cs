using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        // [Min18yearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}