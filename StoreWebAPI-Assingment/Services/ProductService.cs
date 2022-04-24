using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreWebAPI_Assingment.Models.Category;
using StoreWebAPI_Assingment.Models.Data;
using StoreWebAPI_Assingment.Models.Product;

namespace StoreWebAPI_Assingment.Services
{

    public interface IProductService
    {
        //CRUD
        public Task<ProductModel> CreateProductAsync(ProductRequest request);
        public Task<IEnumerable<ProductModel>> GetProductsAsync();
        public Task<ProductModel> GetProductAsync(Guid articleNr);
        public Task<ProductModel> UpdateProductAsync(Guid articleNr, ProductRequest request);
        public Task<bool> DeleteProductAsync(Guid articleNr);
    }

    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductModel> CreateProductAsync(ProductRequest request)
        {
            if (!await _context.Products.AnyAsync(x => x.Name == request.Name))
            {
                var productEntity = _mapper.Map<ProductEntity>(request);

                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.CategoryName);
                if (categoryEntity == null)
                {
                    productEntity.Category = new CategoryEntity { Name = request.CategoryName };
                }
                else
                {
                    productEntity.CategoryId = categoryEntity.Id;
                }

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductModel>(productEntity);
            }

            return null!;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return _mapper.Map<IEnumerable<ProductModel>>(await _context.Products.Include(x => x.Category).ToListAsync());
        }

        public async Task<ProductModel> GetProductAsync(Guid articleNr)
        {
            return _mapper.Map<ProductModel>(await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ArticleNumber == articleNr));
        }

        public async Task<ProductModel> UpdateProductAsync(Guid articleNr, ProductRequest request)
        {
            var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ArticleNumber == articleNr);
            if (productEntity != null)
            {
                if (productEntity.Name != request.Name && !string.IsNullOrEmpty(request.Name))
                    productEntity.Name = request.Name;

                if (productEntity.Description != request.Description && !string.IsNullOrEmpty(request.Description))
                    productEntity.Description = request.Description;

                if (productEntity.Price != request.Price && request.Price != 0)
                    productEntity.Price = request.Price;

                if (productEntity.Category.Name != request.CategoryName && !string.IsNullOrEmpty(request.CategoryName))
                    productEntity.Category.Name = request.CategoryName;

                _context.Entry(productEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductModel>(productEntity);
            }

            return null!;
        }

        public async Task<bool> DeleteProductAsync(Guid articleNr)
        {
            var productEntity = await _context.Products.FindAsync(articleNr);
            if (productEntity != null)
            {
                _context.Products.Remove(productEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
