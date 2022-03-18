using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.Repositories;

public class CategoryRepository: BaseRepository<App.DAL.DTO.Category,App.Domain.Category, ApplicationDbContext>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new CategoryMapper(mapper))
    {
    }
    public override async Task<IEnumerable<Category>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }

        var resQuery = query
            .Include(c => c.AppUser).Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }


    public override async Task<Category?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(c => c.AppUser);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<Category> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(c => c.AppUser)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}