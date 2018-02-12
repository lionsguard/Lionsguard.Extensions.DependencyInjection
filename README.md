# Lionsguard.Extensions.DependencyInjection
Extensions methods for adding and using dependency injection services with a key.

## Usage
### Defining your services:
```
 var services = new ServiceCollection()
    .AddTransientKeyServices<string, IStringKeyService>(builder =>
    {
        builder.Add<StringKeyServiceA>("A");
        builder.Add<StringKeyServiceB>("B");
        builder.Add<StringKeyServiceC>("C");
    })
    .BuildServiceProvider();
```

### Using reflection to find the services.
To use reflection decorate your service classes with the `KeyServiceAttribute`.
```
[KeyService("C")]
[KeyService("D")]
public class StringKeyServiceC : IStringKeyService
{
    public string GetValue() => "C";
}

var services = new ServiceCollection()
    .AddKeyServicesWithReflection<string, IStringKeyService>(ServiceLifetime.Transient)
    .BuildServiceProvider();
```

## ASP.NET Example
Within `Startup.cs` add the following to the `ConfigureServices` method:
```
public void ConfigureServices(IServiceCollection services)
{
    services.AddKeyServicesWithReflection<string, IStringKeyService>(ServiceLifetime.Transient);
}
```

## Console App Example
In `Program.cs`, within the `Main` method. Create your `ServiceCollection` instance.
```
static void Main(string[] args)
{
	var services = new ServiceCollection()
		.AddTransientKeyServices<string, IStringKeyService>(builder =>
		{
			builder.Add<StringKeyServiceA>("A");
			builder.Add<StringKeyServiceB>("B");
			builder.Add<StringKeyServiceC>("C");
		})
		.BuildServiceProvider();
}
```
