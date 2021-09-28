namespace TeamWorks.DomainModel.DataContracts
{
    public interface IScopedEntity
    {
        long? ScopeId { get; set; }

        Scope Scope { get; set; }
    }
}