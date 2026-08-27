namespace School.Api.Mapping
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}
