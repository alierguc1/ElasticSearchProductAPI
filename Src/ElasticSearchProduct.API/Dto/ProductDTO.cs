﻿using ElasticSearchProduct.API.Models;

namespace ElasticSearchProduct.API.Dto
{
    public record ProductDTO(string Id, string Name, string StockCode, decimal Price, int Stock, int WarrantyPeriod, ProductFeatureDTO? Feature)
    {

    }
}
