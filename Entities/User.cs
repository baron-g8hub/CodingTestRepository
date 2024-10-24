using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User  : EntityStatus
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public int PositionId { get; set; }

        public int CompanyId { get; set; }
    }
}
