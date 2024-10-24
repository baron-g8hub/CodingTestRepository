using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CompanyProfile : EntityStatus
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; } = string.Empty;
      
    }
}
