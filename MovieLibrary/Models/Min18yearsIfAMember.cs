using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.Models
{
    public class Min18yearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("BirthDate is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18 years old to go on a membership");
        }
    }
}