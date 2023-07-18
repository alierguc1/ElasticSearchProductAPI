
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using ElasticSearchProduct.API.Repositories.Concrete;
using ElasticSearchProduct.API.Repositories.Interfaces;
using ElasticSearchProduct.API.Services.Concrete;
using ElasticSearchProduct.API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


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

            /* FOR NEST LIBRARY
           var pool = new SingleNodeConnectionPool(new Uri(configuration.GetSection("Elastic")["Url"]!));
           //var pool = new SingleNodeConnectionPool(new Uri("http://elk-stack-elasticsearch-1:9200"));
           var settings = new ConnectionSettings(pool);
           var client = new ElasticClient(settings);
           */


         
            var userName = (configuration.GetSection("Elastic")["Username"]!);
            var passWord = (configuration.GetSection("Elastic")["Password"]!);
            var settings = new ElasticsearchClientSettings(new Uri(configuration.GetSection("Elastic")["Url"]!))
                .Authentication(new BasicAuthentication(userName, passWord));
            var client = new ElasticsearchClient(settings);

            services.AddSingleton(client);
        }
    }
}
