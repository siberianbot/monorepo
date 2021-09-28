using System;

namespace Datascapes.POC.SchemaModels
{
    public class OrderAttribute : Attribute
    {
        public int Idx { get; }

        public OrderAttribute(int idx)
        {
            Idx = idx;
        }
    }
}