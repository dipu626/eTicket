using eticket.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eticket.Data.ViewModel
{
    public class NewMovieVM
    {
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string ImageURL { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie category is required")]
        public MovieCategory MovieCategory { get; set; }

        // Relationships (Many-to-Many)
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int>? ActorIds { get; set; }

        // Cinema (One-to-Many)
        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie cinema is required")]
        public int CinemaId { get; set; }

        // Producer (One-to-Many)
        [Display(Name = "Select a producer")]
        [Required(ErrorMessage = "Movie producer is required")]
        public int ProducerId { get; set; }
    }
}
