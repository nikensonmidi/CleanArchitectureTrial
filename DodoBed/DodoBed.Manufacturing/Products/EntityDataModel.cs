using DodoBed.Manufacturing.Application.Features.Products;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products
{
    public class ProductEntityDataModel
    {

        public IEdmModel GetEdmModel( )
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Product";
            builder.ContainerName = "ProductContainer";
            builder.EntitySet<ProductDTO>("Product").EntityType.HasKey(e => e.ProductId);

            return builder.GetEdmModel();

        }
    }
}
