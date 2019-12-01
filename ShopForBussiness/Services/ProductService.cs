using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShopForBussiness.Dto;
using ShopForBussiness.Repositories;

namespace ShopForBussiness.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(string name, string category, float prize, string description, string imageUrl, int amountInMagazine)
        {
            await _productRepository.Add(new Domain.Product(1, name, category, prize, description,imageUrl, amountInMagazine));
        }

        public async Task<ProductDto> Get(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null) throw new ServiceException(Messages.PRODUCT_DOES_NOT_EXIST);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<string>> GetAuthors()
        {
            var products = await _productRepository.GetAll();
            return products.GroupBy(x => x.Author, x=>x,(x,y)=>x);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsWithAuthor(string author)
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products.Where(x => x.Author==author));
        }

        public async Task<IEnumerable<ProductDto>> GetWithText(string text)
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products.Where(x => x.Name.Contains(text)));
        }

        public async Task Remove(int id)
        {
            var product = await _productRepository.GetProduct(id);
            if(product==null) throw new ServiceException(Messages.PRODUCT_DOES_NOT_EXIST);
            await _productRepository.Remove(id);
        }

        public async Task Update(int id, string name, string author, float prize, string description,string imageUrl, int amountInMagazine)
        {
            var product = await _productRepository.GetProduct(id);
            if (product == null) throw new ServiceException(Messages.PRODUCT_DOES_NOT_EXIST);
            product.Name = name;
            product.Author = author;
            product.SetPrize(prize);
            product.Description = description;
            product.ImageUrl = imageUrl;
            product.SetAmountInMagazine(amountInMagazine);
            await _productRepository.Update(product);
        }
    }
}