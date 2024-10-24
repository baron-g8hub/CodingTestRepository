using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EntityStatus
    {
        public bool? IsActive { get; set; }

        public DateTime? CreatedDate { get; set; } = new DateTime();

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; } = new DateTime();

        public string? UpdatedBy { get; set; }
    }
}
