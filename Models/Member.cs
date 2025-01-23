using System.ComponentModel.DataAnnotations;

namespace MemberModule.Models
{
    public class Member
    {
        //Every fraterity member will need:
        //First Name
        //Last Name
        //Email
        //Phone Number
        [Key]
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }


        [Required]
        public bool Active { get; set; }


    }
}
