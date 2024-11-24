namespace MiniCourse.Service.Payments.DTOs
{
    public record PaymentRequest
    {
        public int OrderId { get; set; }
        public string NameForBill { get; set; } = default!;
        public string LastNameForBill { get; set; } = default!;
        public string AdressForBill { get; set; } = default!;
        public string CardHolderName { get; set; } = default!;
        public string CardNumber { get; set; } = default!;
        public string ExpiryDate { get; set; } = default!;
        public string CVV { get; set; } = default!;
        public int BasketId { get; set; }
    }
}
