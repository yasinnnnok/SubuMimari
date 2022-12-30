using AutoMapper;
using SUBU.DataAccess.EntityFramework.Repositories;
using SUBU.DataAccess.EntityFramework.UnitOfWork;
using SUBU.Entities.EntityFramework.Database1;
using SUBU.Models;
using SUBU.Services.Contans;

namespace SUBU.Services.EntityFramework.Managers;

public interface IProductService
{
	IDataResult<IEnumerable<Product>> ListAll();
	IDataResult<Product> FindSerialNumber(string serialNumber);
	IDataResult<ProductQuery> FindById(int id);
	IDataResult<ProductUpdate> Update(ProductUpdate model);
	IDataResult<string> Create(ProductCreate model);
	IDataResult<string> Delete(int id);
}

public class ProductService : IProductService
{
	private readonly IDatabase1UnitOfWork2 _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IProductRepository _productRepository;

	public ProductService(IDatabase1UnitOfWork2 unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		//burada yukarıdaki Repository'i çağırmadan injectionnunu unitofWork üzerinden yapıyoruz.
		_productRepository = _unitOfWork.GetRepository<IProductRepository>();
	}

	public IDataResult<string> Create(ProductCreate model)
	{
		var user = _productRepository.Queryable().Where(x => x.SerialNumber == model.SerialNumber && x.Name == model.Name).FirstOrDefault();
		if (user == null)
		{
			Product modelProduct = _productRepository.Add(_mapper.Map<Product>(model));
			_productRepository.Save();
			return new DataResult<string>(true, Messages.Save(nameof(Product)));
		}
		return new DataResult<string>(Messages.SaveError(nameof(Product)));
	}

	public IDataResult<string> Delete(int id)
	{
		var product = _productRepository.Get(id);
		if (product != null)
		{
			_productRepository.Remove(id);
			_productRepository.Save();
			return new DataResult<string>(true, Messages.Delete(nameof(Product)));
		}
		return new DataResult<string>(Messages.DeleteError(nameof(Product)));
	}

	public IDataResult<ProductQuery> FindById(int id)
	{
		var product = _productRepository.Get(id);
		if (product != null)
		{
			return new DataResult<ProductQuery>(true, _mapper.Map<ProductQuery>(product));
		}
		return new DataResult<ProductQuery>(Messages.NotFound(nameof(Product)));
	}

	public IDataResult<Product> FindSerialNumber(string serialNumber)
	{
		return new DataResult<Product>(true, _productRepository.Queryable().Where(x => x.SerialNumber == serialNumber).ToList()
			.Select(x => _mapper.Map<Product>(x))
			.FirstOrDefault()!);
	}

	public IDataResult<IEnumerable<Product>> ListAll()
	{
		return new DataResult<IEnumerable<Product>>(true, _productRepository.GetAll().ToList()
			.Select(x => _mapper.Map<Product>(x))
			.ToList());
	}
	
	public IDataResult<ProductUpdate> Update(ProductUpdate model)
	{
		var product = _productRepository.Get(model.Id);
		//map i bu şekilde kullanıyoruz. modelii artiste maple. (newlemeden)
		if (product != null)
		{
			_productRepository.Update(model.Id, _mapper.Map(model, product));
			_productRepository.Save();
			
			return new DataResult<ProductUpdate>(true, Messages.Update(nameof(Product)), _mapper.Map<ProductUpdate>(product));
		}
		return new DataResult<ProductUpdate>(Messages.UpdateError(nameof(Product)));
	}
}