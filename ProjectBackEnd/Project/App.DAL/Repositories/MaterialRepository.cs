using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class MaterialRepository : BaseRepository<App.DAL.DTO.Material, App.Domain.Material, ApplicationDbContext>,
    IMaterialRepository
{
    public MaterialRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext,
        new MaterialMapper(mapper))
    {
    }

    public override async Task<IEnumerable<Material>> GetAllAsync(bool noTracking = true)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }

        var resQuery = query
            .Include(m => m.Category)
            .Include(m => m.FileType).Select(x => Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<Material?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {
        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }

        query = query
            .Include(m => m.Category)
            .Include(m => m.FileType);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }

    public override async Task<Material> RemoveAsync(Guid id)
    {
        var res = await RepoDbSet
            .Include(m => m.Category)
            .Include(m => m.FileType)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}