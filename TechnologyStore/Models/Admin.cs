using System.ComponentModel.DataAnnotations;

namespace TechnologyStore.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Username Not Empty")]
        [StringLength(20, ErrorMessage = "Please only enter 3-20 length characters", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Not Empty")]
        [StringLength(20, ErrorMessage = "Please only enter 3-20 length characters", MinimumLength = 3)]
        public string Password { get; set; }

    }
}
