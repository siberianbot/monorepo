using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Datascapes.POC.SchemaModels;

namespace Datascapes.POC.SchemaReader
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            string schemaPath = args[0];

            List<ObjectDefinition> objDefs = new List<ObjectDefinition>();

            using Stream schemaStream = File.OpenRead(schemaPath);
            using DataReader dataReader = new DataReader(schemaStream, Encoding.UTF8);

            while (schemaStream.Position < schemaStream.Length)
            {
                objDefs.Add(await dataReader.ReadAsync<ObjectDefinition>());
            }

            Console.WriteLine("{0,-20} {1,-20} {2,-11} {3,-40}", "Object Id", "Parent Object Id", "Object Type", "Name");

            foreach (ObjectDefinition definition in objDefs)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-11} {3,-40}", definition.ObjectId, definition.ParentObjectId, definition.ObjectType, definition.Name);
            }
        }
    }
}