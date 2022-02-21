using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookStoreApp.Blazor.Server.UI.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
        public ApiAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var savedToke = await _localStorageService.GetItemAsync<string>("accessToken");
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            if (null == savedToke)
            {
                return new AuthenticationState(user);
            }

            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToke);
            if (DateTime.Now > tokenContent.ValidTo)
            {
                return new AuthenticationState(user);
            }
            var claims = tokenContent.Claims;

            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            return new AuthenticationState(user);
        }

        public async Task LoggedIn()
        {
            var savedToke = await _localStorageService.GetItemAsync<string>("accessToken");
            var tokenContent = _jwtSecurityTokenHandler.ReadJwtToken(savedToke);
            var claims = tokenContent.Claims;
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        public void LoggedOut()
        {
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }

    }
}
