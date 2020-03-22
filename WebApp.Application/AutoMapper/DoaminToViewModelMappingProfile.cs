using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Application.ViewModels.Product;
using WebApp.Data.Entities;

namespace WebApp.Application.AutoMapper
{
    public class DoaminToViewModelMappingProfile:Profile
    {
        public DoaminToViewModelMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
