using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class CategoryService: BaseEntityService<IAppUnitOfWork, ICategoryRepository, App.BLL.DTO.Category, App.DAL.DTO.Category>, ICategoryService
{
    public CategoryService(IAppUnitOfWork serviceUow, ICategoryRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new CategoryMapper(mapper))
    {
    }
}