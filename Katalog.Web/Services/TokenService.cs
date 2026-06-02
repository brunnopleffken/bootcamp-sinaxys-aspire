using Microsoft.JSInterop;

namespace Katalog.Web.Services;

public class TokenService(IJSRuntime runtime)
{
    public ValueTask SetTokenAsync(string token) =>
        runtime.InvokeVoidAsync("AuthStorage.setToken", token);

    public ValueTask<string?> GetTokenAsync() =>
        runtime.InvokeAsync<string?>("AuthStorage.getToken");

    public ValueTask RemoveTokenAsync() =>
        runtime.InvokeVoidAsync("AuthStorage.removeToken");
}
