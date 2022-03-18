using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class TakeAnswerRepository: BaseRepository<App.DAL.DTO.TakeAnswer,App.Domain.TakeAnswer, ApplicationDbContext>, ITakeAnswerRepository
{
    public TakeAnswerRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new TakeAnswerMapper(mapper))
    {
    }
    public override async Task<IEnumerable<TakeAnswer>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(t => t.QuizAnswer)
            .Include(t => t.QuizQuestion)
            .Include(t => t.Take) .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<TakeAnswer?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(t => t.QuizAnswer)
            .Include(t => t.QuizQuestion)
            .Include(t => t.Take);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<TakeAnswer> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(t => t.QuizAnswer)
            .Include(t => t.QuizQuestion)
            .Include(t => t.Take)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}