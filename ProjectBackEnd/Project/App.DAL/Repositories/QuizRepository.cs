using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class QuizRepository: BaseRepository<App.DAL.DTO.Quiz,App.Domain.Quiz, ApplicationDbContext>, IQuizRepository
{
    public QuizRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new QuizMapper(mapper))
    {
    }
    public override async Task<IEnumerable<Quiz>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(q => q.Category)
            .Include(q => q.QuizType) .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<Quiz?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(q => q.Category)
            .Include(q => q.QuizType);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<Quiz> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(q => q.Category)
            .Include(q => q.QuizType)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
}