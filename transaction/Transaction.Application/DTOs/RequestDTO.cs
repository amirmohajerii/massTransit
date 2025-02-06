using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Application.DTOs
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
