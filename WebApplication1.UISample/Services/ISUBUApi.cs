using Refit;
using SUBU.Models;

namespace WebApplication1.UISample.Services;

public interface ISUBUApi
{
	[Get("/Product/List")]
	Task<SUBU.Models.ApiResponse<IEnumerable<ProductQuery>>> GetProducts();
	
	[Post("/Product/Save")]
	Task<ApiResponse> SaveProduct(ProductCreate request);
	
	[Delete("/Product/Delete")]
	Task<ApiResponse> DeleteProduct([Query] int id);

	[Put("/Product/Update")]
	Task<SUBU.Models.ApiResponse<ProductUpdate>> UpdateProduct([Query] int id, ProductUpdate model);

	[Get("/Product/FindById")]
	Task<SUBU.Models.ApiResponse<ProductQuery>> GetProductById([Query] int id);
}
