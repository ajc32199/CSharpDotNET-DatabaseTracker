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
        public int Id { get; set; }

        [Required]
        public string? firstName { get; set; }

        [Required]
        public string? lastName { get; set; }

        [Required]
        public string? email { get; set; }


        [Required]
        public bool active { get; set; }

        [Required]
        public int? scroll { get; set; }


    }
}
