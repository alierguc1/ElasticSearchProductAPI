﻿using Elasticsearch.Net;
using ElasticSearchProduct.API.Repositories.Concrete;
using ElasticSearchProduct.API.Repositories.Interfaces;
using ElasticSearchProduct.API.Services.Concrete;
using ElasticSearchProduct.API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace ElasticSearchProduct.API.Extension
{
    public static class ElasticDependencies
    {
        /// <summary>
        /// Elastic Search Dependencies / Extensions
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddElasticSearchDependency(this IServiceCollection services,IConfiguration configuration)
        {
            var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));
            var settings = new ConnectionSettings(pool);
            var client = new ElasticClient(settings);
          
            services.AddSingleton(client);
        }
    }
}
