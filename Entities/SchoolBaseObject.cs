using System;

namespace Skul.Entities
{
    public class SchoolBaseObject
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public SchoolBaseObject() => UniqueId = Guid.NewGuid().ToString();

        public override string ToString() => $"{Name},{UniqueId}";
    }
}