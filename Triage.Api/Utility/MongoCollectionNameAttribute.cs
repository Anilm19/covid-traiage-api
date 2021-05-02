using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                  System.AttributeTargets.Struct)]
    public class MongoCollectionNameAttribute : System.Attribute
    {
        public string CollectionName { get; set; }

        public MongoCollectionNameAttribute(string name)
        {
            this.CollectionName = name;
        }
    }
}
