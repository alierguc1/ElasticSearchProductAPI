using ElasticSearchProduct.API.Repositories.Concrete;
using ElasticSearchProduct.API.Repositories.Interfaces;
using ElasticSearchProduct.API.Services.Concrete;
using ElasticSearchProduct.API.Services.Interfaces;

namespace ElasticSearchProduct.API.Extension
{
    public static class InversionOfControlClass
    {
        public static void AddInversionOfContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductService,ProductService>();
            services.AddAutoMapper();
        }
    }
}
