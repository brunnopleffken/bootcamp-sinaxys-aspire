namespace Katalog.ApiService.Entities;

public class Review
{
    public int Id { get; set; }
    public string Comment { get; set; }
    public byte Rating { get; set; }
    public DateTime CreatedAt { get; set; }

    // FK do filme que recebeu o review
    public Movie Movie { get; set; }
}
