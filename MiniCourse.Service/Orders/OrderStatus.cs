namespace MiniCourse.Service.Orders
{
    public enum OrderStatus
    {
        // Sipariş yeni oluşturuldu, ödeme bekliyor
        Pending = 1,

        // Ödeme başarılı, sipariş hazirlaniyor
        Paid = 2,

        // Ödeme yapılmadı veya başarısız oldu
        Cancelled = 3,

        // Sipariş tamamlandı, ürün teslim edildikten sonra
        Completed = 4,

        // Sipariş iade edildi
        Returned = 5
    }
}
