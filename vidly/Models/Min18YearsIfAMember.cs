using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Min18YearsIfAMember :ValidationAttribute
    {
        protected override System.ComponentModel.DataAnnotations.ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeID==MembershipType.unknown || customer.MembershipTypeID==MembershipType.PayAsYouGo)
            {

                return ValidationResult.Success;

            }
            if (customer.Birthdate == null)
                return new ValidationResult("BirthDate is required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer Should be 18 years to go on a membership");
        }
    }
}