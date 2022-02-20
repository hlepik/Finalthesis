namespace PublicApi.DTO.v1.Mappers;

public abstract class BaseMapper<TLeftObject, TRightObject> : DAL.Base.BaseMapper<TLeftObject, TRightObject>
    where TRightObject : class?, new()
    where TLeftObject : class?, new()
{
}