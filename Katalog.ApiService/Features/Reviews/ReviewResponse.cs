namespace Katalog.ApiService.Features.Reviews;

public record ReviewResponse(
    int Id,
    string Comment,
    byte Rating,
    DateTime CreatedAt,
    ReviewUserResponse User);

public record ReviewUserResponse(string Name);
