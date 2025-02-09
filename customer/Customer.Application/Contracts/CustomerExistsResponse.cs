namespace Application.Contracts
{
    public class CustomerExistsResponse
    {
        public int CustomerId { get; set; } // Add this property
        public bool Exists { get; set; }
    }
}
