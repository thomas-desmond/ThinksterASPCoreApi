using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksterASPCoreApi.DatabaseEntities
{
    public class Planet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Mass { get; set; }
        public List<Moon> Moons { get; set; }
    }
}
