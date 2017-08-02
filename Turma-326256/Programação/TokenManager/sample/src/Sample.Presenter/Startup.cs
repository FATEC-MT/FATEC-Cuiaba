using FluentValidation.AspNetCore;
using GestaoPessoaEad.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GestaoPessoaEad.Presenter
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.RegistrarDependenciasApplication();
            services.RegistrarDependenciasPresenter();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseMvc(route => route.MapRoute("padrao", "{controller}/{action=Index}"));
        }
    }
}
