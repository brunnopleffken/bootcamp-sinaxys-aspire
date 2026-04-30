namespace Katalog.ApiService.Features.Movies;

public record MoviesIndexResponse(List<MoviesResponse> Movies, int Count);
