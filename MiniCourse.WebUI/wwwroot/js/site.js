

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/basketHub")
    .build();

connection.start()
    .then(() => console.log("SignalR bağlantısı kuruldu."))
    .catch(err => console.error("SignalR bağlantısı başarısız:", err));


connection.on("ReceiveBasketItemCount", function (itemCount) {
    console.log("Sepet güncellendi:", itemCount);
    $("#basket-count").text(itemCount); 
});



$(document).on('click', '.add-to-basket', function () {

    const courseId = $(this).data('course-id');
    const quantityInput = $('#courseQuantity').val() ? $('#courseQuantity').val() : 1;
/*    const quantityInput = $('#courseQuantity').val();*/

 

    $.ajax({
        url: '/Basket/AddToBasket', 
        method: 'POST',
        data: { courseId: courseId, quantity: quantityInput },

        success: function (response) {
            console.log(response)
            if (response.isValid) {
                Toast.fire({
                    icon: response.isValid ? "success" : "error",
                    title: response.message,
                    customClass: {
                        popup: 'custom-toast-bg'
                    }
                });
            } else {
                Toast.fire({
                    icon: response.isValid ? "success" : "error",
                    title: response.message,
                    customClass: {
                        popup: 'custom-toast-bg'
                    }
                });
            }
        },
        error: function () {
            Toast.fire({
                icon: "error",
                title: "Bir hata oluştu. Lütfen tekrar deneyin.",
                customClass: {
                    popup: 'custom-toast-bg'
                }
            });
        }
    });
});

$(document).ready(function () {
    setTimeout(function () {
        $(".server-alert-success").slideUp();
    }, 2000);
});


let Toast = Swal.mixin({
    toast: true,
    position: "top-end",
    showConfirmButton: false,
    timer: 1200,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.onmouseenter = Swal.stopTimer;
        toast.onmouseleave = Swal.resumeTimer;
    }
});
