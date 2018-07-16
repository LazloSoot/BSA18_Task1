using System;

namespace ProjectStructure.Domain
{
    public class Entity
    {
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public Entity()
        {
            AddedDate = ModifiedDate = DateTime.Now;
        }
    }
}
