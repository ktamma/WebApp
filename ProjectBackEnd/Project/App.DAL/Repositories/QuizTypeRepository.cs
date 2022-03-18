using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class QuizTypeRepository: BaseRepository<App.DAL.DTO.QuizType,App.Domain.QuizType, ApplicationDbContext>, IQuizTypeRepository
{
    public QuizTypeRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new QuizTypeMapper(mapper))
    {
    }
    public override async Task<IEnumerable<QuizType>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
       
        var resQuery = query.Select(entity=>Mapper.Map(entity));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<QuizType?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            //return await RepoDbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id .Equals(id));
            query = query.AsNoTracking();
        }

       
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<QuizType> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .FirstOrDefaultAsync(m => m.Id == id);

        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }

    public override QuizType Add(QuizType entity)
    {
        RepoDbSet.Add(Mapper.Map(entity)!);
        return entity;
    }
}