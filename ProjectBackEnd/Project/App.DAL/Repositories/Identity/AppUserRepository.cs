using App.DAL.Contracts.Repositories.Identity;
using App.DAL.DTO.Identity;
using App.DAL.Mappers.Identity;
using AutoMapper;
using Base.Contracts.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Base.DAL.EF.Repositories;

namespace App.DAL.Repositories.Identity;

public class AppUserRepository: BaseRepository<App.DAL.DTO.Identity.AppUser, App.Domain.Identity.AppUser, ApplicationDbContext>, IAppUserRepository
{
    public AppUserRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new AppUserMapper(mapper))
    {
    }

    public override async Task<IEnumerable<AppUser>> GetAllAsync(bool noTracking = true)
    {
        
        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            //return await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id .Equals(id));
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }
}