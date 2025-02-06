using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastracture.http
{
    public interface ICustomerService
    {
        Task<bool> CustomerExistsAsync(int customerId);
    }
}