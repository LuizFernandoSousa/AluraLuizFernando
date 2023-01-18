using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.Dtos;

public class ReadMovieDto
{

    public string Tittle { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public string Director { get; set; }

    public DateTime ConsultationDate { get; set; } = DateTime.Now;


}
