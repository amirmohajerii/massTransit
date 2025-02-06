using MediatR;


namespace Customer.Application.Features.LegalCustomer.Commnads
{
    public class CreateLegalCustomerCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public int UserId { get; set; }
    }
}
