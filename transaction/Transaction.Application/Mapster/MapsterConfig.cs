using Mapster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.DTOs;
using TransactionMS.Domain.Entities;

namespace Transaction.Application.Mapster
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<TransactionEN, TransactionDTO>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<RequestEN, RequestDTO>
                .NewConfig()
                .TwoWays();
        }
    }
}
