using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThinksterASPCoreApi.DatabaseEntities
{
    public class Star
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double AgeInMillions { get; set; }
        public StarFact Fact { get; set; }
    }
}
