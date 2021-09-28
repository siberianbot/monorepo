namespace Datascapes.POC.SchemaModels
{
    public record DatasetDefinition
    {
        [Order(0)]
        public long ObjectId { get; set; }
        
        [Order(1)]
        public DatasetType DatasetType { get; set; } 
    }
}