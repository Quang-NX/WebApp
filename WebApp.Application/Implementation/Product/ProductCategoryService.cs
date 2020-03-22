using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebApp.Application.Interfaces;
using WebApp.Application.ViewModels.Product;
using WebApp.Data.Entities;
using WebApp.Data.Enums;
using WebApp.Data.IRepositories;
using WebApp.Infrastructure.Interfaces;

namespace WebApp.Application.Implementation.Product
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(ProductCategoryViewModel productCategoryVm)
        {
            var productCategory = Mapper.Map<ProductCategoryViewModel, ProductCategory>(productCategoryVm);
            productCategoryRepository.Add(productCategory);
        }

        public void Delete(int id)
        {
            productCategoryRepository.Remove(id);
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            return productCategoryRepository.FindAll().OrderBy(x => x.ParentId)
                .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return productCategoryRepository.FindAll(x => x.Name.Contains(keyword)).OrderBy(x=>x.ParentId)
                    .ProjectTo<ProductCategoryViewModel>().ToList();
            }
            return productCategoryRepository.FindAll().OrderBy(x=>x.ParentId)
                    .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            return productCategoryRepository.FindAll(x => x.Status == Status.Active
                && x.ParentId == parentId)
                .ProjectTo<ProductCategoryViewModel>().ToList();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            return Mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategoryRepository.FindById(id));
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var query = productCategoryRepository
               .FindAll(x => x.HomeFlag == true, c => c.Products)
                 .OrderBy(x => x.HomeOrder)
                 .Take(top).ProjectTo<ProductCategoryViewModel>();

            var categories = query.ToList();
            foreach (var category in categories)
            {
                //category.Products = _productRepository
                //    .FindAll(x => x.HotFlag == true && x.CategoryId == category.Id)
                //    .OrderByDescending(x => x.DateCreated)
                //    .Take(5)
                //    .ProjectTo<ProductViewModel>().ToList();
            }
            return categories;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            throw new NotImplementedException();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}
