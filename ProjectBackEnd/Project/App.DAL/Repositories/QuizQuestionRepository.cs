using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class QuizQuestionRepository: BaseRepository<App.DAL.DTO.QuizQuestion,App.Domain.QuizQuestion, ApplicationDbContext>, IQuizQuestionRepository
{
    public QuizQuestionRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new QuizQuestionMapper(mapper))
    {
    }
    public override async Task<IEnumerable<QuizQuestion>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(q => q.Quiz) .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<QuizQuestion?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(q => q.Quiz);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<QuizQuestion> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(q => q.Quiz)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}