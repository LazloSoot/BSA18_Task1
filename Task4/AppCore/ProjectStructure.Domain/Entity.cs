using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectStructure.Domain
{
    public class Entity
    {
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
