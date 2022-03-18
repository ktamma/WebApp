using App.DAL.Contracts.Repositories;
using App.DAL.DTO;
using App.DAL.Mappers;
using AutoMapper;
using Base.DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories;

public class FileTypeRepository: BaseRepository<App.DAL.DTO.FileType,App.Domain.FileType, ApplicationDbContext>, IFileTypeRepository
{
    public FileTypeRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, new FileTypeMapper(mapper))
    {
    }
    public override async Task<IEnumerable<FileType>> GetAllAsync(bool noTracking = true)
    {

        var query = RepoDbSet.AsQueryable();
        if (noTracking)
        {
            query = query.AsNoTracking();
        }
        var resQuery =  query.Select(x=>Mapper.Map(x));
        var res = await resQuery.ToListAsync();

        return res!;
    }

    public override async Task<FileType?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
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
    
    public override async Task<FileType> RemoveAsync(Guid id)
    {

        var res = await RepoDbSet
            .FirstOrDefaultAsync(m => m.Id == id);
        return Mapper.Map(RepoDbSet.Remove(res!).Entity)!;
    }
    
}