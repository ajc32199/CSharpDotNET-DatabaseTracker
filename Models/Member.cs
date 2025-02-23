﻿using System.ComponentModel.DataAnnotations;

namespace MemberModule.Models
{
    public class Member
    {
        //Every fraterity member will need:
        //First Name
        //Last Name
        //Email
        //Phone Number

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        public bool DuesPaid { get; set; }


        [Required]
        public bool Active { get; set; }


    }
}
