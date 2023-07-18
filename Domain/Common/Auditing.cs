using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public abstract class Auditing
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
