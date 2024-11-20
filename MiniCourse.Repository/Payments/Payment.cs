namespace MiniCourse.Repository.Payments
{
    public class Payment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
