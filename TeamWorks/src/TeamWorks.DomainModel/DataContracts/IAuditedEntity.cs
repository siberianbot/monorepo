using System;

namespace TeamWorks.DomainModel.DataContracts
{
    public interface IAuditedEntity
    {
        DateTime? CreationDate { get; set; }
        
        long? CreationUserId { get; set; }
        
        DateTime? LastModifiedDate { get; set; }
        
        long? LastModifiedUserId { get; set; }
    }
}