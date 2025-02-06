using Mapster;
using Customer.Domain.Entities;

namespace Customer.Application.Mapster
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<IndividualCustomer, IndividualCustomerDTO>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<LegalCustomer, LegalCustomerDTO>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<Role,RoleDTO>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<User, UserDTO>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<UserRole,UserRoleDTO>
                .NewConfig()
                .TwoWays();
        }
    }
}
