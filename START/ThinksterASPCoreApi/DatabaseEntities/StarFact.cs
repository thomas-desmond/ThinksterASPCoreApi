using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksterASPCoreApi.DatabaseEntities
{
    public class StarFact
    {
        public int Id { get; set; }
        public int StarId { get; set; }
        public string Fact { get; set; }
        public string Source { get; set; }
    }
}
