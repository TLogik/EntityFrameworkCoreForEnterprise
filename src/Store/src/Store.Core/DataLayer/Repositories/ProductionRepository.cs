using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.DataLayer.Contracts;
using Store.Core.EntityLayer.Production;

namespace Store.Core.DataLayer.Repositories
{
    public class ProductionRepository : Repository, IProductionRepository
    {
        public ProductionRepository(IUserInfo userInfo, StoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IQueryable<Product> GetProducts(Int32? productCategoryID = null)
        {
            var query = DbContext.Set<Product>().AsQueryable();

            if (productCategoryID.HasValue)
                query = query.Where(item => item.ProductCategoryID == productCategoryID);

            return query;
        }

        public Task<Product> GetProductAsync(Product entity)
            => DbContext.Set<Product>().FirstOrDefaultAsync(item => item.ProductID == entity.ProductID);

        public Product GetProductByName(String productName)
            => DbContext.Set<Product>().FirstOrDefault(item => item.ProductName == productName);

        public void AddProduct(Product entity)
        {
            Add(entity);

            CommitChanges();
        }

        public async Task<Int32> UpdateProductAsync(Product changes)
        {
            Update(changes);

            return await CommitChangesAsync();
        }

        public void DeleteProduct(Product entity)
        {
            Remove(entity);

            CommitChanges();
        }

        public IQueryable<ProductCategory> GetProductCategories()
            => DbContext.Set<ProductCategory>();

        public ProductCategory GetProductCategory(ProductCategory entity)
            => DbContext.Set<ProductCategory>().FirstOrDefault(item => item.ProductCategoryID == entity.ProductCategoryID);

        public void AddProductCategory(ProductCategory entity)
        {
            Add(entity);

            CommitChanges();
        }

        public void UpdateProductCategory(ProductCategory changes)
        {
            Update(changes);

            CommitChanges();
        }

        public void DeleteProductCategory(ProductCategory entity)
        {
            Remove(entity);

            CommitChanges();
        }

        public IQueryable<ProductInventory> GetProductInventories(Int32? productID = null, String warehouseID = null)
        {
            var query = DbContext.Set<ProductInventory>().AsQueryable();

            if (productID.HasValue)
                query = query.Where(item => item.ProductID == productID);

            if (string.IsNullOrEmpty(warehouseID))
                query = query.Where(item => item.WarehouseID == warehouseID);

            return query;
        }

        public ProductInventory GetProductInventory(ProductInventory entity)
            => DbContext.Set<ProductInventory>().FirstOrDefault(item => item.ProductInventoryID == entity.ProductInventoryID);

        public Task<Int32> AddProductInventoryAsync(ProductInventory entity)
        {
            Add(entity);

            return CommitChangesAsync();
        }

        public async Task<Int32> UpdateProductInventoryAsync(ProductInventory changes)
        {
            Update(changes);

            return await CommitChangesAsync();
        }

        public void DeleteProductInventory(ProductInventory entity)
        {
            Remove(entity);

            CommitChanges();
        }

        public IQueryable<Warehouse> GetWarehouses()
            => DbContext.Set<Warehouse>();

        public async Task<Warehouse> GetWarehouseAsync(Warehouse entity)
            => await DbContext.Set<Warehouse>().FirstOrDefaultAsync(item => item.WarehouseID == entity.WarehouseID);

        public async Task<Int32> AddWarehouseAsync(Warehouse entity)
        {
            Add(entity);

            return await CommitChangesAsync();
        }

        public async Task<Int32> UpdateWarehouseAsync(Warehouse changes)
        {
            Update(changes);

            return await CommitChangesAsync();
        }

        public async Task<Int32> RemoveWarehouseAsync(Warehouse entity)
        {
            Remove(entity);

            return await CommitChangesAsync();
        }
    }
}
