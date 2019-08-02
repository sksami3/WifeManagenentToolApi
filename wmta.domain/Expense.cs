using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmta.domain.Base;

namespace wmta.domain
{
    public class Expense: BaseModel
    {
        public string reason { get; set; }
        public decimal cost { get; set; }
    }
}
