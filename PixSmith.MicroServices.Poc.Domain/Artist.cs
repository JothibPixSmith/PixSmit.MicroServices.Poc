using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixSmith.MicroServices.Domain
{
    public class Artist
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public List<Record>? Discography { get; set; }
    }
}
