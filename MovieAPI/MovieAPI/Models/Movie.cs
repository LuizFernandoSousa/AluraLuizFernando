using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models;

public class Movie
{

    public int Id { get; set; }


    [Required(ErrorMessage ="The tittle is required!!")]
    public string Tittle { get; set; }


    [Required(ErrorMessage = " The Genre is required")]
    [MaxLength(50,ErrorMessage = "The leagh of the genre cannot exceed 50 ")]
    public string Genre  { get; set; }


    [Required]
    [Range(70,300, ErrorMessage = "The duration must between 70 and 300")]
    public int Duration { get; set; }


    [Required]
    public string Director { get; set; }



}
