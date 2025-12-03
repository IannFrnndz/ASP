using System;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    public int ID { get; set; }

    public string Title { get; set; }

    [Required(ErrorMessage = "La fecha de estreno es obligatoria")]
    public DateTime ReleaseDate { get; set; }

    public decimal Price { get; set; }
}
