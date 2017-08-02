using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TokenManager.Entities;
using TokenManager.Services;

namespace GestaoPessoaEad.Core
{
    public static class ServiceCollectionExtensionsCore
    {
        public static void RegistrarDependenciasCore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<Token, Token>();
            serviceCollection.AddSingleton<Request, Request>();
            serviceCollection.AddSingleton<AdicionarHeader, AdicionarHeader>();
            serviceCollection.AddSingleton<HttpClient, HttpClient>();
            serviceCollection.AddSingleton<PrepararClient, PrepararClient>();
        }
    }
}