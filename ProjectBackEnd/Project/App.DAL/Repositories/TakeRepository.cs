using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class TakeRepository: BaseRepository<App.DAL.DTO.Take,App.Domain.Take, ApplicationDbContext>, ITakeRepository
{
    public TakeRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new TakeMapper(mapper))
    {
    }
    public override async Task<IEnumerable<Take>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(t => t.AppUser)
            .Include(t => t.Quiz) .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<Take?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(t => t.AppUser)
            .Include(t => t.Quiz);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<Take> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(t => t.AppUser)
            .Include(t => t.Quiz)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}