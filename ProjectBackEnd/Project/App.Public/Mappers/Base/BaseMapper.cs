using AutoMapper;
using Base.Contracts.Public.Mappers;

namespace App.Public.Mappers.Base
{
    public class BaseMapper<TLeftEntity, TRightEntity> : IBaseMapper<TLeftEntity, TRightEntity>
    {
        protected IMapper Mapper;
        
        public BaseMapper(IMapper mapper)
        {
            Mapper = mapper;
        }
        public virtual TLeftEntity? Map(TRightEntity? inObject)
        {
            return Mapper.Map<TLeftEntity>(inObject);
        }

        public virtual TRightEntity? Map(TLeftEntity? inObject)
        {
            return Mapper.Map<TRightEntity>(inObject);
        }
    }
}