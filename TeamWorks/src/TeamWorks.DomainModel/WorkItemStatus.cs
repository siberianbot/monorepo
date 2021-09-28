using TeamWorks.DomainModel.DataAnnotations;

namespace TeamWorks.DomainModel
{
    public enum WorkItemStatus : long
    {
        [Code("NEW")]
        New = 10,
    }
}