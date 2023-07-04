using catering.Domain.Entities;
using catering.Domain.Interface;
using catering.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace catering.Infrastructure.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly StoreContext context;
        private readonly IWebHostEnvironment hostEnvironment;

        public OfferRepository(StoreContext context, IWebHostEnvironment hostEnvironment)
        {
            this.context = context;
			this.hostEnvironment = hostEnvironment;
        }

        public async Task Create(Product product)
        {
            context.Add(product);
            string wwRootPath = hostEnvironment.WebRootPath;
            string path = Path.Combine(wwRootPath + "/images/products/", product.ImageName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(fileStream);
            }
            await context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var productToDelete = await context.Products.FirstAsync(p => p.Id == id);
            context.Products.Remove(productToDelete);
            await context.SaveChangesAsync();
            string wwRootPath = hostEnvironment.WebRootPath;
            string path = Path.Combine(wwRootPath + "/images/products/", productToDelete.ImageName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await context.Products.FirstAsync(p => p.Id == id);
        }

        public Task<Product?> GetByName(string name)
		    => context.Products.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
	}
}
