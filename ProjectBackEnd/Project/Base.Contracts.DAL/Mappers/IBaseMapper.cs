namespace Base.Contracts.DAL.Mappers
{
    public interface IBaseMapper<TLeftObject, TRightObject>
    {
        TLeftObject? Map(TRightObject? inObject);
        TRightObject? Map(TLeftObject? inObject);
    }
}