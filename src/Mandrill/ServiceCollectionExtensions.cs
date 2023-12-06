using Mandrill;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.Extensions.Configuration
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddMandrillApi(this IServiceCollection services, string apiKey, bool useHttps = true, bool useStatic = false, Action<IHttpClientBuilder> configureHttpClient = null)
    {

      services.AddSingleton(new MandrillApiOptions { ApiKey = apiKey });

      var builder = services.AddHttpClient<IMandrillApi, MandrillApi>(config =>
      {
        if (useHttps && useStatic)
          config.BaseAddress = new Uri(Mandrill.Configuration.BASE_STATIC_SECURE_URL);
        else if (useHttps && !useStatic)
          config.BaseAddress = new Uri(Mandrill.Configuration.BASE_SECURE_URL);
        else if (!useHttps && useStatic)
          config.BaseAddress = new Uri(Mandrill.Configuration.BASE_STATIC_URL);
        else
          config.BaseAddress = new Uri(Mandrill.Configuration.BASE_URL);
      });

      if (configureHttpClient != null)
        configureHttpClient(builder);

      return services;
    }
  }
}
