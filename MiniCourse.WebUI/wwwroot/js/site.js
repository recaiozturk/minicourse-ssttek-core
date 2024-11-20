
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/basketHub")
    .build();

connection.start()
    .then(() => console.log("SignalR bağlantısı kuruldu."))
    .catch(err => console.error("SignalR bağlantısı başarısız:", err));

// Sepet güncellemelerini dinleyin
connection.on("ReceiveBasketItemCount", function (itemCount) {
    console.log("Sepet güncellendi:", itemCount);
    $("#basket-count").text(itemCount); 
});

$(document).on('click', '.add-to-basket', function () {
    const courseId = $(this).data('course-id');
    console.log(courseId)

    $.ajax({
        url: '/Basket/AddToBasket', 
        method: 'POST',
        data: { courseId: courseId,  quantity: 1 },
        success: function (response) {
            console.log(response)
            if (response.isValid) {
                alert(response.message);
            } else {
                alert(response.message);
            }
        },
        error: function () {
            alert("Bir hata oluştu. Lütfen tekrar deneyin.");
        }
    });
});
