using Microsoft.Extensions.DependencyInjection;
using TokenManager.Services;

namespace GestaoPessoaEad.Application
{
    public static class ServiceCollectionExtensionApplication
    {
        public static void RegistrarDependenciasApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<PrepararClient, PrepararClient>();
            serviceCollection.AddSingleton<SampleAppService, SampleAppService>();
        }
    }
}