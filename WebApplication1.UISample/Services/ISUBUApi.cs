using Refit;
using SUBU.Models;

namespace WebApplication1.UISample.Services;

[Headers("Accept: application/json")]
public interface ISUBUApi
{
	[Get("/Product/List")]
	Task<Refit.ApiResponse<SUBU.Models.ApiResponse<IEnumerable<ProductQuery>>>> GetProducts();
	
	[Post("/Product/Save")]
	Task<Refit.ApiResponse<ApiResponse>> SaveProduct(ProductCreate productCreate);
	
	[Delete("/Product/Delete")]
	Task<Refit.ApiResponse<ApiResponse>> DeleteProduct([Query] int id);

	[Put("/Product/Update")]
	Task<Refit.ApiResponse<SUBU.Models.ApiResponse<ProductUpdate>>> UpdateProduct(ProductUpdate productUpdate);

	[Get("/Product/FindById")]
	Task<Refit.ApiResponse<SUBU.Models.ApiResponse<ProductQuery>>> GetProductById([Query] int id);
}
