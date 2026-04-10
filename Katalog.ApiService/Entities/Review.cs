namespace Katalog.ApiService.Entities;

public class Review
{
    public int Id { get; set; }
    public required string Comment { get; set; }
    public required byte Rating { get; set; }
    public DateTime CreatedAt { get; set; }

    // FK do filme que recebeu o review
    public required Movie Movie { get; set; }

    // FK do usuário que registrou a avaliação
    public required User User { get; set; }
}
