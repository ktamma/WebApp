using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class QuizMaterialRepository: BaseRepository<App.DAL.DTO.QuizMaterial,App.Domain.QuizMaterial, ApplicationDbContext>, IQuizMaterialRepository
{
    public QuizMaterialRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new QuizMaterialMapper(mapper))
    {
    }
    public override async Task<IEnumerable<QuizMaterial>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(q => q.Material)
            .Include(q => q.Quiz) .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<QuizMaterial?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(q => q.Material)
            .Include(q => q.Quiz);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<QuizMaterial> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(q => q.Material)
            .Include(q => q.Quiz)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}