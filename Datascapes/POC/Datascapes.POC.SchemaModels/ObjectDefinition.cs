namespace Datascapes.POC.SchemaModels
{
    public record ObjectDefinition
    {
        [Order(0)]
        public long ObjectId { get; set; }
        
        [Order(1)]
        public long ParentObjectId { get; set; }
        
        [Order(2)]
        public ObjectType ObjectType { get; set; }
        
        [Order(3)]
        public string Name { get; set; } 
    }
}