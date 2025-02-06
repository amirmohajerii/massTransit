using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionMS.Domain.Entities
{

    public class TransactionEN
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public decimal Amount { get; set; }
            public DateTime TransactionDate { get; set; }
            public int RequestId { get; set; }
            public RequestEN Request { get; set; }
        }

}

