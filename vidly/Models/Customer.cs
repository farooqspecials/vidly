using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="Please Enter Customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
              
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
       
        
        [Display(Name="MembershipType")]
        public byte MembershipTypeID { get; set; }
        
    }
}