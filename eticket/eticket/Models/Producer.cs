using eticket.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eticket.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be in between 3 and 50")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be in between 3 and 50")]
        public string Bio { get; set; }

        // Relationships
        public List<Movie>? Movies { get; set; }
    }
}
