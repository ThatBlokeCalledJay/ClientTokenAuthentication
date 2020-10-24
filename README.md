# Client Token Authentication
[![Build status](https://solvoterra.visualstudio.com/ThatBlokeCalledJay/_apis/build/status/GitHub%20Repos/GitHub%20ClientTokenAuthentication)](https://solvoterra.visualstudio.com/ThatBlokeCalledJay/_build/latest?definitionId=36)

Client token authentication middleware for ASP.Net core applications.

## Setup

### 1. Add the authentication scheme, middleware and token store.

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    // Add Client Token Auth Scheme + Middleware
    services.AddClientTokenAuthenticationScheme();
    
    // Add Your Implementation of ITokenUserStore
    services.AddTransient<ITokenUserStore, DummyTokenUserStore>();
}
```

If you are using swagger, you can also add the required security definitions.

```c#
public void ConfigureServices(IServiceCollection services)
{
    ...
    services.AddSwaggerGen(c =>
    {
        // Add Swagger Definitions
        c.AddClientTokenSecurityDefinitions();
    });
    ...
}
```

This will allow the user to authenticate swagger requests by providing the required `Client-ID` and `API-Key` header values.

### 2. Add Authorization

In `Startup.Configure` call  `app.UseAuthorization()` like normal. 

```c#
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...
    app.UseAuthorization();
    ...
}
```

### 3. Authenticate Endpoints

Finally, add the `AuthorizeClientToken` attribute to the controllers or individual endpoints that require client/token authentication.


```c#
[ApiController]
[Route("[controller]")]
[AuthorizeClientToken]
public class WeatherForecastController : ControllerBase
{
    ...
}
```

or

```c#
[HttpGet]
[AuthorizeClientToken]
public IEnumerable<WeatherForecast> Get()
{
    ...
}
```

## Example App

Header values required for the example app:  

**Client-ID:** *client-id*  
**API-Key:** *token*  

Example curl request:  

`curl -X GET "https://localhost:44357/WeatherForecast" -H  "accept: text/plain" -H  "Client-ID: client-id" -H  "API-Key: token"`

