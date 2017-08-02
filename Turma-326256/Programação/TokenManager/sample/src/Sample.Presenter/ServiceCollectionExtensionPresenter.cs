using Sample.Application.AppServices.SampleAppService;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoPessoaEad.Presenter
{
    public static class ServiceCollectionExtensionPresenter
    {
        public static void RegistrarDependenciasPresenter(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<SampleAppService, SampleAppService>();
        }
    }
}