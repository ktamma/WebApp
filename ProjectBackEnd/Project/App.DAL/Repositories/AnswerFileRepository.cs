using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.Repositories;

public class AnswerFileRepository: BaseRepository<App.DAL.DTO.AnswerFile,App.Domain.AnswerFile, ApplicationDbContext>, IAnswerFileRepository
{
    public AnswerFileRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new AnswerFileMapper(mapper))
    {
    }
    public override async Task<IEnumerable<App.DAL.DTO.AnswerFile>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery = query
            .Include(a => a.FileType)
            .Include(a => a.QuizAnswer) .Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<AnswerFile?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {


        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        query = query
            .Include(a => a.FileType)
            .Include(a => a.QuizAnswer);
        var res = Mapper.Map(await query.FirstOrDefaultAsync(d => d.Id.Equals(id)));


        return res;
    }
    
    public override async Task<AnswerFile> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .Include(a => a.FileType)
            .Include(a => a.QuizAnswer)
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }


}