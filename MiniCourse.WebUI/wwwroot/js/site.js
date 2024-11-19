// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).on('click', '.add-to-basket', function () {
    const courseId = $(this).data('course-id');
    console.log(courseId)


    //if (!userId) {
    //    alert("Sepete eklemek için giriş yapmalısınız!");
    //    return;
    //}

    $.ajax({
        url: '/Basket/AddToBasket', 
        method: 'POST',
        data: { courseId: courseId,  quantity: 1 },
        success: function (response) {
            console.log(response)
            if (response.isValid) {
                alert(response.message);
                $("#basket-count").text(response.data.basketItemsCount);
            } else {
                alert(response.message);
            }
        },
        error: function () {
            alert("Bir hata oluştu. Lütfen tekrar deneyin.");
        }
    });
});
