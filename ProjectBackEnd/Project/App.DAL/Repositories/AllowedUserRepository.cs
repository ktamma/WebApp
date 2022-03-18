using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.Contracts.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Base.DAL.EF.Repositories;

namespace App.DAL.Repositories;


public class AllowedUserRepository: BaseRepository<App.DAL.DTO.AllowedUser, App.Domain.AllowedUser, ApplicationDbContext>, IAllowedUserRepository
{
    public AllowedUserRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new AllowedUserMapper(mapper))
    {
    }


    public override async Task<IEnumerable<AllowedUser>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            //return await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id .Equals(id));
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(a => a.AppUser)
            .Include(a => a.Quiz)
            .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<AllowedUser?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            //return await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id .Equals(id));
            query = query.AsNoTracking();
        }

        query = query
            .Include(a => a.AppUser)
            .Include(a => a.Quiz);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<AllowedUser> RemoveAsync(Guid id)
    {

        var allowedUser = await RepoDbSet
            .Include(a => a.AppUser)
            .Include(a => a.Quiz)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(allowedUser!).Entity)!;
    }
    
    
}