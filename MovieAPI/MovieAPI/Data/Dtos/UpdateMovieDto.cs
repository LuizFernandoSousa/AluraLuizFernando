using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.Dtos;

public class UpdateMovieDto
{
 
    [Required(ErrorMessage = "The tittle is required!!")]
    public string Tittle { get; set; }


    [Required(ErrorMessage = " The Genre is required")]
    [StringLength(50, ErrorMessage = "The leagh of the genre cannot exceed 50 ")]
    public string Genre { get; set; }


    [Required]
    [Range(70, 300, ErrorMessage = "The duration must between 70 and 300")]
    public int Duration { get; set; }


    [Required]
    public string Director { get; set; }
}
