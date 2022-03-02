using PixSmith.MicroServices.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixSmith.MicroServices.Domain
{
    public class Record
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public RecordType Type { get; set; }

        public DateTime DateReleased { get; set; }

        public Artist? Artist { get; set; }
    }
}
