using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.Data.Entities;
using WebApp.Data.IRepositories;
using WebApp.Infrastructure.Interfaces;

namespace WebApp.Data.EF.Repositories
{
    public class ProductCategoryRepository:EFRepository<ProductCategory,int>, IProductCategoryRepository
    {
        private readonly AppDbContext _context;
        public ProductCategoryRepository(AppDbContext context)
            : base(context)
        {
            _context = context;
        }

        public List<ProductCategory> GetByAlias(string alias)
        {
            return _context.ProductCategories.Where(x => x.SeoAlias.Contains(alias)).ToList();
        }
    }
}
