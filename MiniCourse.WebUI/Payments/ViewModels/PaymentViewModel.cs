namespace MiniCourse.WebUI.Payments.ViewModels
{
    public record PaymentViewModel
    {
        public int OrderId { get; set; } // Sipariş ID'si
        public string NameForBill { get; set; } = default!;
        public string LastNameForBill { get; set; } = default!;
        public string AdressForBill { get; set; } = default!;
        public string CardHolderName { get; set; } = default!; // Kart sahibi adı
        public string CardNumber { get; set; } = default!; // Kart numarası
        public string ExpiryDate { get; set; } = default!; // Kart son kullanma tarihi
        public string CVV { get; set; } = default!; // Güvenlik kodu

        public int BasketId { get; set; }

    }
}
