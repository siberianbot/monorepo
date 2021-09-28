using System.IO;
using System.Text;
using System.Threading.Tasks;
using Datascapes.POC.SchemaModels;

namespace Datascapes.POC.SchemaWriter
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            string schemaPath = args[0];

            var objectDefs = new[]
            {
                new ObjectDefinition
                {
                    ObjectId = 1,
                    ParentObjectId = 0,
                    ObjectType = ObjectType.Storage,
                    Name = "SampleStorage"
                },
                new ObjectDefinition
                {
                    ObjectId = 2,
                    ParentObjectId = 1,
                    ObjectType = ObjectType.Dataset,
                    Name = "SampleDataset"
                },
                new ObjectDefinition
                {
                    ObjectId = 3,
                    ParentObjectId = 2,
                    ObjectType = ObjectType.Column,
                    Name = "Id"
                },
                new ObjectDefinition
                {
                    ObjectId = 4,
                    ParentObjectId = 2,
                    ObjectType = ObjectType.Column,
                    Name = "Name"
                },
            };

            using Stream schemaStream = File.Create(schemaPath);
            using DataWriter dataWriter = new DataWriter(schemaStream, Encoding.UTF8);

            foreach (ObjectDefinition def in objectDefs)
            {
                await dataWriter.WriteAsync(def);
            }
        }
    }
}