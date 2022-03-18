using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class QuizAnswerRepository: BaseRepository<App.DAL.DTO.QuizAnswer,App.Domain.QuizAnswer, ApplicationDbContext>, IQuizAnswerRepository
{
    public QuizAnswerRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new QuizAnswerMapper(mapper))
    {
    }
    public override async Task<IEnumerable<QuizAnswer>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(q => q.QuizQuestion)
            .Include(q => q.Type) .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<QuizAnswer?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(q => q.QuizQuestion)
            .Include(q => q.Type);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<QuizAnswer> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(q => q.QuizQuestion)
            .Include(q => q.Type)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}