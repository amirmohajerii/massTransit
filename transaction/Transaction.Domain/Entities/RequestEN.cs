using TransactionMS.Domain.Entities;

public class RequestEN
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string RequestType { get; set; }
        public DateTime RequestDate { get; set; }
        public ICollection<TransactionEN> Transaction { get; set; }
}

