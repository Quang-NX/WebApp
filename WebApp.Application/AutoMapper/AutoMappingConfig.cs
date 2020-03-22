using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Application.AutoMapper
{
    public class AutoMappingConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DoaminToViewModelMappingProfile());
                    cfg.AddProfile(new ViewModelToDomainMappingProfile());
                }
            );
        }
    }
}
